using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Const;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class TableStatusJob : IJob
{
    private readonly IUnitOfWork _unitOfWork;
    public TableStatusJob(RMContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    public Task Execute(IJobExecutionContext context)
    {
        string formatDate = DateTime.Today.ToShortDateString();
        StringBuilder sb = new StringBuilder();
        var reses = _unitOfWork.Reservations.GetAll().ToList();
        var todayRes = new List<Reservation>();
        foreach (var res in reses)
        {
            sb.Append(res.ReservedDate.ToShortDateString());
            if (sb.ToString() == formatDate)
            {
                todayRes.Add(res);
            }
            sb.Clear();
        }
        foreach (var res in todayRes)
        {
            TimeSpan span = DateTime.Now.Subtract(res.ReservedDate);
            var currentTable = _unitOfWork.Tables.GetAll().FirstOrDefault(t => t.Number == res.TableNumber);
            if (span.TotalMinutes > 30 && currentTable.Status == TableStatus.Reserved)
            {
                currentTable.Status = TableStatus.Available;
            }
        }
        _unitOfWork.Save();
        return Task.CompletedTask;
    }
}
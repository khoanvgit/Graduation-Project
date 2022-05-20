$(document).ready(function () {
    $("#customerpay").on('keyup', function () {
        var total = $("#totalM").val();
        var pay = $("#customerpay").val();
        var rs = (Math.round((pay - total) * 100) / 100).toFixed(2);
        $("#changemoney").val(rs);
        if ($("#customerpay").val() == "")
            $("#changemoney").val("");
    });


    $('#btnClearSearch').on('click', function () {
        $("#myInput").val("");
        $("#myInput").trigger("keyup");
    });

    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
})
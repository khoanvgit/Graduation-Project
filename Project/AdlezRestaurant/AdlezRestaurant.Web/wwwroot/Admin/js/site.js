$(function () {
    $("#loaderbody").addClass('d-none');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('d-none');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('d-none');
    });
});

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    });
};

JqueryAjaxPost = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    if (res.html == "") {
                        window.location.reload();
                    }
                    $('#view_all').html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    $.notify('Submit successfully', { globalPosition: 'top center', className: 'success' });
                    $.getScript("/Admin/js/userDatatable.js");
                }
                else {
                    $('#form-modal .modal-body').html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};

JqueryAjaxDelete = form => {
    if (confirm("Are you sure to delete this record?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#view_all').html(res.html);
                        $.notify('Delete successfully', { globalPosition: 'top center', className: 'success' });
                        $.getScript("/Admin/js/userDatatable.js");
                    }
                },
                error: function (err) {
                    console.log(err.responseText);
                }
            });
        }
        catch (e) {
            console.log(e);
        }
    }
    // prevent form submit event
    return false;
};

tableClick = (url) => {
    try {
        $.ajax({
            type: "POST",
            url: url,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view_detail').html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};

chooseDish = (url, str, tabNum) => {
    try {
        var num = $('#' + str).val();
        $.ajax({
            type: "POST",
            url: url + "&number=" + num + "&tableNumber=" + tabNum,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view_detail').html(res.html);
                    $.notify('Add dish successfully', { globalPosition: 'top center', className: 'success' });
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};

createOrder = (url, tabNum) => {
    try {

        $.ajax({
            type: "POST",
            url: url + "&tableNumber=" + tabNum,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view_tables').html(res.html);
                    $.notify('Create order successfully', { globalPosition: 'top center', className: 'success' });
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};

cancelDish = (url, tabNum) => {
    if (confirm("Are you sure to cancel this dish?")) {
        try {
            $.ajax({
                type: "POST",
                url: url + "&tableNumber=" + tabNum,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#view_detail').html(res.html);
                        $.notify('Cancel dish successfully', { globalPosition: 'top center', className: 'success' });
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
        catch (e) {
            console.log(e);
        }
    }
    // prevent form submit event
    return false;
};

payOrder = (url) => {
    try {
        var mop = $('#mop option:selected').text();
        $.ajax({
            type: "POST",
            url: url + "&mop=" + mop,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view_tables').html(res.html);
                    $('#view_detail').html('');
                    $.notify('Pay successfully', { globalPosition: 'top center', className: 'success' });
                }
                else {
                    $('#view_tables').html(res.html);
                    $('#view_detail').html('');
                    $.notify('Pay failed...', { globalPosition: 'top center', className: 'danger' });
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};

JqueryAjaxCustomerOrder = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    $('#view_detail').html('');
                    $('#view_tables').html(res.html);
                }
                else {
                    $('#form-modal .modal-body').html(res.html);
                }
            },
            error: function (err) {
                console.log("error: " + err.responseText);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};

cancelOrder = (url) => {
    if (confirm("Are you sure to cancel this order?")) {
        try {
            $.ajax({
                type: "POST",
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#view_tables').html(res.html);
                        $('#view_detail').html('');
                        $.notify('Cancel order successfully', { globalPosition: 'top center', className: 'success' });
                    }
                },
                error: function (err) {
                    console.log(err.responseText);
                }
            });
        }
        catch (e) {
            console.log(e);
        }
    }
    // prevent form submit event
    return false;
};

showStatisticReport = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#statisticReport').html(res.html);
                    $.notify('Successfully', { globalPosition: 'top center', className: 'success' });
                }
                else {
                    $('#statisticReport').html(res.html);
                    $.notify('There is no event this day', { globalPosition: 'top center', className: 'error' });
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    catch (e) {
        console.log(e);
    }
    // prevent form submit event
    return false;
};
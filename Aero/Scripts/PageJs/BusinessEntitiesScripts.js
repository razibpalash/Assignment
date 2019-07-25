var datatable = $('#datatable').DataTable({
    "ajax": {
        "url": '/BusinessEntities/GetAllBusinessEntity',
        "type": "GET",
        "dataType": "json"
    },
    "columns": [
        { "data": "Code", "autoWidth": true },
        { "data": "Name", "autoWidth": true },
        { "data": "Email", "autoWidth": true },
        { "data": "Country", "autoWidth": true },
        { "data": "Mobile", "autoWidth": true },
        { "data": "CurrentBalance", "autoWidth": true },
        {
            "data": "BusinessId", "width": "80px", "render": function (data) {
                return '<a class="popup" href="#" onclick="Edit(' + data + ');">Edit</a> | <a href="#" onclick="Delele(' + data + ');">Delete</a></td>';
            }
        }
    ]
});

function Add() {
    if ($('#Balance').val() == '') {
        alert('Balance field is Required!!');
        return;
    }
    if ($('#CurrentBalance').val() == '') {
        alert('Current Balance field is Required!!');
        return;
    }
    var data = {
        Code: $('#Code').val(),
        Email: $('#Email').val(),
        Name: $('#Name').val(),
        Street: $('#Street').val(),
        City: $('#City').val(),
        State: $('#State').val(),
        Zip: $('#Zip').val(),
        Country: $('#Country').val(),
        Mobile: $('#Mobile').val(),
        Phone: $('#Phone').val(),
        ContactPerson: $('#ContactPerson').val(),
        ReferredBy: $('#ReferredBy').val(),
        Balance: $('#Balance').val(),
        CurrentBalance: $('#CurrentBalance').val(),
        Status: $('input[name=Status]:checked').val()
    };
    $.ajax({
        url: "/BusinessEntities/Create",
        data: JSON.stringify(data),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            datatable.ajax.reload();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Edit(id) {
    ClearData();
    $.ajax({
        url: "/BusinessEntities/Details/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#BusinessId').val(data["BusinessId"]);
            $('#Code').val(data["Code"]);
            $('#Email').val(data["Email"]);
            $('#Name').val(data["Name"]);
            $('#Street').val(data["Street"]);
            $('#City').val(data["City"]);
            $('#State').val(data["State"]);
            $('#Zip').val(data["Zip"]);
            $('#Country').val(data["Country"]);
            $('#Mobile').val(data["Mobile"]);
            $('#Phone').val(data["Phone"]);
            $('#ContactPerson').val(data["ContactPerson"]);
            $('#ReferredBy').val(data["ReferredBy"]);
            $('#Balance').val(data["Balance"]);
            $('#CurrentBalance').val(data["CurrentBalance"]);

            $("input[name='Status'][value='" + data["Status"] + "']").prop('checked', true);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Update() {

    var data = {
        BusinessId: $('#BusinessId').val(),
        Code: $('#Code').val(),
        Email: $('#Email').val(),
        Name: $('#Name').val(),
        Street: $('#Street').val(),
        City: $('#City').val(),
        State: $('#State').val(),
        Zip: $('#Zip').val(),
        Country: $('#Country').val(),
        Mobile: $('#Mobile').val(),
        Phone: $('#Phone').val(),
        ContactPerson: $('#ContactPerson').val(),
        ReferredBy: $('#ReferredBy').val(),
        Balance: $('#Balance').val(),
        CurrentBalance: $('#CurrentBalance').val()
    };
    $.ajax({
        url: "/BusinessEntities/Edit",
        data: JSON.stringify(data),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            datatable.ajax.reload();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delele(id) {
    var ans = confirm("Are you sure you want to delete?");
    if (ans) {
        $.ajax({
            url: "/BusinessEntities/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                datatable.ajax.reload();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function ClearData() {
    $('#BusinessId').val('');
    $('#Code').val('');
    $('#Email').val('');
    $('#Name').val('');
    $('#Street').val('');
    $('#City').val('');
    $('#State').val('');
    $('#Zip').val('');
    $('#Country').val('');
    $('#Mobile').val('');
    $('#Phone').val('');
    $('#ContactPerson').val('');
    $('#ReferredBy').val('');
    $('#Balance').val('');
    $('#CurrentBalance').val('');

}
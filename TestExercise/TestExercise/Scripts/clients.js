$("document").ready(function () {
    checkOutClients(1, 5);
});

function printClients(data) {
    var clientsPlaceHolder = $("#clientsContainer").html("");
    if (data.length === 0) {
        clientsPlaceHolder.html("Клиенты не добавлены");
        return;
    }
    var table = $('<table class="table"></table>');
    table.append($("<tr><th>ФИО</th></tr>"));
    data.forEach(function (client) {
        var tr = $("<tr></tr>");
        tr.append("<th>" + client.Fio + "</th>");
        table.append(tr);
    });
    clientsPlaceHolder.append(table);
}

function checkOutClients(pageNumber, clientsPerPage) {
    var requestData = {
        "pageNumber": pageNumber,
        "clientsPerPage": clientsPerPage
    }
    $.ajax({
        url: "/Home/GetClientsJSON",
        dataType: "json",
        success: printClients,
        data: requestData
    });
}
$("document").ready(function () {
    checkOutClients(1, 5);
});

function printClients(data) {
    var clientsPlaceHolder = $("#clientsContainer").html("");
    var clientsViewModel = data.clientsViewModel;
    if (clientsViewModel.length === 0) {
        clientsPlaceHolder.html("Клиенты не добавлены");
        return;
    }
    var table = GenerateTableByData(clientsViewModel);
    clientsPlaceHolder.append(table);

    var pagination = $(".pagination");
    var pageCount = data.pageCount;

}

function GenerateTableByData(data) {
    var table = $('<table class="table table-bordered table-hover"></table>');
    table.append($("<tr><th>ФИО</th><th>Cумма заказов</th></tr>"));
    data.forEach(function (client) {
        var tr = $("<tr></tr>");
        tr.append("<th>" + client.fio + "</th>" + "<th>" + client.orderSum + "</th>");
        table.append(tr);
    });
    return table;
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
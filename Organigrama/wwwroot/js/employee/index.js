$(document).ready(function () {
    Listado();
});

function getList() {
    $.ajax({
        url: Url,
        method: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        data: {
            filter: "j",
            offset: "1",
            limit: "10",
            sortBy: "Id",
            orderBy: "desc"
        }
    })
        .done(function (data) {
            alert("success");
        })
        .fail(function () {
            alert("error");
        })
        .always(function () {
            alert("complete");
        })
}

function Listado() {

    $tableMain.bootstrapTable('destroy');

    $tableMain.bootstrapTable({
        url: UrlBase,
        method: 'GET',
        pagination: true,
        sidePagination: 'server',
        queryParamsType: 'limit',
        pageSize: 5,
        //pageNumber: 2, //indica en que pagina se inicializara
        pageList: [5, 10, 20],
        //smartDisplay: false, mostrar si o si el combo de las paginas
        dataField: 'items',
        totalField: 'count',
        queryParams: function (p) {
            return {
                filter: "",
                offset: p.offset,
                limit: p.limit,
                sortBy: "Id",
                orderBy: "asc"
            };
        },
        responseHandler: function (res) {
            return res;
        }
    });
}

function rowNumFormatter(value, row, index) {
    return 1 + index;
}

function formatterBirthDate(value, row, index) {
    return moment(value).format("DD-MM-yyyy");
}
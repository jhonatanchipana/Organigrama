$(document).ready(function () {
    Autocomplete();
});

function Autocomplete() {
    $("#boos-id-auto").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: UrlBase,
                method: 'GET',
                contentType: "application/json; charset=utf-8",
                dataType: "JSON",
                data: {
                    filter: request.term,
                    limit: "10"
                }
            })
                .done(function (data) {
                    const dataFinal = data.map(x => ({ id: x.value, value: x.text }));
                    response(dataFinal);
                });

        },
        minlength: 2,
        select: function (event, ui) {
            $("#BossId").val(ui.item.id);
        }
    });
}

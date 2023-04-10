$(document).ready(function () {
    Organigrama();
});

function Organigrama() {
    $('#organigrama-chart').orgchart({
        'data': UrlBase,
        'nodeContent': 'workStationNames',
        'nodeTitle': 'names',
        'createNode': function ($node, data) {
            $node.children('.content').after(`<div class="org-name">${data.names} ${data.lastNames}</div>`);
            $node.children('.title').html('<img src="/img/avatar-hombre.png" widht="100%" height="100%">')
        }
    });
}
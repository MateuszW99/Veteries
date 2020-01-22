var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/patient",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "wdith": "40%" },
            { "data": "species", "width": "40%" },
            { "data": "age", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/species/upsert?id=${data}" class="btn btn-success text-white> style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit></i> Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=Delete('api/patients/+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>`;
                }, "width": "30%"
            }],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%"
    });
};
var dataTable;

$(document).ready(function () {
    loadList();
}); 

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/species",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <a href="/Admin/species/upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=Delete('/api/category/'+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%"
    });
}
var dataTable;

$(document).ready(function () {
    loadList();
}); 

function loadList() {
    dataTable = $('#DT_users').DataTable({
        "ajax": {
            "url": "/api/user",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fullName", "width": "25%" },
            { "data": "email", "width": "25%" },
            { "data": "phoneNumber", "width": "25%" },
            {
                "data": {id: "id", lockoutEnd: "lockoutEnd"},
                "render": function (data) {
                    var today = new Date;
                    today = today.getDate();
                    var lockout = new Date(data.lockoutEnd);
                    lockout = lockout.getDate();
                    if (lockout > today) {
                        // user is locked
                        return `<div class="text-center">
                                    <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=LockUnlock('${data.id}')>
                                        <i class="fas fa-lock-open"></i> Unlock
                                    </a>
                                </div>`;
                    }
                    else {
                        return `<div class="text-center">
                                    <a class="btn btn-success text-white" style="cursor:pointer; width:100px;" onclick=LockUnlock('${data.id}')>
                                        <i class="fas fa-lock"></i> Lock
                                    </a>
                                </div>`;
                    }
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%"
    });
}

function LockUnlock(id) {
    $.ajax({
        type: 'POST',
        url: 'api/user',
        data: JSON.stringify(id),
        contentType: 'application/json',
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });
}

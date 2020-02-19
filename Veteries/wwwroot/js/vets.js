var dataTable;

function Delete(_id) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You won't be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'GET',
                url: '?id='+_id+'&handler=Delete',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        location.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

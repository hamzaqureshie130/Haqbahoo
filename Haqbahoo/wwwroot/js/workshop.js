function confirmDelete(id) { debugger
    Swal.fire({
        title: 'Are you sure?',
        text: 'You will not be able to recover this item!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/CRM/workshop/Delete`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                body: `id=${id}`
            })
                .then(response => {
                    if (response.ok) {
                        Swal.fire("Deleted!", "The category has been deleted.", "success").then(() => {
                            location.reload(); // Reload the page to reflect changes
                        });
                    } else {
                        Swal.fire("Error!", "Failed to delete category.", "error");
                    }
                })
                .catch(error => {
                    Swal.fire("Error!", "Something went wrong.", "error");
                });
        }
    });
}

// Open Modal with Product ID and Pre-fill Purchase Price
function openPurchaseModal(productId, purchasePrice) {
    $('#productId').val(productId);
    $('#quantity').val(1);
    $('#purchasePrice').val(purchasePrice);

    // Calculate total amount initially
    let total = 1 * parseFloat(purchasePrice || 0);
    $('#totalAmount').val(total.toFixed(2));

    // Show the modal
    $('#purchaseModal').modal('show');
}

// Calculate Total Amount in Real-Time
$('#quantity, #purchasePrice').on('input', function () {
    let quantity = parseFloat($('#quantity').val()) || 0;
    let price = parseFloat($('#purchasePrice').val()) || 0;
    let total = quantity * price;
    $('#totalAmount').val(total.toFixed(2));
});

// Submit Purchase Data with AJAX
function submitPurchase() {
    let productId = $('#productId').val();
    let quantity = parseInt($('#quantity').val());
    let purchasePrice = parseFloat($('#purchasePrice').val());

    if (!quantity || !purchasePrice) {
        alert('Please enter valid values.');
        return;
    }

    $.ajax({
        url: '/Crm/PurchaseItem/Purchase',
        type: 'POST',
        data: {
            productId: productId,
            quantity: quantity,
            purchasePrice: purchasePrice
        },
        success: function (response) {
            alert('Purchase Successful!');
            $('#purchaseModal').modal('hide');
            location.reload();  // Refresh page to reflect changes
        },
        error: function () {
            alert('Error occurred during purchase.');
        }
    });
}
// Open Sale Modal with Product ID and Pre-fill Sale Price
function openSaleModal(productId, salePrice) {
    $('#saleProductId').val(productId);
    $('#saleQuantity').val(1);
    $('#sellingPrice').val(salePrice);

    // Calculate total amount initially
    let total = 1 * parseFloat(salePrice || 0);
    $('#saleTotalAmount').val(total.toFixed(2));

    // Show the modal
    $('#saleModal').modal('show');
}

// Calculate Total Amount in Real-Time for Sale
$('#saleQuantity, #sellingPrice').on('input', function () {
    let quantity = parseFloat($('#saleQuantity').val()) || 0;
    let price = parseFloat($('#sellingPrice').val()) || 0;
    let total = quantity * price;
    $('#saleTotalAmount').val(total.toFixed(2));
});

// Submit Sale Data with AJAX
function submitSale() {
    let productId = $('#saleProductId').val();
    let quantity = parseInt($('#saleQuantity').val());
    let salePrice = parseFloat($('#sellingPrice').val());

    if (!quantity || !salePrice) {
        alert('Please enter valid values.');
        return;
    }

    $.ajax({
        url: '/Crm/SaleItem/Sell',
        type: 'POST',
        data: {
            productId: productId,
            quantity: quantity,
            salePrice: salePrice
        },
        success: function (response) {
            if (response.success) {
                alert('Sale Successful!');
                $('#saleModal').modal('hide');
                location.reload();  // Refresh page to reflect changes
            } else {
                alert(response.message || 'Error during sale.');
            }
        },
        error: function () {
            alert('Error occurred during sale.');
        }
    });
}

function confirmDelete(id) {
    debugger
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
            fetch(`/CRM/product/Delete`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                body: `id=${id}`
            })
                .then(response => {
                    if (response.ok) {
                        Swal.fire("Deleted!", "The product has been deleted.", "success").then(() => {
                            location.reload(); // Reload the page to reflect changes
                        });
                    } else {
                        Swal.fire("Error!", "Failed to delete product.", "error");
                    }
                })
                .catch(error => {
                    Swal.fire("Error!", "Something went wrong.", "error");
                });
        }
    });
}

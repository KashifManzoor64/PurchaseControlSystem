$("#ProductName").change(function () {
    var selectedPrId = $("#ProductName option:selected").val();
    console.log('ProductId_FK -> ' + selectedPrId);

    $.ajax({
        url: '/PurchaseOrder/getProductById',
        type: 'post',
        data: {
            'id': selectedPrId
        },
        success: function (r) {
            console.log(r);
            $('#ProductId_FK').val(r.Id);
            $('#Suffix').val(r.Suffix);
            $('#UnitPrice').val(r.UnitPrice);
            $('#PackSize').val(r.PackSize);
        },
        error: function (r) {
            console.log( r);
        }
    });

});

//Header ajax 

$("#SupplierName").change(function () {
    var selectedName = $("#SupplierName option:selected").val();
    console.log('SupplierName -> ' + selectedName);

    $.ajax({
        url: '/PurchaseOrder/getSupplierByName',
        type: 'post',
        data: {
            'supplier': selectedName
        },
        success: function (r) {
            console.log(r);
            $('#AccountId_FK').val(r.AccountId);
            $('#SupplierAddress').val(r.Address1);
            
        },
        error: function (r) {
            console.log(r);
        }
    });

});
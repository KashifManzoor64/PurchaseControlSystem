

// Calculate Exchange Rate

$(document).on('change', "#transList input.exchangeRate", function (e) {
    var grossVal = $(this).parent().parent().find('td[gross-value]').attr('gross-value');
    grossVal = parseInt(grossVal);
    var exchRate = $(this).val();
    exchRate = parseInt(exchRate);
    var baseAmmount = grossVal * exchRate;
    console.log(grossVal, exchRate, baseAmmount);
    $(this).parent().parent().find('td.baseAmmount').html(baseAmmount);
});


// Add trans
$(document).on('click', ".add-trans", function (e) {
    console.log('adding up row');
    var x = $(this).parents('tr').clone();
    console.log('x', x);
    $(this).parents('tbody').append(x);
    $(this).html("-");
    $(this).removeClass("text-success").addClass("text-danger");
    $(this).removeClass('add-trans').addClass('remove-trans');
    $(this).parents('tr').next().find('input').val('');
    $(this).parents('tr').next().find('select').val(null);
    $(this).attr('terms')
    $(this).parents('tr').next().find('.terms-conditions').attr('terms' , '0');
    $(this).parents('tr').next().find('.terms-conditions').attr('changed' , 'false');
    console.log('Next Sibling',$(this).parents('tr').next());
});


$(document).on('change', "#customFields td input.qty", function (e) {
    var qty = $(this).val();
    qty = parseInt(qty);
    var unitPrice = $(this).parents('tr').find('.unit-price').val();
    unitPrice = parseInt(unitPrice);
    var cur = qty * unitPrice;
    $(this).parents('tr').find('.ammount-cur').val(cur);
});

$(document).on('change', "#customFields td input.exc-rate", function (e) {
    var exVal = $(this).val();
    exVal = parseInt(exVal);
    var ammountCur = $(this).parents('tr').find('.ammount-cur').val();
    ammountCur = parseInt(ammountCur);
    var baseAmmount = exVal * ammountCur ;
    $(this).parents('tr').find('.base-ammount').val(baseAmmount);
});

$(document).on('click',".submit-data",function (e) {
    e.preventDefault();
    var CostCenterId_FK = $('select[name="CostCenterId_FK"]').val();
    var AccountId_FK = $('select[name="AccountId_FK"]').val();
    var DepartmentId_FK = $('select[name="DepartmentId_FK"]').val();
    var Status = $('input[name="Status"]').val();
    var SupplierName = $('select[name="SupplierName"]').val();
    var SupplierAddress = $('select[name="SupplierAddress"]').val();
    var Approver = $('select[name="Approver"]').val();
    var Comments = $('#Comments').val();

    console.log('CostCenterId_FK ', CostCenterId_FK );
    console.log('AccountId_FK ', AccountId_FK );
    console.log('DepartmentId_FK ', DepartmentId_FK );
    console.log('Status ', Status );
    console.log('SupplierName ', SupplierName );
    console.log('SupplierAddress ', SupplierAddress );
    console.log('Approver ', Approver );
    console.log('Comments ', Comments );

    var transData = [];
    $("#customFields tbody tr").each(function (x) {
        var d = {
            'ProductId_FK': $(this).find('select[name="ProductName"]').val(),
            'unitPrice': $(this).find('input[name="UnitPrice"]').val(),
            'ExchangeRate': $(this).find('.exc-rate').val(),
            'TermsCode': $(this).find('.app-btn-group .terms-conditions').attr('terms'),
            'Quantity': $(this).find('input[name="Quantity"]').val()
        }
        transData.push(d);
    });

    console.log('transData', transData);

    $.ajax({
        url: '/PurchaseOrder/createPOAjax',
        type: 'post',
        data: {
            'CostCenterId_FK': CostCenterId_FK,
            'AccountId_FK': AccountId_FK,
            'DepartmentId_FK': DepartmentId_FK,
            'Status': Status,
            'SupplierName': SupplierName,
            'SupplierAddress': SupplierAddress,
            'Approver': Approver,
            'Comments': Comments,
            'transData': JSON.stringify(transData),
        },
        success: function (r) {
            console.log('post reply back',r);
           
        },
        error: function (r) {
            console.log(r);
        }
    });
});


$(document).on('click',".terms-conditions",function (e) {
    e.preventDefault();
    var productId = $(this).parents('tr').find('select[name="ProductName"]').val();
    console.log('productId', productId)
    $(this).attr('terms-conditions-selected-product', productId);
    var changed = $(this).attr('changed');
    var customTerms = $(this).attr('terms');
    $.ajax({
        url: '/PurchaseOrder/getTemsConditions',
        type: 'post',
        data: {
            'productId': productId,
            
        },
        success: function (r) {
            console.log('post reply back', r);
            $("#select-terms").modal();
            var conds = r.conditionids.TermsCode;
            if (changed == "true") {
                var conds = customTerms;
            }
            console.log('conds', conds);
            conds = conds.split(",");
            
            var html = `
                <div class="row check-box-list">
                    <div class="col-12">
                        <ul>`;
            for (var i = 0; i < r.terms.length; i++) {
                var checked = '';
                if (conds.includes(r.terms[i].TermsCode.toString())) {
                    checked = 'checked="checked"';
                }
                html += `<li>
                            <input type="checkbox" `+ checked + ` value="` + r.terms[i].TermsCode +`"  />
                            <span>`+ r.terms[i].Description +`</span>
                         </li>`;
            }
                           
            html +=`        </ul>
                    </div>
                </div>
            `;

            $("button[save-product-terms]").attr("save-product-terms", productId);
            $("#select-terms").find(".modal-body").html(html);
           
        },
        error: function (r) {
            console.log(r);
        }
    });
});

$(document).on('change', '#select-terms .modal-body .check-box-list li input[type="checkbox"]', function (e) {
    console.log('changed');
    var productId = $('button[save-product-terms]').attr('save-product-terms');
    console.log('productId', productId);
    $('*[terms-conditions-selected-product="' + productId + '"]').attr('changed', 'true');
});

$(document).on('click', "button[save-product-terms]", function (e) {
    var val = [];
    $("#select-terms .modal-body .check-box-list li").each(function () {
        var s = $(this).find('input[type="checkbox"]').val();
        var x = $(this).find('input[type="checkbox"]').prop('checked');
        if (x) {
            val.push(s);
        }
       
    });
    var productId = $(this).attr('save-product-terms');
    console.log("data-holder productId", productId);
    $('*[terms-conditions-selected-product="' + productId + '"]').attr('terms', val.join(","));
    $('*[terms-conditions-selected-product="' + productId + '"]').removeAttr('terms-conditions-selected-produc');
    $("#select-terms").modal('hide');
});

//function loadOrderData() {
//    console.log(' Load Order Data Funtion is Called');
//    var OrderNo = $('#OrderNo').val();

//    $.ajax({
//        url: '/Approve/getOrderlinesByOrderNo',
//        type: 'post',
//        data: {
//            'orderNo': OrderNo
//        },
//        success: function (r) {
//            console.log('reply -> ' + r);
//            $('#ProductId_FK').val(r.ProductId_FK);
//            $('#Suffix').val(r.Suffix);
//            $('#UnitPrice').val(r.UnitPrice);
//            $('#PackSize').val(r.PackSize);
//        },
//        error: function (r) {
//            console.log(r);
//        }
//    });


//}
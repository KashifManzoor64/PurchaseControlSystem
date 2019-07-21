// $(document).ready(function() {
//     $('.name-valid').on('keypress', function(e) {
//         var regex = new RegExp("^[a-zA-Z ]*$");
//         var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
//         if (regex.test(str)) {
//             return true;
//         }
//         e.preventDefault();
//         return false;
//     });
// });

/*** Dynamically add/remove table row using jquery***/

/*Add row event*/
$(document).on('click', '.rowfy-addrow', function(){
     rowfyable = $(this).closest('table');
     lastRow = $('tbody tr:last', rowfyable).clone();
    $('input', lastRow).val('');
    $('tbody', rowfyable).append(lastRow);
    $(this).removeClass('rowfy-addrow text-success').addClass('rowfy-deleterow text-danger').text('-');
});

/*Delete row event*/
$(document).on('click', '.rowfy-deleterow', function(){
    $(this).closest('tr').remove();
});

/*Initialize all rowfy tables*/
$('.rowfy').each(function(){
    $('tbody', this).find('tr').each(function(){
        $(this).append('<td class="p-0 text-center pt-1 px-2 '
            + ($(this).is(":last-child") ?
                'rowfy-addrow text-success border-left-0" style="font-size:40px;cursor: pointer">+' :
                'rowfy-deleterow text-danger border-left-0" style="font-size:40px;cursor: pointer">-')
            +'</td>');
    });
});

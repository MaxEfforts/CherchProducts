// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});
showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            debugger;
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}
jQueryAjaxPost = (form,AddId,tableId) => {
    try {
        debugger;
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    debugger;
                    $("#" + AddId).hide();
                    $('#' + tableId).html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $(form)[0].reset();
                    $('#custom-file-label').val('Select a file');
                    $('#ImageUpload').attr('src', '/images/download.png');
                    $('#form-modal').modal('hide');
                    $.notify('تمت العملية بنجاح', { globalPosition: 'top center', className: 'success' });
                    toastr.success("تمت العملية بنجاح");
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                $.notify('حدث خطا', { globalPosition: 'top center', className: 'error' });
                toastr.error("جدث خطأ");
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}
////////////////
jQueryAjaxDelete = form => {
   
    if (confirm('Are you sure to delete this record ?')) {
        try {
            debugger;
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    debugger;
                    $('#view-all').html(res.html);
                   
                    $.notify('تم الحذف بنجاح', { globalPosition: 'top center', className: 'success' });
                    toastr.success("تم الحذف بنجاح");
                  
                },
                error: function (err) {
                    $.notify('حدث خطا', { globalPosition: 'top center', className: 'error' });
                    toastr.error("جدث خطأ");
                }
            })
        } catch (ex) {
            console.log(ex)
        }
   }

    //prevent default form submit event
    return false;
}

// Add the following code if you want the name of the file appear on select
function FileOnChange(evt, ImageId) {
    var fileName = $(evt).val().split("\\").pop();
    $(evt).siblings(".custom-file-label").addClass("selected").html(fileName);
    var tgt = evt.target || window.event.srcElement,
        files = tgt.files;
    var element = $(this);
    if (FileReader && files && files.length) {
        var fr = new FileReader();
        fr.onload = function () {
            $("#" + ImageId).attr("src", fr.result)
        }
        fr.readAsDataURL(files[0]);
    }
    else {
    }
}


function OpenToAdd(OpendivId) {

    $("#"+OpendivId).fadeIn(2000);
};
$(document).ready(function () {
    $("#AddNew").hide();
});
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
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
           
        }
    })
}

jQueryAjaxPost = form => {
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
                 
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
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
        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });
        $('[type="file"]').change(function (evt) {
            var tgt = evt.target || window.event.srcElement,
                files = tgt.files;
            var element = $(this);
            if (FileReader && files && files.length) {
                var fr = new FileReader();
                fr.onload = function () {
                    $("#ImageUpload").attr("src", fr.result)
                }
                fr.readAsDataURL(files[0]);
            }
            else {
            }
        });

$.Delete = function (url, recId) {
    var obj = new Object();
    obj.id = recId;
    $.ajax({
        url: url,
        data: "{'id':" + recId + "}",//JSON.stringify(obj),
        method: 'POST',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result.Status === 'error')
                $.ShowError("Hata", result.Message, "Tamam")
            else {
                //silme işlemi başarılı
                //tablodan da ilgili satırı kaldıralım.
                $(".row-" + recId).hide(1000, function () {
                    $(this).remove();
                });
                $.ShowSuccess("Sunucunun Mesajı", result.Message, "Tamam")
            }
        }
    });

};

$.InitDataTable = function (tableId) {
    $('#' + tableId).dataTable({
        "language": {
            "emptyTable": "Gösterilecek ver yok.",
            "processing": "Veriler yükleniyor",
            "sDecimal": ".",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

};

$.ShowInfo = function (title, content, butonText, func) {

    $.confirm({
        title: title,
        content: content,
        type: 'blue',
        typeAnimated: true,
        useBootstrap: false,
        boxWidth: '60%',
        buttons: {
            tryAgain: {
                text: butonText,
                btnClass: 'btn btn-primary',
                action: func
            }
        }
    });

};

$.ShowError = function (title, content, butonText, func) {

    $.confirm({
        title: title,
        content: content,
        type: 'red',
        typeAnimated: true,
        useBootstrap: false,
        boxWidth: '60%',
        buttons: {
            error: {
                text: butonText,
                btnClass: 'btn btn-danger',
                action: func
            }
        }
    });

};

$.ShowSuccess = function (title, content, butonText, func) {

    $.confirm({
        title: title,
        content: content,
        type: 'green',
        typeAnimated: true,
        useBootstrap: false,
        boxWidth: '60%',
        buttons: {
            error: {
                text: butonText,
                btnClass: 'btn btn-success',
                action: func
            }
        }
    });

};

$.ShowConfirm = function (title, content, okButonText, okFunc,
    cancelButtonText, cancelFunc) {

    $.confirm({
        title: title,
        content: content,
        type: 'orange',
        typeAnimated: true,
        useBootstrap: false,
        boxWidth: '60%',
        buttons: {
            ok: {
                text: okButonText,
                btnClass: 'btn btn-danger',
                action: okFunc
            },
            cancel: {
                text: cancelButtonText,
                btnClass: 'btn btn-success',
                action: cancelFunc
            }
        }
    });

};

$.Ck = function (inputName) {

    $().ready(function () {
        var editor = CKEDITOR.instances[inputName];
        if (editor) { editor.destroy(true); }
        CKEDITOR.replace(inputName, {
            enterMode: CKEDITOR.ENTER_BR
        });
        CKFinder.setupCKEditor(null, '/Areas/Admin/Content/plugins/ckfinder/');
    });

};

$.DropDown = function (className) {
    $('.' + className).select2();
};

$.FileUpload = function () {

    $().ready(function () {
        //kullanıcı kendi bilgisayarından bir resim seçiyor.
        $(".custom-file-input").on("change", function () {
            //console.log($(this));
            var file = $(this).get(0).files[0];
            var fileName = file.name;
            //console.log($(this).after());
            //$(this).$(this).closest(".custom-file-label")(".custom-file-label").addClass("selected").html(fileName);
            $(this).next().addClass("selected").html(fileName);

        });

    });
};

$.ImageUpload = function (aspectRatio = NaN) {

    $().ready(function () {

        var cropperCreated = false;
        var cropper;
        var ratio;

        //kullanıcı kendi bilgisayarından bir resim seçiyor.
        $(".custom-file-input").on("change", function () {
            //console.log($(this));
            var file = $(this).get(0).files[0];
            var fileName = file.name;
            //console.log($(this).after());
            //$(this).$(this).closest(".custom-file-label")(".custom-file-label").addClass("selected").html(fileName);
            $(this).next().addClass("selected").html(fileName);
            //seçilen resmin modal içerisinde yer alan cropPreview isimli
            //img etiketine yüklenmesi

            var reader = new FileReader();
            //okumayı başlat
            reader.readAsDataURL(file);
            //okuma işlemi tamamlandığında aşağıdaki fonksiyon tetiklenecek
            reader.onload = function (e) {
                $("#crop-preview").attr('src', e.target.result);
            };
        });

        //resim kırpma ekranını hazırlayalım.
        $("#open-crop-screen").click(function () {
            $image = $("#crop-preview");

            //eğer cropper daha önce hazırlandıysa eskisini yok et
            if (cropperCreated) {
                $image.cropper('destroy');
                cropperCreated = false;
            }

            var imageWidth = $image.get(0).width;
            var imageHeight = $image.get(0).height;
            var browserWidth = $(window).width();
            var browserHeight = $(window).height();

            ratio = imageWidth / (browserWidth / 2); //genişliği ve yüksekliği hangi oranda küçültmeliyim
            var newWidth = imageWidth / ratio;
            var newHeight = imageHeight / ratio;

            $(".modal-body").css('padding', '10px');
            $(".modal-dialog").css('max-width', newWidth + 20);

            //cropper'ı resme uygula
            $image.cropper({
                scalable: false,
                zoomable: false,
                aspectRatio: aspectRatio,
                //kırpma alanında resmi hangi boyutlarda istiyorum
                minContainerWidth: newWidth,
                minContainerHeight: newHeight
            });
            cropper = $image.data('cropper');
            cropperCreated = true;

            //modal kontrolünü aç
            $("#crop-modal").modal('show');

            $("#crop-modal").dialog("option", { height: 'auto', width: 'auto' });

        });

        //Kırpma alanına ait bilgileri form içerisinde yer alan hidden inputlara
        //ekleyelim.
        $("#crop-complate").click(function () {
            var cropArea = cropper.getCropBoxData();
            $("#left").val(cropArea.left);
            $("#top").val(cropArea.top);
            $("#width").val(cropArea.width);
            $("#height").val(cropArea.height);
            $("#ratio").val(ratio);
            //modal kapatılıyor
            $("#crop-modal").modal('hide');
        });

    });
};

$.TelNoMask = function (id) {
    $().ready(function () {
        $("#" + id).inputmask("(999) 999 99 99");
    });
};

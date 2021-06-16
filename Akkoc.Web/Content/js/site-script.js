
$.MenuClicked = function () {
    $().ready(function () {
        $(".topnav>li a").click(function () {
            sessionStorage.setItem('menuId', $(this).data("id"));
        });
        if (sessionStorage.getItem('menuId').length!==0) {
            var clickedMenuId = sessionStorage.getItem('menuId');
            $("a[data-id='" + clickedMenuId + "']").parent().addClass("active");
        }
        else {
            sessionStorage.setItem('menuId',1);
            $("a[data-id='1']").parent().addClass("active");
        }

    });
};


$().ready(function () {

    //$("#send").click(function () {
    //    var jsonData = new Object();
    //    jsonData.Name = $("#Name").val();
    //    jsonData.Subject = $("#Subject").val();
    //    jsonData.Content = $("#Content").val();
    //    jsonData.Email = $("#Email").val();
    //    $.ajax({
    //        url: '/Contact/SendMessage',
    //        data: JSON.stringify(jsonData),
    //        type: 'POST',
    //        contentType: 'application/json;charset=utf-8',
    //        dataType: 'json',
    //        success: function (result) {
    //            //hata var
    //            if (result.Status === "error") {
    //                $("#errormessage").html(result.Message);
    //                $("#errormessage").show(300);
    //            }
    //        }
    //    });
    //});

    $("#send").click(function () {        
        var formData = $("#contact-form").serialize();
        $.ajax({
            url: '/Contact/SendMessage',
            data: formData,
            type:'POST',
            contentType: 'application/x-www-form-urlencoded',
            dataType: 'json',
            success: function (result) {
                //hata var
                if (result.Status === "error") {
                    $("#errormessage").html(result.Message);
                    $("#errormessage").show(600);
                }
                else {
                    $("#sendmessage").html(result.Message);
                    $("#sendmessage").show(600);
                    $("#contact-form").remove();
                }
            }
        });
    });
});

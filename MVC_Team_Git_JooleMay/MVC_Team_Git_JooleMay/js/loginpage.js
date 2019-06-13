$(document).ready(function () {


    $("#userImage").change(function () {


        var File = this.files;

        if (File && File[0]) {
            ReadImage(File[0]);
        }

    });

    var ReadImage = function (file) {

        var reader = new FileReader;
        var image = new Image;

        reader.readAsDataURL(file);
        reader.onload = function (_file) {

            image.src = _file.target.result;
            image.onload = function () {



                $("#targetImg").attr('src', _file.target.result);
                $("#imgPreview").show();
            };

        };
    };


    var ClearPreview = function () {

        $("#userImage").val('');
        $("#imgPreview").hide();
    };

    //var UploadImage = function () {

    //    var file = $("#userImage").get(0).files;

    //    var data = new FormData;
    //    data.append("ImageFile", file[0]);
    //    data.append("ProductName", "SamsungA8");

    //    $.ajax({
    //        type: "Post",
    //        url: "/loginpage/dologin",
    //        data: data,
    //        contentType: false,
    //        processData: false,
    //        success: function (response) {



    //        }


    //    });
    //};


    //$("#btnSubmit").click(function () {


    //    var UserName = $("#UserName").val();
    //    var Email = $("#Email").val();
    //    var Password = $("#Password").val();
    //    var ConfirmPassword = $("#ConfirmPassword").val();

    //    //if (!$("#myForm").val()) {

    //    //    return false;
    //    //}

    //    if (UserName === "" || UserName === undefined) {
    //        alert("Please enter UserName");
    //        return false;
    //    }

    //    if (Email === "" || Email === undefined) {
    //        alert("Please enter email");
    //        return false;
    //    }

    //    if (Password === "" || Password === undefined) {
    //        alert("Please enter password");
    //        return false;
    //    }

    //    if (ConfirmPassword === "" || ConfirmPassword === undefined) {
    //        alert("Please enter Confirm password");
    //        return false;
    //    }








    //    var file = $("#userImage").get(0).files;

    //    var myformdata = $("#myForm").serialize();


    //    //myformdata.append
    //    //myformdata.append("ImageFile", file[0]);

    //    $.ajax({
    //        type: "Post",
    //        url: "/loginpage/dologin",
    //        data: myformdata,
    //        //contentType: false,
    //        //processData: false,
    //        success: function (response) {

    //            if (response === "fail") {
    //                window.location.href = "/LoginPage/Dologin";
    //            }

    //            else if (response === "Admin") {
    //                window.location.href = "/LoginPage/Dologin";
    //            }

    //            else {
    //                window.location.href = "/LoginPage/Dologin";
    //            }
    //        }

    //    });
    //});

});
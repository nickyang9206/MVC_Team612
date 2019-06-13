$(document).ready(function () {
    $("#myBtn").click(function () {

        console.log("hi");
        $("#UserName").val("");
        $("#Email").val("");
        $("#Password").val("");
        $("#ConfirmPassword").val("");
        $("#lblMsg").text("");

    });

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
});
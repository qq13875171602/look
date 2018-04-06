$(function () {
    $("#Request").click(function () {
        $("#name").val("");
        $("#password").val("");
        $("#name").focus();
    });

    $("#Iok").click(function () {
        Dialog.tishidialog("请稍后", "正在加载中");
        $.post("/user/Index", { "user.Uname": $("#name").val(), "user.Password": $("#password").val() }, function (data) {
            Dialog.hidetishidialog();
            if (data.Souse = true)
            {
                Dialog.dialog(data.Message, "用户登录", function () {
                    location.href = "/houtai/Index";
                });
                return;
            }
            Dialog.dialog(data.Message, "用户登录", function () {
                return;
            });
        },"json");
    });
});
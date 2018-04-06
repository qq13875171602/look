$(function () {
   
    $("#tianjia").click(function () {
        Dialog.tishidialog("请稍后", "正在添加");
        $.post("/BookType/Index", { "Type.Type": $("#Type").val() }, function (data) {
            Dialog.hidetishidialog();
            if (data.Souse)
            {
                Dialog.dialog("添加成功", "图书管理", function () {
                    return;
                });
                $("#Type").val("");
            }
            Dialog.dialog(data.Message, "图书管理", function () { return;});
        },"json");
    });

    query();

    function query() {
        $("#Type").html("");
        Dialog.tishidialog("正在加载中");
        $.post("/BookType/Query", {}, function (data) {
            Dialog.hidetishidialog();
            if (!data.Souse)
            {
                Dialog.dialog(data.Message, "图书管理", function () { return;});
            }
            $.each(data.TypeList, function (i, v) {
                var tr = $(document.createElement("tr"));
                var td = $(document.createElement("td"));
                td.append(v.tid);
                tr.append(td);

                var td = $(document.createElement("td"));
                td.append(v.type);
                tr.append(td);

                var td = $(document.createElement("td"));
                td.append(v.datatime);
                tr.append(td);

                $("#Type").append(tr);
            });

        }, "json");

    }
});
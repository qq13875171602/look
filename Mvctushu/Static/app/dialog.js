$(function () {
    var dialogg = {};

    var Iok;
    function dialog(info, title, ok) {
        Iok = ok;
        $("#title").html(title);
        $("#info").html(info);
        $("#dialog").modal("show");
    }
    function hidedialog() {
        $("#dialog").modal("hide");
    }

    var ok;
    var nok;
    function modaldialog(info, title, ok, nok) {
        ok = ok;
        nok = nok;
        $("#modaltitle").html(title);
        $("#modalinfo").html(info);
        $("#modaldialog").modal("show");
    }
    function hidemodaldialog() {
        $("#modaldialog").modal("hide");
    }

    function tishidialog(info, title) {
        $("#tishititle").html(title);
        $("#tishiinfo").html(info);
        $("#tishidialog").modal("show");
    }
    function hidetishidialog() {
        $("#tishidialog").modal("hide");
    }

    var ol;
    var lp;
    function diaoyongdialog(info, title) {
        ol = info;
        lp = info.parent();
        $("#diaoyonginfo").append(info);
        info.show();
        $("#diaoyongtitle").html(title);
        $("#diaoyongdialog").modal("show");
    }
    function hidediaoyongdialog() {
        $("#diaoyongdialog").modal("hide");
        lp.append(ol);
        ol.hide();
    }


    $(function () {
        $("#ok").click(function () {
            $("#dialog").modal("hide");
            if (Iok) {
                Iok();
            }
        });
        $("#Imok").click(function () {
            $("#modaldialog").modal("hide");
            if (ok) {
                ok();
            }
        });
        $("#Requeset").click(function () {
            $("#modaldialog").modal("hide");
            if (nok) {
                nok();
            }
        });
    });


    dialogg.dialog = dialog;
    dialogg.hidedialog = hidedialog;
    dialogg.modaldialog = modaldialog;
    dialogg.hidemodaldialog = hidemodaldialog;
    dialogg.tishidialog = tishidialog;
    dialogg.hidetishidialog = hidetishidialog;
    dialogg.diaoyongdialog = diaoyongdialog;
    dialogg.hidediaoyongdialog = hidediaoyongdialog;
    window.Dialog = dialogg;
});
$(document).ready(function () {
    $(".js-fade").fadeIn(2000);
    $(".box").fadeIn(3000);
    $("button").click(function () {
        $.get("~/views/admin/notmentored.cshtml", function () {
            alert("Success");
            //$(".js-load").append(data);
        })

    });

});

//$("button").click(function () {
//    $(".js-load").load("admin/notmentored.cshtml", function (responseTxt, statusTxt, xhr) {
//        if (statusTxt === "success")
//            alert("External content loaded successfully!");
//        if (statusTxt === "error")
//            alert("Error: " + xhr.status + ": " + xhr.statusText);
//    });
//}); 
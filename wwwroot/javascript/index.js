$(document).ready(function () {
    var form = $(".theForm");
    //form.hide("slow");

    $(".productProp").eq(1).children().on("click", function () {
        console.log("u clicked on:" + $(this).text());
    });

    var $login = $("#loginToggle");
    var $popup = $(".popupForm");
    $login.on("click", function () {
        $popup.slideToggle(500);
    });


});
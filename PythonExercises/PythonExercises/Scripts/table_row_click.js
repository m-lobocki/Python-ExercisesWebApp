$(".table > tbody > tr").click(function () {
    window.location = $(this).data("url");
});
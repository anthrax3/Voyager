$(".changeArticleStatusLink").bind("click", function (event) {
    var imgChild = $(this).find("img");
    var statusPublished = imgChild.hasClass("published-true") ? true : false;

    if (statusPublished)
    {
        imgChild.removeClass("published-true");
        imgChild.addClass("published-false");
    }
    else
    {
        imgChild.removeClass("published-false");
        imgChild.addClass("published-true");
    }

    $.ajax({
        type: "POST", // or GET
        url: "/AdminArticles/ChangePublishedArticleState",
        data: "alias=test",
        success: function(data) {
            
        },
        error: function() {
            alert("AJAX error");
        }
    });

    event.preventDefault();
});
$(document).ready(new function () {
    $(".changeArticleStatusLink").bind("click", function (event) {
        var alias = $(this).attr("data-alias");
        var currentPublished = $(this).attr("data-published").toLowerCase() == "true";
        var imgChild = $(this).find("img");

        changeArticleState($(this), imgChild, !currentPublished);

        $.ajax({
            type: "POST",
            url: "/AdminArticles/ChangePublishedArticleState",
            data: "alias=" + alias + "&published=" + (!currentPublished),
            success: function (data) {
                if (JSON.parse(data).result != "Success")
                {
                    changeArticleState($(this), imgChild, currentPublished);
                    alert(data);
                }
            },
            error: function () {
                changeArticleState($(this), imgChild, currentPublished);
                alert("AJAX error");
            }
        });

        event.preventDefault();
    });

    function changeArticleState(link, img, published)
    {
        if (!published) {
            img.removeClass("published-true");
            img.addClass("published-false");
            link.attr("data-published", "False");
        }
        else {
            img.removeClass("published-false");
            img.addClass("published-true");
            link.attr("data-published", "True");
        }
    }
});
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

    $(".trash-button-action").bind("click", function (event) {
        var selectedElement = $(this);
        var alias = selectedElement.attr("data-alias");
        hideArticle(selectedElement);

        $.ajax({
            type: "POST",
            url: "/AdminArticles/RemoveArticle",
            data: "alias=" + alias,
            success: function (data) {
                if (JSON.parse(data).result != "Success") {
                    removeArticle(selectedElement);
                    alert(data);
                }
            },
            error: function () {
                showArticle(selectedElement);
                alert("AJAX error");
            }
        });

        event.preventDefault();
    });

    function changeArticleState(href, img, published)
    {
        if (!published) {
            img.removeClass("published-true");
            img.addClass("published-false");
            href.attr("data-published", "False");
        }
        else {
            img.removeClass("published-false");
            img.addClass("published-true");
            href.attr("data-published", "True");
        }
    }

    function removeArticle(href) {
        var parent = href.closest("tr");
        parent.remove();
    }

    function hideArticle(href)
    {
        var parent = href.closest("tr");
        parent.hide();
    }

    function showArticle(href)
    {
        var parent = href.closest("tr");
        parent.show();
    }
});
$(document).ready(new function () {
    $(".changeArticleStatusLink").bind("click", function (event) {
        var selectedElement = $(this);
        var alias = selectedElement.attr("data-alias");
        var currentPublished = selectedElement.attr("data-published").toLowerCase() == "true";
        var imgChild = selectedElement.find("img");

        changeArticleState(selectedElement, imgChild, !currentPublished);

        $.ajax({
            type: "POST",
            url: "/AdminArticles/ChangePublishedArticleState",
            data: "alias=" + alias + "&published=" + (!currentPublished),
            success: function (data) {
                if (JSON.parse(data).result != "Success")
                {
                    changeArticleState(selectedElement, imgChild, currentPublished);
                    alert(data);
                }
            },
            error: function () {
                changeArticleState(selectedElement, imgChild, currentPublished);
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
                    alert(data);
                }

                removeArticle(selectedElement);
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
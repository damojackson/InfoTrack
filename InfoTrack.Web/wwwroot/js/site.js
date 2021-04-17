// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// This is a basic ajax function which is simpler than using a framework like Angular or React to acomplish this.

$("#searchForm").submit(function (event) {
    // Stop form from submitting normally
    event.preventDefault();
    var searchEngine = $("#searchEngine");
    var searchCount = $("#searchCount");
    var results = $("#results");
    var error = $("#errorMessage");

    // Get some values from elements on the page:
    var $form = $(this),
        searchUrl = $form.find("input[name='searchUrl']").val(),
        searchText = $form.find("input[name='searchText']").val(),
        url = $form.attr("action");

    var requestData = { searchTerm: searchText, searchEngineURL: searchUrl };
    error.collapse('hide');
    results.collapse('hide');

    performSearch(requestData, url, searchEngine, searchCount, results, error);
});

function showError(error, errorMessage) {
    error.text(errorMessage);
    error.collapse('show');
}

function performSearch(requestData, url, searchEngine, searchCount, results, error) {
    // Send the data using post.
    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(requestData),
        dataType: "json",
    }).done(function (data) {
        if (data.error) {
            showError(error, data.error);
        }
        else {
            searchEngine.text(data.searchEngine);
            searchCount.text(data.results);
            results.collapse('show');
        }
    }).fail(
        function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status == 400) {
                //error stuff
                showError(error, 'Error: Invalid search parameters.');
            }
            else {
                showError(error, 'Error: Search could not be completed. Please check the search parameters and try again.');
            }
        });
}

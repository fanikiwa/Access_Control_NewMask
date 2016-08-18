$(function () {
    window.onerror = function (message, url, lineNumber) {
        // code to execute on an error
        InitialPageLoadPanel.Hide(); // hide loading panel
    };
})
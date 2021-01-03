// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    if (location.href.indexOf("Movie") !== -1) {
        $(".movie-nav").addClass("active");
    }
    else if (location.href.indexOf("Home/Privacy") !== -1) {
        $(".privacy-nav").addClass("active");
    } else {
        $(".home-nav").addClass("active");
    }
});
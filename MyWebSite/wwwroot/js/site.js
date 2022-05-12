// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$( document ).ready(function() {
    $('.progress').addClass('hover');
    $('.progress-bar').addClass('progress-bar-animated');
    setTimeout(function() {
        $('.progress-bar').removeClass('progress-bar-animated');
    }, 2000);
});
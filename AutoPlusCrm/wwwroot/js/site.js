// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$('.js-data-example-ajax').select2({
    ajax: {
        url: 'https://api.github.com/search/repositories',
        dataType: 'json'
        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
    }
});
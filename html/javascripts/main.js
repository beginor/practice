'use strict';

requirejs.config({
    baseUrl: 'javascripts',
    paths: {
        jquery: 'libs/jquery/2.1.1/jquery-2.1.1',
        bootstrap: 'libs/bootstrap/3.2.0/js/bootstrap',
        app: 'req-app'
    },
    shim: {
        bootstrap: { deps: ['jquery'] }
    }
});

require(['jquery', 'bootstrap'],
    function ($) {
        $(function() {
            $('#carousel-example-generic').carousel();
        });
    }
);
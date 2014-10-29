'use strict';

requirejs.config({
    baseUrl: 'javascripts/libs',
    paths: {
        app: '../app'
    }
});

require(
    ['jquery/2.1.1/jquery-2.1.1', 'app'],
    function(jquery, sub) {

    }
)
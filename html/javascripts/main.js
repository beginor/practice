'use strict';

requirejs.config({
    baseUrl: 'javascripts/libs',
    paths: {
        'jquery': 'jquery/2.1.1/jquery-2.1.1',
        'app': '../req-app'
    }
});

require(
    ['app'],
    function(app) {
        console.log('app loaded in main.js');
        console.log('app version is ' + app.version);
    }
);
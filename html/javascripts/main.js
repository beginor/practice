'use strict';

requirejs.config({
    baseUrl: 'javascripts/libs',
    paths: {
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
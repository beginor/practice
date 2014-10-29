define(
    'app',
    ['jquery'],
    function($) {
        console.log($);
        console.log('app loaded.');
        return {
            version: '0.0.1 beta'
        };
    }
);
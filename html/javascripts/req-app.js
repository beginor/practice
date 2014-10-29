define(
    'app',
    ['jquery/2.1.1/jquery-2.1.1'],
    function() {
        console.log(jQuery);
        console.log('app loaded.');
        return {
            version: '0.0.1 beta'
        };
    }
);
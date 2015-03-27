requirejs.config({
    paths: {
        'angular': 'bower_components/angular/angular',
        'angular-i18n': 'bower_components/angular-i18n/angular-locale_zh-cn',
        'angular-animate': 'bower_components/angular-animate/angular-animate',
        'angular-route': 'bower_components/angular-route/angular-route',
        'angular-resource': 'bower_components/angular-resource/angular-resource',
        'angular-bootstrap': 'bower_components/angular-bootstrap/ui-bootstrap-tpls'
    },
    shim: {
        'angular': { exports: 'angular' },
        'angular-i18n': { deps: ['angular'] },
        'angular-animate': { deps: ['angular'] },
        'angular-route': { deps: ['angular'] },
        'angular-resource': { deps: ['angular'] },
        'angular-bootstrap': { deps: ['angular'] }
    }
});

require(['app'], function() {
    angular.bootstrap(document, ['app']);
})
define([], function () {
    return {
        defaultRoute: 'home',
        routes: {
            '/home': {
                templateUrl: 'components/page-home.html',
                controller: 'homeController',
                dependencies: ['components/page-home']
            },
            '/about': {
                templateUrl: 'components/page-about.html',
                controller: 'aboutController',
                dependencies: ['components/page-about']
            },
            '/contact': {
                templateUrl: 'components/page-contact.html',
                controller: 'contactController',
                dependencies: ['components/page-contact']
            }
        }
    };
});
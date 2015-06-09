var app = angular.module('app', ['ionic', 'ngCordova', 'uiGmapgoogle-maps']);

app.config(function ($stateProvider, $urlRouterProvider, uiGmapGoogleMapApiProvider) {

    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    uiGmapGoogleMapApiProvider.configure({
        key: 'AIzaSyBDtLcCREX7c9SxppygrEjV_FzgudxbWBQ',
        v: '3.17',
        libraries: 'weather,geometry,visualization'
    });

    $stateProvider
    .state('tabs', {
        url: "/tab",
        abstract: true,
        templateUrl: "templates/tabs.html"
    })
    .state('tabs.home', {
        url: "/home",
        views: {
            'home-tab': {
                templateUrl: "templates/home.html",
                controller: 'HomeController'
            }
        }
    })
    .state('tabs.facts', {
        url: "/map",
        views: {
            'home-tab': {
                templateUrl: "templates/map.html"
            }
        }
    })
    .state('tabs.facts2', {
        url: "/camera",
        views: {
            'home-tab': {
                templateUrl: "templates/camera.html"
            }
        }
    })
    .state('tabs.about', {
        url: "/about",
        views: {
            'about-tab': {
                templateUrl: "templates/about.html"
            }
        }
    })
    .state('tabs.contact', {
        url: "/contact",
        views: {
            'contact-tab': {
                templateUrl: "templates/contact.html"
            }
        }
    });


    $urlRouterProvider.otherwise("/tab/home");
});
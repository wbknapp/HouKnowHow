var app = angular.module('app', ['ngRoute', 'ui.bootstrap']);

app.config(function ($routeProvider, $httpProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/app/Views/Home.html',
            title: 'Home Page'
        })
        .when('/MapApp', {
            templateUrl: '/app/Views/MapApp.html',
            title: 'Map App'
        })
        .when('/About', {
            templateUrl: '/app/Views/About.html',
            title: 'About'
        })
        .when('/StoryMap', {
            templateUrl: '/app/Views/StoryMap.html',
            title: 'Map App'
        })

        .when('/ImageMap', {
            templateUrl: '/app/Views/Images.html',
            title: 'Map App'
        })

        .when('/register', {
            templateUrl: '/app/Views/Register.html',
            title: 'Map App'
        })
        .when('/Login', {
            templateUrl: '/app/Views/Login.html',
            title: 'Login'
        })
        .when('/Privacy', {
            templateUrl: '/app/Views/Privacy.html',
            title: 'Privacy'
        }).otherwise({
        redirectTo: '/'
    });
    $httpProvider.interceptors.push('AuthFactory');
});
app.controller('HomeController', function ($scope, LoginFactory) {
    $scope.status = LoginFactory.status;
    $scope.user = {
        username: '', password: ''
    }
    $scope.userInfo = {};
    $scope.login = function () {
        LoginFactory.login($scope.user).then(function () {
            $scope.getUserInfo();
        });
    }
    $scope.logout = LoginFactory.logout;

    $scope.getUserInfo = function () {
        LoginFactory.getInfo().then(function (data) {
            $scope.userInfo = data;
        });
    }
    if ($scope.status.loggedin) $scope.getUserInfo();



    // Angular Carousel
    $scope.myInterval = 5000;
    $scope.slides = [];
    var img = ['../img/houapp_banner.jpg', '../img/houapp_banner3.jpg', '../img/houapp_banner2.jpg'];
    var txt = ['Making Sense of Open Data', 'Making Houstonians More Resilient', 'Putting Houstonians in the Know']
    var title = ['Jon Cordingley', 'Julio Rodriguez', 'Garima Vyas', 'Andrew Bethel', 'Nabil Rhiati', 'Bill Knapp', 'Gina Fantoni', 'Will Hermann'];
    for (var i = 0; i < 3; i++) {
        $scope.slides.push({
            image: img[i],
            text: txt[i],
            title: 'HouKnowHow'
        });
    }
    // End Carousel
})
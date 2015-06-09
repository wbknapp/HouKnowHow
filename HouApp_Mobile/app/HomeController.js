app.controller('HomeController', function ($scope, $rootScope, AppService, $ionicSideMenuDelegate, $cordovaCamera, uiGmapGoogleMapApi) {
    $scope.income = true;
    $scope.flood = false;
    $scope.art = false;
    $scope.safety = false;
    $scope.health = false;
    $scope.food = false;

    $scope.map = {};
    $scope.options = { scrollwheel: false };

    $scope.toggleLeft = function () {
        $ionicSideMenuDelegate.toggleLeft();
    };
    $scope.checkBox = function (string) {
        if (string == 'income') {
            if ($scope.income == false) {
                $scope.income = true;
            }
            else {
                $scope.income = false;
            }
        }
        if (string == 'flood') {
            if ($scope.flood == false) {
                $scope.flood = true;
            }
            else {
                $scope.flood = false;
            }
        }
        if (string == 'art') {
            if ($scope.art == false) {
                $scope.art = true;
                $scope.refresh();
            }
            else {
                $scope.art = false;
                $scope.refresh();
            }
        }
        if (string == 'safety') {
            if ($scope.safety == false) {
                $scope.safety = true;
            }
            else {
                $scope.safety = false;
            }
        }
        if (string == 'health') {
            if ($scope.health == false) {
                $scope.health = true;
            }
            else {
                $scope.health = false;
            }
        }
        if (string == 'food') {
            if ($scope.food == false) {
                $scope.food = true;
            }
            else {
                $scope.food = false;
            }
        }
    }

    $scope.takePicture = function () {
        var options = {
            quality: 75,
            destinationType: Camera.DestinationType.DATA_URL,
            sourceType: Camera.PictureSourceType.CAMERA,
            allowEdit: true,
            encodingType: Camera.EncodingType.JPEG,
            targetWidth: 300,
            targetHeight: 300,
            popoverOptions: CameraPopoverOptions,
            saveToPhotoAlbum: false
        };

        $cordovaCamera.getPicture(options).then(function (imageData) {
            $scope.imgURI = "data:image/jpeg;base64," + imageData;
        }, function (err) {
            // An error occured. Show a message to the user
        });
    }
    $scope.map = {};
    $scope.markers = [];
    $scope.refresh = function () {
        AppService.getCurrentPosition(function (position) {
            $scope.latitude = position.coords.latitude;
            $scope.longitude = position.coords.longitude;
            uiGmapGoogleMapApi.then(function (maps) {
                $scope.marker = {
                    id: 1,
                    coords: {
                        latitude: $scope.latitude,
                        longitude: $scope.longitude
                    },
                    title: 'you',
                    options: { draggable: false },
                };
                $scope.markers = [];
                $scope.markers = [{
                    id: 1,
                    coords: {
                        latitude: 29.75608173592184,
                        longitude: -95.37678884723647
                    },
                    title: 'this',
                    options: { draggable: false },
                    url: "https://02varvara.files.wordpress.com/2012/06/00b-street-art-mexico-city-mx-05-12.jpg"
                }, {
                    id: 2,
                    coords: {
                        latitude: 29.752095180071144,
                        longitude: -95.3820245192372
                    },
                    title: 'that',
                    options: { draggable: false },
                    url: "https://02varvara.files.wordpress.com/2012/06/00a-street-art-naples-it-05-12.jpg?w=1024"
                }, {
                    id: 3,
                    coords: {
                        latitude: 29.747549567797872,
                        longitude: -95.37717508533999
                    },
                    title: 'the',
                    options: { draggable: false },
                    url: "http://media.creativebloq.futurecdn.net/sites/creativebloq.com/files/images/2014/01/yes2.jpg"
                }, {
                    id: 4,
                    coords: {
                        latitude: 29.753026632548856,
                        longitude: -95.37060903767039
                    },
                    title: 'other',
                    options: { draggable: false },
                    url: "http://21onuv2o3diqcdqccz3o9c12iv.wpengine.netdna-cdn.com/wp-content/uploads/2009/04/china_pothole-[gadling-bumper].jpg"
                }];
                $scope.map = { center: { latitude: $scope.latitude, longitude: $scope.longitude }, zoom: 15, bounds: {} };

            });
        });
    };
    $scope.refresh();
    $scope.windowOptions = {
        visible: false
    };
    $scope.title = "http://www.granducahouston.com/i/SITE_110602_11175489_ER1H8/content/CMS_110602_14313378_JL0I0/11045C3C-188B-3B72-2E612F7C67BFB5FF.JPG"

    $scope.onClick = function () {
        $scope.windowOptions.visible = !$scope.windowOptions.visible;
    };

    $scope.closeClick = function () {
        $scope.windowOptions.visible = false;
    };
});
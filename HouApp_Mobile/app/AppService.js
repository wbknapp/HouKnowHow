app.factory('AppService', function ($http, $q, $rootScope) {

    var getPicture = function (options) {
        var q = $q.defer();

        navigator.camera.getPicture(function (result) {
            q.resolve(result);
        }, function (err) {
            q.reject(err);
        }, options);

        return q.promise;
    }

    var getCurrentPosition = function (onSuccess, onError, options) {
        navigator.geolocation.getCurrentPosition(function () {
            var that = this,
              args = arguments;

            if (onSuccess) {
                $rootScope.$apply(function () {
                    onSuccess.apply(that, args);
                });
            }
        }, function () {
            var that = this,
              args = arguments;

            if (onError) {
                $rootScope.$apply(function () {
                    onError.apply(that, args);
                });
            }
        },
        options);
    }

    return {
        getPicture: getPicture,
        getCurrentPosition: getCurrentPosition
    }
});
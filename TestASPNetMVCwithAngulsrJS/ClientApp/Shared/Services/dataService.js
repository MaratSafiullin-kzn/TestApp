(function () {
    angular
        .module('app')
        .factory('dataServices', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getMessages = function () {
                var deferred = $q.defer();
                $http.get('/Message/Get').then(function (result) {
                    deferred.resolve(result.data)
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addMessage = function (message) {
                var deferred = $q.defer();
                $http.post('/Message/Create', message).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.delMessage = function (id) {
                var deferred = $q.defer();
                $http.post('/Message/Delete', { id: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            return service;
        }]);
})();
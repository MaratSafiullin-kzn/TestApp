(function () {
    angular
        .module('app', [
            'ngRoute'
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/', {
                    controller: 'messageCntrl',
                    templateUrl: '/ClientApp/Templates/messages.html'
                })
        }]);
})();
(function () {
    angular.module('app')
        .controller('messageCntrl', ['$scope', 'dataServices', function ($scope, dataServices) {
            $scope.messages = [];

            function getData() {
                dataServices.getMessages().then(function (result) {
                    $scope.messages = result;
                });
            }

            getData();

            $scope.deleteMessage = function (id) {
                dataServices.delMessage(id).then(function () {
                    getData();
                });
            };

            $scope.createMessage = function (message) {
                if (message.Original == '') return;

                dataServices.addMessage(message).then(function () {
                    getData();
                });
            };
        }]);
})();

var serviceManagementApp = angular.module('serviceManagementApp', ['ui.bootstrap']);

serviceManagementApp.controller('RunningServicesCtlr', function ($scope, $http) {

    $http.get("http://tpg-eiu-e6520:9008/manage/json/instances")
        .success(function (data, status, headers, config) {
            console.log(data);
            $scope.services = data;
            $scope.services.forEach(function(element, index, array) {
                if (element.ServiceState === "Running") {
                    element.isRunning = true;
                } else {
                    element.isRunning = false;
                }
            });
        })
        .error(function (data, status, headers, config) {
            console.log(status);
        });
    
    $http.get("http://tpg-eiu-e6520:9008/manage/json/addins")
        .success(function (data, status, headers, config) {
            console.log(data);
            $scope.addins = data;
        })
        .error(function (data, status, headers, config) {
            console.log(status);
        });

    $scope.oneAtATime = true;

    $scope.hasServices = $scope.services === null;
    $scope.hasAddins = $scope.addins === null;
});

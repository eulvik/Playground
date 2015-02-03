var serviceManagementApp = angular.module('serviceManagementApp', ['ui.bootstrap']);

serviceManagementApp.controller('RunningServicesCtlr', function ($scope, $http) {

    $http.get("http://localhost:9008/manage/json/addins")
        .success(function(response) {
         $scope.services = response;
    });
    
    $scope.oneAtATime = true;

    $scope.hasServices = $scope.services === null;
});

function httpGet(theUrl)
{
    var xmlHttp = null;

    xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", theUrl, false );
    xmlHttp.send( null );
    return xmlHttp.responseText;
}
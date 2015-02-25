var serviceManagementApp = angular.module('serviceManagementApp', ['ui.bootstrap']);

serviceManagementApp.controller('RunningServicesCtlr', function ($scope, $http) {
    var baseUri = "http://localhost:9008/manage/web/json/";

    $scope.updateServices = function() {
      var uri = baseUri.concat("instances");
      $http.get(uri)
          .success(function (data, status, headers, config) {
              console.log("Fetched running services.");
              $scope.services = data;
              $scope.numRunningServices = $scope.services.length;
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
              $scope.services = null;
              $scope.numRunningServices = 0;
          });
      }

    $scope.updateAddIns = function() {
      var uri = baseUri.concat("addins");
      $http.get(uri)
          .success(function (data, status, headers, config) {
              console.log("Fetched addins");
              $scope.addins = data;
              $scope.numAvailableAddins = $scope.addins.length;
          })
          .error(function (data, status, headers, config) {
              console.log(status);
              $scope.addins = null;
              $scope.numAvailableAddins = 0;
          });
      }

      $scope.stopService = function(serviceId) {
          var url = baseUri.concat("stop/");
          url = url.concat(serviceId);
          $http.get(url)
              .success(function (data, status, headers, config) {
                  console.log("Stopped service");
                  $scope.updateServices();
              })
              .error(function (data, status, headers, config) {
                  console.log(status);
              });
      }

      $scope.restartService = function(serviceId) {
          var url = baseUri.concat("restart/");
          url = url.concat(serviceId);
          $http.get(url)
              .success(function (data, status, headers, config) {
                  console.log("Restarted service");
                  $scope.updateServices();
              })
              .error(function (data, status, headers, config) {
                  console.log(status);
              });
      }

      $scope.startService = function(addinId) {
          var url = baseUri.concat("start/");
          url = url.concat(addinId);
          $http.get(url)
              .success(function (data, status, headers, config) {
                  console.log("Started service");
                  $scope.updateServices();
              })
              .error(function (data, status, headers, config) {
                  console.log(status);
              });
      }

      $scope.updateData = function() {
        $scope.updateAddIns();
        $scope.updateServices();
      }

      $scope.rescanAddIns = function() {
        var url = baseUri.concat("addins/rescan/true");
        $http.get(url)
            .success(function (data, status, headers, config) {
                console.log("Rescanned addins");
                $scope.updateData();
            })
            .error(function (data, status, headers, config) {
                console.log(status);
            });
      }

      $scope.numRunningServices = 0;
      $scope.numAvailableAddins = 0;
      $scope.updateServices();
      $scope.updateAddIns();
});

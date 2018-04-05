(function() {
  var app = angular.module("controllers");
  app.controller('conpl', ['$log', "$scope", "$location", "datahttp", "$rootScope", "$window", conpl]);

  function conpl($log, $scope, $location, datahttp, $rootScope, $window) {
    $log.debug("conpl");
    $scope.$on("$destroy", function() {
      $log.debug("销毁控制器");
    });

    $scope.data = {};
    $rootScope.name = {};


    $scope.denglu = function() {
      datahttp.data("/denglu/Index", $scope.data, function(err, data) {
        if (err) {
          console.log('登录失败');
          return;
        }
        if (data.Souse) {
          console.log('登录成功');
          $location.path("/yemian");
          $rootScope.name = $scope.data.user;
          $window.localStorage.mylocal = $rootScope.name;
          return;
        }
      });
    };


    $scope.plo = function() {
      $scope.data = {};
    };

  }
})();
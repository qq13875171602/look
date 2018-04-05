(function() {
  var app = angular.module("controllers");
  app.controller('plk', ['$log', "$scope", "datahttp", "$rootScope", "Dataservice", plk]);

  function plk($log, $scope, datahttp, $rootScope, Dataservice) {
    $log.debug("plk");
    $scope.$on("$destroy", function() {
      $log.debug("销毁控制器");
    });

    $scope.op = true;
    $scope.bn = true;
    $scope.like = {};
    $scope.shuju = {};
    $scope.query = {};
    $scope.mohu = {};
    $scope.lick = function() {
      $scope.op = false;
    };
    $scope.ke = function() {
      $scope.op = true;
    };
    $scope.zx = function() {
      $scope.bn = false;
    };
    $scope.cv = function() {
      $scope.bn = true;
    };


    /* ===========    分类添加    ============*/
    $scope.add = function() {
      Dataservice.wadlklog("正在进入中");
      datahttp.data("/houtai/Index", $scope.shuju, function(err, data) {
        Dataservice.hidewardialog();
        if (err) {
          Dataservice.setdialog("服务器忙");
          $log.debug("err",err);
          return;
        }
        if (data.Souse) {
          Dataservice.awstdialog("添加成功",function () {
                Dataservice.hidedialog();
          },function () {
            Dataservice.hidedialog();
          });
          $scope.shuju.Booktype = {};
          $scope.ag();
          return;
        }
      });
    };

    //js ctrl+alt+f
    //css ctrl+alt+[
    //html ctrl+shift+alt+f
    /* ============   分类查询       =============*/
    $scope.ag = function() {
      Dataservice.wadlklog("正在进入中");
      datahttp.data("/houtai/Query", {}, function(err, data) {
        Dataservice.hidewardialog();
        if (err) {
          Dataservice.setdialog('查询失败');
          return;
        }
        if (data.Souse) {
          $scope.pl = data.List;
          $scope.like.book = {
            Tid: $scope.pl[0].tid
          };
          return;
        }
      });
    };
    $scope.ag();

    /*===============    图书添加       ========================*/

    $scope.tianjia = function() {
      Dataservice.wadlklog("正在添加中");
      datahttp.data("/houtai/Add", $scope.like, function(err, data) {
        Dataservice.hidewardialog();
        if (err) {
          Dataservice.setdialog("添加失败",function () {
            Dataservice.hidedialog();
          });
          return;
        }
        if (data.Souse) {
          Dataservice.setdialog("添加成功",function () {
             Dataservice.hidedialog();
          });
          $scope.okl();
          return;
        }
      });
    };



    /*============    图书查询  分页查询    ================*/


    $scope.okl = function() {

      datahttp.data("/houtai/select", {
        "page.PageSize": 2,
        "page.PageNumber": 1
      }, function(err, data) {
        if (err) {
          console.log('查询失败');
          return;
        }
        if (data.Souse) {
          console.log('查询成功');
          $scope.query = data.list;
          $scope.page = data.page;
          return;
        }
      });
    };
    $scope.okl();

    $scope.sd = function(adf) {
      datahttp.data("/houtai/select", {
        "page.PageSize": 2,
        "page.PageNumber": adf
      }, function(err, data) {
        if (err) {
          console.log('查询失败');
          return;
        }
        if (data.Souse) {
          console.log('查询成功');
          $scope.query = data.list;
          $scope.page = data.page;
          return;
        }
      });
    };

    $scope.qw = function(qwe) {
      datahttp.data("/houtai/select", {
        "page.PageSize": 2,
        "page.PageNumber": qwe
      }, function(err, data) {
        if (err) {
          console.log('查询失败');
          return;
        }
        if (data.Souse) {
          console.log('查询成功');
          $scope.query = data.list;
          $scope.page = data.page;
          return;
        }
      });
    };

    $scope.ty = function(asd) {
      datahttp.data("/houtai/select", {
        "page.PageSize": 2,
        "page.PageNumber": asd
      }, function(err, data) {
        if (err) {
          console.log('查询失败');
          return;
        }
        if (data.Souse) {
          console.log('查询成功');
          $scope.query = data.list;
          $scope.page = data.page;
          return;
        }
      });
    };


    /*===========   图书删除     ==================*/
    $scope.delete = function(oplk) {
      datahttp.data("/houtai/delete", {
        "book.bid": oplk
      }, function(err, data) {
        if (err) {
          console.log('删除失败');
          return;
        }
        if (data.Souse) {
          console.log('删除成功');
          $scope.okl();
          return;
        }
      });
    };

    /*===================     ==================*/

  }
})();
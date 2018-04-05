(function () {
  var app=angular.module("services");
  app.factory('datahttp', ['$log',"$http",datahttp]);

  function datahttp($log,$http){
      var url={};
      var data={};

      var service ={};
      service.data=function (url,dataq,cb) {
       $http({
          method:"POST",
          url:"http://localhost:1050/"+url,
          data:dataq
       }).then(function(datas) {
           $log.debug("正确信息", datas.data);
           cb(null,datas.data);
      }, function(datas) {
           $log.debug("错误信息", datas);
           cb(datas,null);
      });
   };   

   var weeks=["星期六","星期一","星期二","星期三","星期四","星期五","星期天"];

   service.time=function (datemj,formart) {
      var data=new Date();
      if(datemj)
      {
        data.setTime(datemj);
      }
      if(!formart)
      {
        formart("y-m-d");
      }

       var year=data.getFullYear();
       var mouth=data.getMonth()+1;
       var day=data.getDate();
       var hous=data.getHours();
       var minus=data.getMinutes();
       var serop=data.getSeconds();
       var week=data.getDay();

       mouth = mouth < 10? "0" + mouth : "" + mouth;
       day = day < 10? "0" + day : "" + day;
       hous = hous < 10? "0" + hous : "" + hous;
       minus = minus < 10? "0" + minus : "" + minus;
       serop = serop < 10? "0" + serop : "" + serop;
       week=weeks[week];

       var reast=formart.replace("y",year);
       reast=reast.replace("m",mouth);
       reast=reast.replace("d",day);
       reast=reast.replace("h",hous);
       reast=reast.replace("i",minus);
       reast=reast.replace("s",serop);
       reast=reast.replace("w",week);
       return reast;
   };


   return service;

  }

})();
(function () {
    var app = angular.module("theMusic", ["ngRoute"]);
    var config = function ($routeProvider) {
            $routeProvider
            .when("/list",
                { templateUrl: "/Assets/Templates/list.html", controller: "MusicListController" })
            .when("/details/:id",
                { templateUrl: "/Assets/Templates/details.html", controller: "DetailsController" })
            .otherwise(
                { redirectTo: "/list", controller: "MusicListController" });
           };

    app.config(config);
    app.constant("musicApiUrl", "/api/musics/");
}());
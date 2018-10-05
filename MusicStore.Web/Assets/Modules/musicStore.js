(function () {
    var app = angular.module("musicStore", ["ngRoute"]);
    var config = function ($routeProvider) {
        $routeProvider
            .when("/genres/list",
                { templateUrl: "/Assets/Templates/Genres/list.html", controller: "genreListController" })
            .when("/genres/details/:id",
                { templateUrl: "/Assets/Templates/Genres/details.html", controller: "genreDetailsController" })
            .when("/artists/list",
                { templateUrl: "/Assets/Templates/Artists/list.html", controller: "artistListController" })
            .when("/artists/details/:id",
                { templateUrl: "/Assets/Templates/Artists/details.html", controller: "artistDetailsController" })
            .when("/albums/list",
                { templateUrl: "/Assets/Templates/Albums/list.html", controller: "albumListController" })
            .when("/albums/details/:id",
                { templateUrl: "/Assets/Templates/Albums/details.html", controller: "albumDetailsController" })
            .otherwise(
                { redirectTo: "/genres/list", controller: "genreListController" });
    };

    app.config(config);
    app.constant("genresApiUrl", "/api/genres/");
    app.constant("albumsApiUrl", "/api/albums/");
    app.constant("artistsApiUrl", "/api/artists/");
}());
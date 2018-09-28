(function (app) {
    var genreListController = function ($scope, genreService) {

        genreService
            .getAll()
            .success(function (data) {
                $scope.genres = data;
            });

        $scope.create = function () {
         $scope.edit = {
                genre: {
                    name: "",
                    description: ""
                }
            };
        };

        $scope.delete = function (genre) {
            genreService.delete(genre.genreId)
                .success(function () {
                    removeGenreById(genre.genreId);
                });
        };

        var removeGenreById = function (id) {
            for (var i = 0; i < $scope.genres.length; i++) {
                if ($scope.genres[i].Id == id) {
                    $scope.genres.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("genreListController", genreListController);
}(angular.module("musicStore")));

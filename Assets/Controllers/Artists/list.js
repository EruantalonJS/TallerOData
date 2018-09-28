(function (app) {
    var artistListController = function ($scope, artistService) {

        artistService
            .getAll()
            .success(function (data) {
                $scope.artists = data;
            });

        $scope.create = function () {
         $scope.edit = {
                artist: {
                    name: "",
                    description: ""
                }
            };
        };

        $scope.delete = function (artist) {
            artistService.delete(artist.artistId)
                .success(function () {
                    removeGenreById(artist.artistId);
                });
        };

        var removeGenreById = function (id) {
            for (var i = 0; i < $scope.artists.length; i++) {
                if ($scope.artists[i].Id == id) {
                    $scope.artists.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("artistListController", artistListController);
}(angular.module("musicStore")));

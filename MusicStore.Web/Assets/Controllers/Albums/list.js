(function (app) {
    var albumListController = function ($scope, albumService) {

        albumService
            .getAll()
            .success(function (data) {
                $scope.albums = data;
            });

        $scope.create = function () {
         $scope.edit = {
                album: {
                    name: "",
                    description: ""
                }
            };
        };

        $scope.delete = function (album) {
            albumService.delete(album.albumId)
                .success(function () {
                    removeGenreById(album.albumId);
                });
        };

        var removeGenreById = function (id) {
            for (var i = 0; i < $scope.albums.length; i++) {
                if ($scope.albums[i].Id == id) {
                    $scope.albums.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("albumListController", albumListController);
}(angular.module("musicStore")));

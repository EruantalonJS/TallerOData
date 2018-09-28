(function(app) {
    var albumEditController = function ($scope, albumService) {

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.album;
        };

        $scope.cancel = function() {
            $scope.edit.album = null;
        };

        $scope.save = function () {
            if ($scope.edit.album.albumId) {
                updateGenre();
            } else {
                createGenre();
            }
        };
        $scope.albums = [];
        var updateGenre = function() {
            albumService.update($scope.edit.album)
                    .then(function () {
                        angular.extend($scope.album, $scope.edit.album);
                        $scope.edit.album = null;
                });
        };

        var createGenre = function () {
            albumService.insert($scope.edit.album)
                .then(function () {
                    $scope.albums.push($scope.edit.album);
                    $scope.edit.album = null;
                });
        };
    };
    app.controller("albumEditController", albumEditController);
}(angular.module("musicStore")));
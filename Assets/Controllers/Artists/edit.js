(function(app) {
    var artistEditController = function ($scope, artistService) {

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.artist;
        };

        $scope.cancel = function() {
            $scope.edit.artist = null;
        };

        $scope.save = function () {
            if ($scope.edit.artist.artistId) {
                updateGenre();
            } else {
                createGenre();
            }
        };
        $scope.artists = [];
        var updateGenre = function() {
            artistService.update($scope.edit.artist)
                    .then(function () {
                        angular.extend($scope.artist, $scope.edit.artist);
                        $scope.edit.artist = null;
                });
        };

        var createGenre = function () {
            artistService.insert($scope.edit.artist)
                .then(function () {
                    $scope.artists.push($scope.edit.artist);
                    $scope.edit.artist = null;
                });
        };
    };
    app.controller("artistEditController", artistEditController);
}(angular.module("musicStore")));
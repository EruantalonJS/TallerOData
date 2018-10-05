(function(app) {
    var genreEditController = function ($scope, genreService) {

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.genre;
        };

        $scope.cancel = function() {
            $scope.edit.genre = null;
        };

        $scope.save = function () {
            if ($scope.edit.genre.genreId) {
                updateGenre();
            } else {
                createGenre();
            }
        };
        $scope.genres = [];
        var updateGenre = function() {
            genreService.update($scope.edit.genre)
                    .then(function () {
                        angular.extend($scope.genre, $scope.edit.genre);
                        $scope.edit.genre = null;
                });
        };

        var createGenre = function () {
            genreService.insert($scope.edit.genre)
                .then(function () {
                    $scope.genres.push($scope.edit.genre);
                    $scope.edit.genre = null;
                });
        };
    };
    app.controller("genreEditController", genreEditController);
}(angular.module("musicStore")));
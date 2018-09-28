(function (app) {
    var genreDetailsController = function ($scope, $routeParams, genreService) {
        var id = $routeParams.id;
        genreService
            .getById(id)
            .success(function(data) {
                $scope.genre = data;
            });

        $scope.edit = function () {
            $scope.edit.genre = angular.copy($scope.genre);
        };


    };
    app.controller("genreDetailsController", genreDetailsController);
}(angular.module("musicStore")));
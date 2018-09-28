(function (app) {
    var artistDetailsController = function ($scope, $routeParams, artistService) {
        var id = $routeParams.id;
        artistService
            .getById(id)
            .success(function(data) {
                $scope.artist = data;
            });

        $scope.edit = function () {
            $scope.edit.artist = angular.copy($scope.artist);
        };


    };
    app.controller("artistDetailsController", artistDetailsController);
}(angular.module("musicStore")));
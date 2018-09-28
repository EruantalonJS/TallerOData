(function (app) {
    var albumDetailsController = function ($scope, $routeParams, albumService) {
        var id = $routeParams.id;
        albumService
            .getById(id)
            .success(function(data) {
                $scope.album = data;
            });

        $scope.edit = function () {
            $scope.edit.album = angular.copy($scope.album);
        };


    };
    app.controller("albumDetailsController", albumDetailsController);
}(angular.module("musicStore")));
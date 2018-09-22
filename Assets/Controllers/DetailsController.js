(function (app) {
    var DetailsController = function ($scope, $routeParams, musicService) {
        var id = $routeParams.id;
        musicService
            .getById(id)
            .success(function(data) {
                $scope.music = data;
            });

        $scope.edit = function () {
        $scope.edit.music = angular.copy($scope.music);
        };


    };
    app.controller("DetailsController", DetailsController);
}(angular.module("theMusic")));
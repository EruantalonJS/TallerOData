(function(app) {
    var EditController = function ($scope, musicService) {

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.music;
        };

        $scope.cancel = function() {
            $scope.edit.music = null;
        };

        $scope.save = function () {
            if ($scope.edit.music.Id) {
                updateMusic();
            } else {
                createMusic();
            }
        };
        $scope.musics = [];
        var updateMusic = function() {
            musicService.update($scope.edit.music)
                    .then(function () {
                    angular.extend($scope.music, $scope.edit.music);
                    $scope.edit.music = null;
                });
        };

        var createMusic = function () {
            musicService.create($scope.edit.music)
                .then(function () {
                    $scope.musics.push($scope.edit.music);
                    $scope.edit.music = null;
                });
        };
    };
    app.controller("EditController", EditController);
}(angular.module("theMusic")));
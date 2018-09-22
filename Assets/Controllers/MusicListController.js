(function (app) {
    var MusicListController = function ($scope, musicService) {

        musicService
            .getAll()
            .success(function (data) {
                $scope.musics = data;
            });

        $scope.create = function () {
         $scope.edit = {
                music: {
                    Title: "",
                    Singers: "",
                    ReleaseDate: new Date().getFullYear(),
                    RunTime: 0
                }
            };
        };

        $scope.delete = function (music) {
            musicService.delete(music.Id)
                .success(function () {
                    removeMusicById(music.Id);
                });
        };

        var removeMusicById = function (id) {
            for (var i = 0; i < $scope.musics.length; i++) {
                if ($scope.musics[i].Id == id) {
                    $scope.musics.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("MusicListController", MusicListController);
}(angular.module("theMusic")));

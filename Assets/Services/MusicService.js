(function(app) {
    var musicService = function($http, musicApiUrl) {
        var getAll = function() {
            return $http.get(musicApiUrl);
        };

        var getById = function(id) {
            return $http.get(musicApiUrl + id);
        };

        var update = function(music) {
            return $http.put(musicApiUrl + music.Id, music);
        };

        var create = function (music) {
           console.log(JSON.stringify(music));
            return $http.post(musicApiUrl, music);
        };

        var destroy = function(id) {
            return $http.delete(musicApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };
    app.factory("musicService", musicService);
}(angular.module("theMusic")));
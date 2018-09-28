(function(app) {
    var albumService = function ($http, albumsApiUrl) {
        var getAll = function() {
            return $http.get(albumsApiUrl);
        };

        var getById = function(id) {
            return $http.get(albumsApiUrl + id);
        };

        var update = function (album) {
            return $http.put(albumsApiUrl + album.albumId, album);
        };

        var insert = function (album) {
            return $http.post(albumsApiUrl, album);
        };

        var remove = function(id) {
            return $http.delete(albumsApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            insert: insert,
            remove: remove
        };
    };
    app.factory("albumService", albumService);
}(angular.module("musicStore")));
(function(app) {
    var artistService = function ($http, artistsApiUrl) {
        var getAll = function() {
            return $http.get(artistsApiUrl);
        };

        var getById = function(id) {
            return $http.get(artistsApiUrl + id);
        };

        var update = function (artist) {
            return $http.put(artistsApiUrl + artist.artistId, artist);
        };

        var insert = function (artist) {
            return $http.post(artistsApiUrl, artist);
        };

        var remove = function(id) {
            return $http.delete(artistsApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            insert: insert,
            remove: remove
        };
    };
    app.factory("artistService", artistService);
}(angular.module("musicStore")));
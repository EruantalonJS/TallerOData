(function(app) {
    var genreService = function ($http, genresApiUrl) {
        var getAll = function() {
            return $http.get(genresApiUrl);
        };

        var getById = function(id) {
            return $http.get(genresApiUrl + id);
        };

        var update = function (genre) {
            return $http.put(genresApiUrl + genre.genreId, genre);
        };

        var insert = function (genre) {
            return $http.post(genresApiUrl, genre);
        };

        var remove = function(id) {
            return $http.delete(genresApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            insert: insert,
            remove: remove
        };
    };
    app.factory("genreService", genreService);
}(angular.module("musicStore")));
module MusuprApp {

    export class AdminService {

        private $http: ng.IHttpService;
        private $q: ng.IQService;

        public static $inject = ['$http', '$q'];
        constructor($http, $q) {
            this.$http = $http;
            this.$q = $q;
        }

        public BloquearUsuario(ID: number) {
            var defer = this.$q.defer();

            this.$http.post('/api/Admin/BloquearUsuario/' + ID, {})
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public DesbloquearUsuario(ID: number) {
            var defer = this.$q.defer();

            this.$http.post('/api/Admin/DesbloquearUsuario/' + ID, {})
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public BloquearAnuncio(ID: number) {
            var defer = this.$q.defer();

            this.$http.post('/api/Admin/BloquearAnuncio/' + ID, {})
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public DesbloquearAnuncio(ID: number) {
            var defer = this.$q.defer();

            this.$http.post('/api/Admin/DesbloquearAnuncio/' + ID, {})
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

    }
}

angular.module('MusuprApp').service('AdminService', MusuprApp.AdminService); 
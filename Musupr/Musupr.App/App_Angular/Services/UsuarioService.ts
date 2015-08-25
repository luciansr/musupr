module MusuprApp {

    export class UsuarioService {

        private $http: ng.IHttpService;
        private $q: ng.IQService;

        public static $inject = ['$http', '$q'];
        constructor($http, $q) {
            this.$http = $http;
            this.$q = $q;
        }

        public GetUsuarioByID(id: number) {
            var defer = this.$q.defer();

            this.$http.get('/api/Usuario/GetUsuarioByID?id=' + id)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public EditaUsuario(usuario: any, reCaptchaResponse: string) {
            var defer = this.$q.defer();

            this.$http.post('/api/Usuario/EditaUsuario',
                {
                    reCaptchaResponse: reCaptchaResponse,
                    param: usuario
                })
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetItensDoUsuario() {
            var defer = this.$q.defer();

            this.$http.get('/api/Usuario/GetItensDoUsuario')
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public IsUsernameUnique(username: string) {
            var defer = this.$q.defer();
            if (username == '' || username == null || username === undefined) defer.reject();
            this.$http.get('/api/Usuario/IsUsernameUnique?username=' + username)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public IsEmailUnique(email: string) {
            var defer = this.$q.defer();
            if (email == '' || email == null || email === undefined) defer.reject();
            this.$http.get('/api/Usuario/IsEmailUnique?email=' + email)
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

angular.module('MusuprApp').service('UsuarioService', MusuprApp.UsuarioService); 
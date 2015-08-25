var MusuprApp;
(function (MusuprApp) {
    var UsuarioService = (function () {
        function UsuarioService($http, $q) {
            this.$http = $http;
            this.$q = $q;
        }
        UsuarioService.prototype.GetUsuarioByID = function (id) {
            var defer = this.$q.defer();
            this.$http.get('/api/Usuario/GetUsuarioByID?id=' + id)
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        UsuarioService.prototype.EditaUsuario = function (usuario, reCaptchaResponse) {
            var defer = this.$q.defer();
            this.$http.post('/api/Usuario/EditaUsuario', {
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
        };
        UsuarioService.prototype.GetItensDoUsuario = function () {
            var defer = this.$q.defer();
            this.$http.get('/api/Usuario/GetItensDoUsuario')
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        UsuarioService.prototype.IsUsernameUnique = function (username) {
            var defer = this.$q.defer();
            if (username == '' || username == null || username === undefined)
                defer.reject();
            this.$http.get('/api/Usuario/IsUsernameUnique?username=' + username)
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        UsuarioService.prototype.IsEmailUnique = function (email) {
            var defer = this.$q.defer();
            if (email == '' || email == null || email === undefined)
                defer.reject();
            this.$http.get('/api/Usuario/IsEmailUnique?email=' + email)
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        UsuarioService.$inject = ['$http', '$q'];
        return UsuarioService;
    })();
    MusuprApp.UsuarioService = UsuarioService;
})(MusuprApp || (MusuprApp = {}));
angular.module('MusuprApp').service('UsuarioService', MusuprApp.UsuarioService);
//# sourceMappingURL=UsuarioService.js.map
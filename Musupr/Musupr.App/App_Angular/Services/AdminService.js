var MusuprApp;
(function (MusuprApp) {
    var AdminService = (function () {
        function AdminService($http, $q) {
            this.$http = $http;
            this.$q = $q;
        }
        AdminService.prototype.BloquearUsuario = function (ID) {
            var defer = this.$q.defer();
            this.$http.post('/api/Admin/BloquearUsuario/' + ID, {})
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        AdminService.prototype.DesbloquearUsuario = function (ID) {
            var defer = this.$q.defer();
            this.$http.post('/api/Admin/DesbloquearUsuario/' + ID, {})
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        AdminService.prototype.BloquearAnuncio = function (ID) {
            var defer = this.$q.defer();
            this.$http.post('/api/Admin/BloquearAnuncio/' + ID, {})
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        AdminService.prototype.DesbloquearAnuncio = function (ID) {
            var defer = this.$q.defer();
            this.$http.post('/api/Admin/DesbloquearAnuncio/' + ID, {})
                .success(function (data) {
                defer.resolve(data);
            })
                .error(function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
        AdminService.$inject = ['$http', '$q'];
        return AdminService;
    })();
    MusuprApp.AdminService = AdminService;
})(MusuprApp || (MusuprApp = {}));
angular.module('MusuprApp').service('AdminService', MusuprApp.AdminService);
//# sourceMappingURL=AdminService.js.map
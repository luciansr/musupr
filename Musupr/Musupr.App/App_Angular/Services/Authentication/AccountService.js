var MusuprApp;
(function (MusuprApp) {
    var AccountService = (function () {
        function AccountService($http, $q, $window, $filter, SecurityService) {
            this.SecurityService = SecurityService;
            this.$http = $http;
            this.$q = $q;
            this.$window = $window;
            this.$filter = $filter;

            if ($window.sessionStorage["userInfo"]) {
                this.userInfo = JSON.parse($window.sessionStorage["userInfo"]);
            }
        }
        AccountService.prototype.SetUserName = function (nome) {
            this.userInfo.Nome = nome;
        };

        AccountService.prototype.UserIsAdmin = function () {
            var self = this;

            if (self.userInfo !== undefined && self.userInfo != null && self.userInfo.Role !== undefined && self.userInfo.Role != null && self.userInfo.Role != '') {
                return self.userInfo.Role.split(',').indexOf('admin') >= 0;
            }

            return false;
        };

        AccountService.prototype.UserHasAccess = function (allowedRoles) {
            var self = this;

            if (self.userInfo !== undefined && self.userInfo != null) {
                //var roles = self.userInfo.Role.split(',');
                return true;
                //if (allowedRoles === undefined || allowedRoles == null || allowedRoles.length == 0) return true;
                //var filteredArray = self.$filter('filter')(allowedRoles, self.userInfo.Role);
                //for (var index in filteredArray) {
                //    if (filteredArray[index] == self.userInfo.Role) {
                //        return true;
                //    }
                //}
            }

            return false;
        };

        AccountService.prototype.logout = function () {
            var self = this;
            var deferred = self.$q.defer();

            self.$window.sessionStorage["userInfo"] = null;
            self.userInfo = null;
            deferred.resolve(true);

            return deferred.promise;
        };

        AccountService.prototype.login = function (user, password) {
            var self = this;
            var deferred = self.$q.defer();

            var data = "grant_type=password&username=" + user + "&password=" + self.SecurityService.GetSHA512(password);

            self.$http.post('/GetToken', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (data) {
                if (data.access_token !== undefined && data.access_token != null) {
                    self.userInfo = {
                        accessToken: data.access_token,
                        Nome: data.Nome,
                        Role: data.Role,
                        ID: data.ID
                    };

                    self.$window.sessionStorage["userInfo"] = JSON.stringify(self.userInfo);
                    deferred.resolve(true);
                } else {
                    deferred.resolve(false);
                }
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        AccountService.prototype.getUserInfo = function () {
            return this.userInfo;
        };

        AccountService.prototype.TrocarSenha = function (guid, userID, novaSenha, reCaptchaResponse) {
            var self = this;
            var defer = this.$q.defer();

            this.$http.post('/api/Account/TrocarSenha?guid=' + guid + '&userID=' + userID + '&novaSenha=' + self.SecurityService.GetSHA512(novaSenha) + '&reCaptchaResponse=' + reCaptchaResponse, {}).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        AccountService.prototype.PedirTrocarSenha = function (userID, reCaptchaResponse) {
            var defer = this.$q.defer();

            this.$http.post('/api/Account/PedirTrocarSenha?userID=' + userID + '&reCaptchaResponse=' + reCaptchaResponse, {}).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        AccountService.prototype.RegistrarUsuario = function (Nome, userID, Email, senha, reCaptchaResponse) {
            var defer = this.$q.defer();
            var self = this;

            this.$http.post('/api/Account/RegistrarUsuario?Nome=' + Nome + '&userID=' + userID + '&Email=' + Email + '&senha=' + self.SecurityService.GetSHA512(senha) + '&reCaptchaResponse=' + reCaptchaResponse, {}).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };
        AccountService.$inject = ['$http', '$q', '$window', '$filter', 'SecurityService'];
        return AccountService;
    })();
    MusuprApp.AccountService = AccountService;
})(MusuprApp || (MusuprApp = {}));

angular.module('MusuprApp').service('AccountService', MusuprApp.AccountService);
//# sourceMappingURL=AccountService.js.map

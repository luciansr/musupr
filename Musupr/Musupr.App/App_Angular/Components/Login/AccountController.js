var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').controller('AccountController', ['$scope', 'AccountService', '$location', 'LogService', '$q', 'vcRecaptchaService',
        function ($scope, AccountService, $location, LogService, $q, vcRecaptchaService) {
            var self = this;
            self.userID = '';
            self.password = '';
            self.newUser = {};
            self.widgetId = '';
            self.salvaWidgetId = function (id) {
                self.widgetId = id;
            };
            self.RegistrarUsuario = function () {
                var reCaptchaResponse = vcRecaptchaService.getResponse(self.widgetId);
                LogService.Info('Aguarde');
                AccountService.RegistrarUsuario(self.newUser.Nome, self.newUser.userID, self.newUser.email, self.newUser.password, reCaptchaResponse).then(function (data) {
                    LogService.Success('Bem vindo(a), ' + self.newUser.Nome + '!');
                    AccountService.login(self.newUser.userID, self.newUser.password).then(function (success) {
                        if (success) {
                            $location.path('/');
                        }
                    });
                }, function (error) {
                    LogService.Error('Não foi possível efetuar o cadastro', 'Tente novamente mais tarde');
                });
            };
            init();
            function init() {
                $scope.$watchCollection('[accountCtrl.userID, accountCtrl.password]', function (newValues, oldValues) {
                    if (newValues != oldValues) {
                        self.wrongUserOrPassword = false;
                    }
                });
            }
            this.message = "LoginErrorMessage";
            this.isLogged = function () {
                return AccountService.getUserInfo() != null;
            };
            self.getUserInfo = function () {
                return AccountService.getUserInfo();
            };
            self.login = function (submit) {
                if (submit === undefined || submit) {
                    AccountService.login(self.userID, self.password).then(function (success) {
                        if (success) {
                            $location.path('/');
                        }
                    }, function (erro) {
                        if (erro.error == "invalid_grant") {
                            self.wrongUserOrPassword = true;
                        }
                    });
                }
            };
            self.logout = function () {
                AccountService.logout().then(function (success) {
                    if (success === true) {
                        $location.path('/');
                    }
                });
            };
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=AccountController.js.map
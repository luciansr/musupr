module MusuprApp {
    angular.module('MusuprApp').controller('PedirTrocarSenhaController', ['$routeParams', 'LogService', '$location', 'vcRecaptchaService', 'AccountService', '$scope',
        function ($routeParams, LogService: LogService, $location, vcRecaptchaService, AccountService: AccountService, $scope) {
            var self = this;

            self.widgetId = '';

            self.salvaWidgetId = function (id) {
                self.widgetId = id;
            }

            self.PedirTrocarSenha = function () {
                LogService.Info('Aguarde');
                var reCaptchaResponse = vcRecaptchaService.getResponse(self.widgetId);
                AccountService.PedirTrocarSenha(self.userID, reCaptchaResponse).then(
                    function (data) {
                        LogService.Success('Foi enviada uma mensagem para o seu e-mail para ser efetuada a troca de senha');
                        $location.path('/Login');
                    },
                    function (error) {
                        if (error.Message == '800') {
                            LogService.Error('reCAPTCHA Inválido', 'Tente novamente');
                            vcRecaptchaService.reload();
                        } else {
                            LogService.Success('Ocorreu um erro, tente novamente mais tarde');
                            $location.path('/Login');
                        }
                    });

            };

        }]);
}

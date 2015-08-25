module MusuprApp {
    angular.module('MusuprApp').controller('TrocarSenhaController', ['$routeParams', 'LogService', '$location', 'vcRecaptchaService', 'AccountService',
        function ($routeParams, LogService: LogService, $location, vcRecaptchaService, AccountService: AccountService) {
            var self = this;

            self.guid = $routeParams.guid;

            self.widgetId = '';

            self.salvaWidgetId = function (id) {
                self.widgetId = id;
            }

            self.trocarSenha = function () {
                var reCaptchaResponse = vcRecaptchaService.getResponse(self.widgetId);
                LogService.Info('Aguarde');
                AccountService.TrocarSenha(self.guid, self.userID, self.password, reCaptchaResponse).then(
                    function (data) {
                        LogService.Success('Senha trocada com sucesso');
                        $location.path('/Login');
                    },
                    function (error) {
                        if (error.Message == '800') {
                            LogService.Error('reCAPTCHA Inválido', 'Tente novamente');
                            vcRecaptchaService.reload();
                        } else {
                            LogService.Error('Não foi possível trocar a senha com os dados fornecidos', 'Tente solicitar novamente a troca de senha');
                            $location.path('/Login');
                        }
                    });
            };

        }]);
}

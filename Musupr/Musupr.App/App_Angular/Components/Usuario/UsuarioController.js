var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').controller('UsuarioController', ['UsuarioService', '$routeParams', 'LogService', '$location', 'vcRecaptchaService', 'AccountService',
        function (UsuarioService, $routeParams, LogService, $location, vcRecaptchaService, AccountService) {
            var self = this;
            self.id = $routeParams.id;
            self.widgetId = '';
            self.salvaWidgetId = function (id) {
                self.widgetId = id;
            };
            self.EditaUsuario = function () {
                var reCaptchaResponse = vcRecaptchaService.getResponse(self.widgetId);
                UsuarioService.EditaUsuario(self.usuario, reCaptchaResponse).then(function (data) {
                    LogService.Success('Usuário salvo com sucesso.');
                    $location.path('/Usuario/' + data);
                    AccountService.SetUserName(self.usuario.Nome);
                    vcRecaptchaService.reload();
                }, function (error) {
                    vcRecaptchaService.reload();
                    if (error.Message == '800') {
                        LogService.Warning('Marque novamente o campo "Não sou um robô"!', 'Erro no reCAPTCHA :(');
                    }
                    else if (error.Message == '401') {
                        LogService.Error('Você não tem esse tipo de permissão');
                        $location.path('/Vagas');
                    }
                    else {
                        LogService.Error('Tente novamente mais tarde.', 'Ocorreu um erro ao salvar o usuário');
                    }
                });
            };
            init();
            function init() {
                UsuarioService.GetUsuarioByID($routeParams.id).then(function (data) {
                    self.usuario = data;
                }, function (error) {
                    LogService.Info('Usuário não encontrado');
                    $location.path('/Vagas');
                });
            }
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=UsuarioController.js.map
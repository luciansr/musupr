var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').controller('VagaController', ['VagasService', '$routeParams', 'LogService', '$location',
        function (VagasService, $routeParams, LogService, $location) {
            var self = this;
            self.id = $routeParams.id;
            self.naoTemDados = function () {
                return self.vaga === undefined || self.vaga === null;
            };
            self.AvaliaVaga = function (like) {
                VagasService.AvaliaVaga(like, self.id).then(function (success) {
                    if (success) {
                        var texto = like ? 'gostei' : 'não gostei';
                        LogService.Success('Você avaliou esta vaga como "' + texto + '".');
                        self.vaga.Like = like;
                    }
                }, function (error) {
                    if (error.Message == 'Authorization has been denied for this request.') {
                        LogService.Error('Você não está logado', 'Faça login');
                    }
                    else {
                        LogService.Error('Tente novamente mais tarde', 'Erro na tentativa de avaliação');
                    }
                });
            };
            init();
            function init() {
                VagasService.GetVagaByID($routeParams.id).then(function (vaga) {
                    self.vaga = vaga;
                }, function (error) {
                    LogService.Info('Vaga não encontrada');
                    $location.path('/Vagas');
                });
            }
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=VagaController.js.map
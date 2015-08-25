var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').controller('NovaVagaController', ['VagasService', '$scope', 'AccountService', '$routeParams', 'LogService', '$location', 'vcRecaptchaService',
        function (VagasService, $scope, AccountService, $routeParams, LogService, $location, vcRecaptchaService) {
            var self = this;
            var agora = new Date();
            var depois = new Date();
            self.widgetId = '';
            self.salvaWidgetId = function (id) {
                self.widgetId = id;
            };
            self.loading = true;
            depois.setDate(depois.getDate() + 10);
            self.selectValues = [
                {
                    valor: 10,
                    texto: 'Validade de 10 dias'
                },
                {
                    valor: 15,
                    texto: 'Validade de 15 dias'
                },
                {
                    valor: 20,
                    texto: 'Validade de 20 dias'
                },
                {
                    valor: 30,
                    texto: 'Validade de 30 dias'
                },
                {
                    valor: 45,
                    texto: 'Validade de 45 dias'
                },
            ];
            init();
            self.SalvarAnuncio = function () {
                var reCaptchaResponse = vcRecaptchaService.getResponse(self.widgetId);
                VagasService.SalvarAnuncio(self.vaga, reCaptchaResponse).then(function (data) {
                    LogService.Success('Anúncio salvo com sucesso.');
                    self.vaga.ID = data;
                    $location.path('/Vaga/' + data);
                }, function (error) {
                    vcRecaptchaService.reload();
                    if (error.Message == '800') {
                        LogService.Warning('Marque novamente o campo "Não sou um robô"!', 'Erro no reCAPTCHA :(');
                    }
                    else if (error.Message == '401') {
                        LogService.Error('Você não tem esse tipo de permissão');
                        $location.path('/Vagas');
                    }
                    else if (error.Message == '406') {
                        LogService.Error('Você só pode ter até 5 anúncios ativos', 'Número de anúncios excedido');
                    }
                    else if (error.Message == '2') {
                        LogService.Error('Delete o anúncio antigo antes de criar um parecido', 'Anúncio duplicado');
                    }
                    else {
                        LogService.Error('Tente novamente mais tarde', 'Ocorreu um erro ao salvar o anúncio');
                    }
                });
            };
            function init() {
                $scope.$watch('novaVagaCtrl.vaga.TempoExpiracao', function (newVal, oldVal) {
                    if (newVal !== oldVal) {
                        var data = new Date();
                        self.vaga.DataExpiracao = data.setDate(data.getDate() + newVal);
                    }
                });
                if ($routeParams.id == undefined || $routeParams == null) {
                    self.TituloPlaceholder = 'Nova vaga';
                    self.loading = false;
                }
                else {
                    self.TituloPlaceholder = 'Editar vaga';
                    VagasService.GetVagaParaEditarByID($routeParams.id).then(function (vaga) {
                        self.vaga = vaga;
                        self.vaga.TempoExpiracao = 10;
                        self.loading = false;
                    }, function (error) {
                        if (error.Message == "NotFound") {
                            LogService.Info('Vaga não encontrada');
                            $location.path('/Vagas');
                        }
                        else if (error.Message == '401') {
                            LogService.Error('Você não tem autorização para editar este anúncio.');
                            $location.path('/Vaga/' + $routeParams.id);
                        }
                        else {
                            LogService.Info('Tente novamente mais tarde', 'Ocorreu um erro');
                            $location.path('/Vagas');
                        }
                    });
                }
                VagasService.GetTiposDeVagas().then(function (data) {
                    self.tiposDeVaga = [];
                    for (var i in data) {
                        self.tiposDeVaga.unshift({
                            ID: data[i].ID,
                            Nome: 'Tipo de vaga: ' + data[i].Nome
                        });
                    }
                    if ($routeParams.id == undefined || $routeParams == null) {
                        self.vaga = {
                            DataCriacao: agora,
                            DataExpiracao: depois,
                            CriadorNome: AccountService.getUserInfo().Nome,
                            TipoVagaID: self.tiposDeVaga[0].ID,
                            TempoExpiracao: 10
                        };
                    }
                }, function (error) {
                });
            }
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=NovaVagaController.js.map
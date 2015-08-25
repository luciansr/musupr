module MusuprApp {
    angular.module('MusuprApp').controller('VagasController', ['VagasService', '$scope', '$routeParams', '$location',
        function (VagasService: VagasService, $scope: ng.IScope, $routeParams, $location: ng.ILocationService) {
            var self = this;
            self.selectedPage = 1;

            self.loading = true;

            self.naoTemDados = function () {
                return self.vagasDaPagina === undefined || self.vagasDaPagina === null || self.vagasDaPagina.length === 0;
            };

            self.temDados = function () { return !self.naoTemDados(); }

            init();
            function init() {
                if ($routeParams.pagina !== undefined && $routeParams.pagina !== null && $routeParams.pagina !== '') {
                    self.selectedPage = $routeParams.pagina;
                }

                $scope.$watch('vagasCtrl.selectedPage', function (newVal, oldVal) {
                    if (newVal != oldVal) {
                        if ($routeParams.busca !== undefined && $routeParams.busca != null && $routeParams.busca != '') {
                            $location.path('/Vagas/' + $routeParams.busca + '/' + newVal);
                        } else {
                            $location.path('/Vagas/' + newVal);
                        }
                    }
                })

                VagasService.GetDadosDeVagaPorRecomendacao(self.selectedPage, $routeParams.busca).then(
                    function (data: DadosDePaginaDeVagas) {
                        self.numeroPaginas = data.numeroPaginas;
                        self.paginaSelecionada = data.paginaSelecionada;
                        self.vagasDaPagina = data.vagasDaPagina;
                        self.loading = false;
                    },
                    function (error) {
                    });

            }

        }]);
}

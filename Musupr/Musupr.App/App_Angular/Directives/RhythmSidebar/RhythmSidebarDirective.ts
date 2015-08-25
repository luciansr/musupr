module MusuprApp {
    declare var adsbygoogle;
    declare var window;
    angular.module('MusuprApp').directive('rhythmSidebar', function () {
        return {
            restrict: 'EA',
            transclude: false,
            templateUrl: 'App_Angular/Directives/RhythmSidebar/RhythmSidebarTemplate.html',
            controllerAs: 'sideBarCtrl',
            controller: ['VagasService', '$location', function (VagasService: VagasService, $location: ng.ILocationService) {
                var self = this;

                self.carregado = function () {
                    return self.tags !== undefined;
                };

                self.buscaVagas = function (busca) {
                    $location.path('/Vagas/1/' + busca);
                };

                init();
                function init() {
                    //(adsbygoogle = window.adsbygoogle || []).push({});

                    VagasService.GetSidebarInfo(6, 5).then(
                        function (data: SidebarInfoModel) {
                            self.ultimasOportunidades = data.ultimasOportunidades;
                            self.tags = data.tags;
                            self.tipoVagaCounter = data.tipoVagaCounter;
                        },
                        function (error) {
                        });

                    //self.numeroEstagios = data.numeroEstagios;
                    //self.numeroIniciacoes = data.numeroIniciacoes;
                    //self.numeroPaginas = data.numeroPaginas;
                    //self.numeroPlenos = data.numeroPlenos;
                    //self.numeroTrainees = data.numeroTrainees;
                }
            }]
        };
    });
} 
var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('rhythmSidebar', function () {
        return {
            restrict: 'EA',
            transclude: false,
            templateUrl: 'App_Angular/Directives/RhythmSidebar/RhythmSidebarTemplate.html',
            controllerAs: 'sideBarCtrl',
            controller: ['VagasService', '$location', function (VagasService, $location) {
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
                        VagasService.GetSidebarInfo(6, 5).then(function (data) {
                            self.ultimasOportunidades = data.ultimasOportunidades;
                            self.tags = data.tags;
                            self.tipoVagaCounter = data.tipoVagaCounter;
                        }, function (error) {
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
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=RhythmSidebarDirective.js.map
var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').controller('HomeController', [
        'VagasService',
        function (VagasService) {
            var self = this;

            self.ultimasVagas = [];

            self.tabs = [
                {
                    tabContent: '<a href="#service-branding" data-toggle="tab"><div class="alt-tabs-icon"><span class="icon-strategy"></span></div>Sem aborrecimento</a>',
                    templateUrl: 'App_Angular/Components/Home/Tabs/tab1.html'
                },
                {
                    tabContent: '<a href="#service-branding" data-toggle="tab"><div class="alt-tabs-icon"><span class="icon-desktop"></span></div>Direto ao ponto</a>',
                    templateUrl: 'App_Angular/Components/Home/Tabs/tab2.html'
                },
                {
                    tabContent: '<a href="#service-branding" data-toggle="tab"><div class="alt-tabs-icon"><span class="icon-tools"></span></div>Bom para a Empresa</a>',
                    templateUrl: 'App_Angular/Components/Home/Tabs/tab3.html'
                }
            ];

            init();
            function init() {
                VagasService.GetUltimasNVagas(3).then(function (data) {
                    self.ultimasVagas = data;
                }, function (error) {
                });
            }
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=HomeController.js.map

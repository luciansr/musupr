var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').controller('MenuController', ['$location',
        function ($location) {
            var self = this;
            self.isInLocation = function (path) {
                return $location.path() == path;
            };
            self.buscaVagas = function (busca) {
                $location.path('/Vagas/1/' + busca);
            };
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=MenuController.js.map
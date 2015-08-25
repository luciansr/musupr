module MusuprApp {
    angular.module('MusuprApp').controller('MenuController', ['$location',
        function ($location: ng.ILocationService) {
            var self = this;

            self.isInLocation = function (path) {
                return $location.path() == path;
            };

            self.buscaVagas = function (busca) {
                $location.path('/Vagas/1/' + busca);
            };
        }]);
}

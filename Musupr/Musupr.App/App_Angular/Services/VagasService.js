var MusuprApp;
(function (MusuprApp) {
    var VagasService = (function () {
        function VagasService($http, $q) {
            this.$http = $http;
            this.$q = $q;
        }
        VagasService.prototype.GetTiposDeVagas = function () {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetTiposDeVagas').success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.SalvarAnuncio = function (vaga, reCaptchaResponse) {
            var defer = this.$q.defer();

            this.$http.post('/api/Vagas/SalvarAnuncio', {
                reCaptchaResponse: reCaptchaResponse,
                param: vaga
            }).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.ExpirarAnuncio = function (ID) {
            var defer = this.$q.defer();

            this.$http.post('/api/Vagas/ExpirarAnuncio/' + ID, {}).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.AvaliaVaga = function (like, vagaId) {
            var defer = this.$q.defer();

            this.$http.post('/api/Vagas/AvaliaVaga?like=' + like + '&vagaId=' + vagaId, {}).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.GetSidebarInfo = function (numberOfTags, numberOfLastOpportunities) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetSidebarInfo?numberOfTags=' + numberOfTags + '&numberOfLastOpportunities=' + numberOfLastOpportunities).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.GetVagaParaEditarByID = function (id) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetVagaParaEditarByID?id=' + id).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.GetVagaByID = function (id) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetVagaByID?id=' + id).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.GetNTags = function (n) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetNTags?n=' + n).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.GetUltimasNVagas = function (n) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetUltimasNVagas?n=' + n).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };

        VagasService.prototype.GetDadosDeVagaPorRecomendacao = function (pagina, busca) {
            var defer = this.$q.defer();

            if (busca == undefined)
                busca = '';

            this.$http.get('/api/Vagas/GetDadosDeVagaPorRecomendacao?pagina=' + pagina + '&busca=' + busca).success(function (data) {
                defer.resolve(data);
            }).error(function (error) {
                defer.reject(error);
            });

            return defer.promise;
        };
        VagasService.$inject = ['$http', '$q'];
        return VagasService;
    })();
    MusuprApp.VagasService = VagasService;
})(MusuprApp || (MusuprApp = {}));

angular.module('MusuprApp').service('VagasService', MusuprApp.VagasService);
//# sourceMappingURL=VagasService.js.map

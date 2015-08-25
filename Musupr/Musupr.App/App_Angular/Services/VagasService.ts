module MusuprApp {
    export interface DadosDePaginaDeVagas {
        vagasDaPagina: Array<any>;
        paginaSelecionada: number;
        numeroPaginas: number;
    }

    export interface SidebarInfoModel {
        ultimasOportunidades: Array<any>;
        tags: Array<string>;
        tipoVagaCounter: Array<any>;
    }

    export class VagasService {

        private $http: ng.IHttpService;
        private $q: ng.IQService;

        public static $inject = ['$http', '$q'];
        constructor($http, $q) {
            this.$http = $http;
            this.$q = $q;
        }

        public GetTiposDeVagas() {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetTiposDeVagas')
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public SalvarAnuncio(vaga: any, reCaptchaResponse: string) {
            var defer = this.$q.defer();

            this.$http.post('/api/Vagas/SalvarAnuncio',
                {
                    reCaptchaResponse: reCaptchaResponse,
                    param: vaga
                })
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        
        public ExpirarAnuncio(ID: number) {
            var defer = this.$q.defer();

            this.$http.post('/api/Vagas/ExpirarAnuncio/' + ID, {})
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public AvaliaVaga(like: boolean, vagaId: number) {
            var defer = this.$q.defer();

            this.$http.post('/api/Vagas/AvaliaVaga?like=' + like + '&vagaId=' + vagaId, {})
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetSidebarInfo(numberOfTags: number, numberOfLastOpportunities: number) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetSidebarInfo?numberOfTags=' + numberOfTags + '&numberOfLastOpportunities=' + numberOfLastOpportunities)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetVagaParaEditarByID(id: number) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetVagaParaEditarByID?id=' + id)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetVagaByID(id: number) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetVagaByID?id=' + id)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetNTags(n: number) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetNTags?n=' + n)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetUltimasNVagas(n: number) {
            var defer = this.$q.defer();

            this.$http.get('/api/Vagas/GetUltimasNVagas?n=' + n)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }

        public GetDadosDeVagaPorRecomendacao(pagina: number, busca: string) {
            var defer = this.$q.defer();

            if (busca == undefined) busca = '';

            this.$http.get('/api/Vagas/GetDadosDeVagaPorRecomendacao?pagina=' + pagina + '&busca=' + busca)
                .success(function (data: DadosDePaginaDeVagas) {
                    defer.resolve(data);
                })
                .error(function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        }
    }
}

angular.module('MusuprApp').service('VagasService', MusuprApp.VagasService); 
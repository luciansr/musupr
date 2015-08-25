angular.module('MusuprApp', [
    'ngRoute',
    'ngAria',
    'ngAnimate',
    'angularSpinner',
    'ngSanitize',
    'angulartics',
    'angulartics.google.analytics',
    'btford.markdown',
    //'djds4rce.angular-socialshare',
    'smart-table',
    'vcRecaptcha',
    'ngMessages'
]);
angular.module('MusuprApp').config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        var resolveAuthentication = function (allowedRoles) {
            var authObj = {
                auth: ["$q", "AccountService", function ($q, AccountService) {
                        var userInfo = AccountService.getUserInfo();
                        if (userInfo) {
                            if (AccountService.UserHasAccess(allowedRoles)) {
                                return $q.when(userInfo);
                            }
                            else {
                                return $q.reject({ authenticated: true, allowedAccess: false });
                            }
                        }
                        else {
                            return $q.reject({ authenticated: false });
                        }
                    }]
            };
            return authObj;
        };
        $locationProvider.hashPrefix('!');
        $routeProvider
            .when('/', {
            templateUrl: 'App_Angular/Components/Home/Home.html',
            controller: 'HomeController as homeCtrl',
        })
            .when('/Vagas', {
            templateUrl: 'App_Angular/Components/Vagas/Vagas.html',
            controller: 'VagasController as vagasCtrl',
        })
            .when('/Vagas/:pagina', {
            templateUrl: 'App_Angular/Components/Vagas/Vagas.html',
            controller: 'VagasController as vagasCtrl',
        })
            .when('/Vagas/:pagina/:busca', {
            templateUrl: 'App_Angular/Components/Vagas/Vagas.html',
            controller: 'VagasController as vagasCtrl',
        })
            .when('/Vaga/:id', {
            templateUrl: 'App_Angular/Components/Vaga/Vaga.html',
            controller: 'VagaController as vagaCtrl',
        })
            .when('/NovaVaga', {
            templateUrl: 'App_Angular/Components/NovaVaga/NovaVaga.html',
            controller: 'NovaVagaController as novaVagaCtrl',
            resolve: resolveAuthentication([])
        })
            .when('/EditarVaga/:id', {
            templateUrl: 'App_Angular/Components/NovaVaga/NovaVaga.html',
            controller: 'NovaVagaController as novaVagaCtrl',
            resolve: resolveAuthentication([])
        })
            .when('/Usuario/:id', {
            templateUrl: 'App_Angular/Components/Usuario/Usuario.html',
            controller: 'UsuarioController as usuarioCtrl',
        })
            .when('/MeusAnuncios', {
            templateUrl: 'App_Angular/Components/MeusAnuncios/MeusAnuncios.html',
            controller: 'MeusAnunciosController as meusAnunciosCtrl',
            resolve: resolveAuthentication([])
        })
            .when('/Login', {
            templateUrl: 'App_Angular/Components/Login/Login.html',
        })
            .when('/TrocarSenha/:guid', {
            templateUrl: 'App_Angular/Components/TrocarSenha/TrocarSenha.html',
            controller: 'TrocarSenhaController as trocarSenhaCtrl',
        })
            .when('/PedirTrocarSenha', {
            templateUrl: 'App_Angular/Components/PedirTrocarSenha/PedirTrocarSenha.html',
            controller: 'PedirTrocarSenhaController as pedirTrocarSenhaCtrl',
        })
            .when('/Sobre', {
            templateUrl: 'App_Angular/Components/Sobre/Sobre.html',
        })
            .when('/Regras', {
            templateUrl: 'App_Angular/Components/Regras/Regras.html',
        })
            .when('/404', {
            templateUrl: 'App_Angular/Components/Shared/404/404.html',
        })
            .otherwise({ redirectTo: '/404' });
    }]);
angular.module('MusuprApp').config(['$httpProvider', '$analyticsProvider', 'usSpinnerConfigProvider', function ($httpProvider, $analyticsProvider, usSpinnerConfigProvider) {
        $httpProvider.interceptors.push('HttpInterceptorService');
        $analyticsProvider.firstPageview(true); /* Records pages that don't use $state or $route */
        $analyticsProvider.withAutoBase(true); /* Records full path */
        var opts = {
            lines: 7,
            length: 2,
            width: 4,
            radius: 8,
            corners: 0,
            rotate: 26,
            direction: 1,
            color: '#000',
            speed: 0.5,
            trail: 46,
            shadow: false,
            hwaccel: true,
            className: 'spinner',
            zIndex: 2e9,
            top: '50%',
            left: '50%' // Left position relative to parent
        };
        usSpinnerConfigProvider.setDefaults(opts);
    }]);
angular.module('MusuprApp').run(["$rootScope", "$window", "$location", function ($rootScope, $window, $location) {
        $rootScope.$on("$routeChangeSuccess", function (userInfo) {
            //console.log(userInfo);
            //try {
            //    grecaptcha.reset();
            //} catch (ex) { }
        });
        //$FB.init('235621179973454');
        $rootScope.$on("$routeChangeError", function (event, current, previous, eventObj) {
            if (eventObj.authenticated === false) {
                toastr.warning('É necessário fazer login para ter acesso a esta função.');
                $location.path('/Login');
            }
            else if (eventObj.allowedAccess === false) {
            }
        });
    }]);
//# sourceMappingURL=MusuprAppModule.js.map
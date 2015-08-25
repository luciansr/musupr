angular.module('MusuprApp',
    [
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
                    } else {
                        return $q.reject({ authenticated: true, allowedAccess: false });
                    }

                } else {
                    return $q.reject({ authenticated: false });
                }
            }]
        }

        return authObj;
    };

    $locationProvider.hashPrefix('!');

    $routeProvider
        .when('/', {
            templateUrl: 'App_Angular/Components/Home/Home.html',
            controller: 'HomeController as homeCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/Vagas', {
            templateUrl: 'App_Angular/Components/Vagas/Vagas.html',
            controller: 'VagasController as vagasCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/Vagas/:pagina', {
            templateUrl: 'App_Angular/Components/Vagas/Vagas.html',
            controller: 'VagasController as vagasCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/Vagas/:pagina/:busca', {
            templateUrl: 'App_Angular/Components/Vagas/Vagas.html',
            controller: 'VagasController as vagasCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/Vaga/:id', {
            templateUrl: 'App_Angular/Components/Vaga/Vaga.html',
            controller: 'VagaController as vagaCtrl',
            //resolve: resolveAuthentication([])
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
            //resolve: resolveAuthentication([])
        })
        .when('/MeusAnuncios', {
            templateUrl: 'App_Angular/Components/MeusAnuncios/MeusAnuncios.html',
            controller: 'MeusAnunciosController as meusAnunciosCtrl',
            resolve: resolveAuthentication([])
        })
        .when('/Login', {
            templateUrl: 'App_Angular/Components/Login/Login.html',
            //controller: 'AccountController as accountCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/TrocarSenha/:guid', {
            templateUrl: 'App_Angular/Components/TrocarSenha/TrocarSenha.html',
            controller: 'TrocarSenhaController as trocarSenhaCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/PedirTrocarSenha', {
            templateUrl: 'App_Angular/Components/PedirTrocarSenha/PedirTrocarSenha.html',
            controller: 'PedirTrocarSenhaController as pedirTrocarSenhaCtrl',
            //resolve: resolveAuthentication([])
        })
        .when('/Sobre',
        {
            templateUrl: 'App_Angular/Components/Sobre/Sobre.html',
            //resolve: resolveAuthentication([])
        })
        .when('/Regras',
        {
            templateUrl: 'App_Angular/Components/Regras/Regras.html',
            //resolve: resolveAuthentication([])
        })
        .when('/404',
        {
            templateUrl: 'App_Angular/Components/Shared/404/404.html',
            //resolve: resolveAuthentication([])
        })
        .otherwise({ redirectTo: '/404' });
}]);

angular.module('MusuprApp').config(['$httpProvider', '$analyticsProvider', 'usSpinnerConfigProvider', function ($httpProvider, $analyticsProvider, usSpinnerConfigProvider) {
    $httpProvider.interceptors.push('HttpInterceptorService');

    $analyticsProvider.firstPageview(true); /* Records pages that don't use $state or $route */
    $analyticsProvider.withAutoBase(true);  /* Records full path */

    var opts = {
        lines: 7, // The number of lines to draw
        length: 2, // The length of each line
        width: 4, // The line thickness
        radius: 8, // The radius of the inner circle
        corners: 0, // Corner roundness (0..1)
        rotate: 26, // The rotation offset
        direction: 1, // 1: clockwise, -1: counterclockwise
        color: '#000', // #rgb or #rrggbb or array of colors
        speed: 0.5, // Rounds per second
        trail: 46, // Afterglow percentage
        shadow: false, // Whether to render a shadow
        hwaccel: true, // Whether to use hardware acceleration
        className: 'spinner', // The CSS class to assign to the spinner
        zIndex: 2e9, // The z-index (defaults to 2000000000)
        top: '50%', // Top position relative to parent
        left: '50%' // Left position relative to parent
    };

    usSpinnerConfigProvider.setDefaults(opts);
}]);
declare var grecaptcha;
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
        } else if (eventObj.allowedAccess === false) {
            //console.log('Not allowed access - current: ' + current.$$route.originalPath, ', previous: ' + previous !== undefined && previous !== null ? previous.$$route.originalPath : '' + '.'); 
        }
    });
}]);

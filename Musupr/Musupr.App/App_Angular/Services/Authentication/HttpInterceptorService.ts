module MusuprApp {
    export module Auth {
        export class HttpInterceptorService {
            private $q: ng.IQService;
            private $window: ng.IWindowService;
            private $location: ng.ILocationService;

            public request;
            public responseError;

            public static $inject: any = ['$q', '$window', '$location'];
            constructor($q, $window, $location) {
                this.$q = $q;
                this.$window = $window;

                this.request = (config) => {
                    var self = this;
                    config.headers = config.headers || {};

                    if (self.$window.sessionStorage["userInfo"] != null) {
                        var userInfo = JSON.parse(self.$window.sessionStorage["userInfo"]);
                        if (userInfo != null) {
                            var token = userInfo.accessToken;
                        }
                    }

                    if (token) {
                        config.headers.Authorization = 'Bearer ' + token;
                    }

                    return config;
                };

                this.responseError = (rejection) => {
                    var self = this;

                    if (rejection.status === 401) {
                        toastr.error('Acesso não autorizado.');
                        self.$location.path('/Login');
                    }

                    return self.$q.reject(rejection);
                };
            }
        }
    }
}

//angular.module('MusuprApp').factory('HttpInterceptorService', MusuprApp.Auth.HttpInterceptorService.GetFactoryInstance);
angular.module('MusuprApp').service('HttpInterceptorService', MusuprApp.Auth.HttpInterceptorService);
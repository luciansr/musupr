var MusuprApp;
(function (MusuprApp) {
    (function (Auth) {
        var HttpInterceptorService = (function () {
            function HttpInterceptorService($q, $window, $location) {
                var _this = this;
                this.$q = $q;
                this.$window = $window;

                this.request = function (config) {
                    var self = _this;
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

                this.responseError = function (rejection) {
                    var self = _this;

                    if (rejection.status === 401) {
                        toastr.error('Acesso não autorizado.');
                        self.$location.path('/Login');
                    }

                    return self.$q.reject(rejection);
                };
            }
            HttpInterceptorService.$inject = ['$q', '$window', '$location'];
            return HttpInterceptorService;
        })();
        Auth.HttpInterceptorService = HttpInterceptorService;
    })(MusuprApp.Auth || (MusuprApp.Auth = {}));
    var Auth = MusuprApp.Auth;
})(MusuprApp || (MusuprApp = {}));

//angular.module('MusuprApp').factory('HttpInterceptorService', MusuprApp.Auth.HttpInterceptorService.GetFactoryInstance);
angular.module('MusuprApp').service('HttpInterceptorService', MusuprApp.Auth.HttpInterceptorService);
//# sourceMappingURL=HttpInterceptorService.js.map

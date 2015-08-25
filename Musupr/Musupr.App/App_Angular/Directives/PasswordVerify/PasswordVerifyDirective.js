var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive("passwordVerify", function () {
        return {
            require: "ngModel",
            scope: {
                passwordVerify: '='
            },
            link: function (scope, element, attrs, ctrl) {
                scope.$watch('passwordVerify', function (newVal, oldVal) {
                    if (newVal != oldVal) {
                        if (newVal != password2Value) {
                            ctrl.$setValidity("passwordVerify", false);
                        }
                        else {
                            ctrl.$setValidity("passwordVerify", true);
                        }
                    }
                });
                var password2Value = undefined;
                scope.$watch(function () {
                    var combined;
                    if (scope.passwordVerify || ctrl.$viewValue) {
                        combined = scope.passwordVerify + '_' + ctrl.$viewValue;
                    }
                    return combined;
                }, function (value) {
                    if (value) {
                        ctrl.$parsers.unshift(function (viewValue) {
                            var origin = scope.passwordVerify;
                            if (origin !== viewValue) {
                                ctrl.$setValidity("passwordVerify", false);
                                return undefined;
                            }
                            else {
                                ctrl.$setValidity("passwordVerify", true);
                                password2Value = viewValue;
                                return viewValue;
                            }
                        });
                    }
                });
            }
        };
    });
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=PasswordVerifyDirective.js.map
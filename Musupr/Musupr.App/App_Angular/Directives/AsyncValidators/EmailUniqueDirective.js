var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('emailUnique', ['UsuarioService', function (UsuarioService) {
            return {
                require: 'ngModel',
                link: function (scope, elm, attrs, ctrl) {
                    ctrl.$asyncValidators.emailUnique = function (modelValue, viewValue) {
                        //if (ctrl.$isEmpty(modelValue)) {
                        //    // consider empty model valid
                        //    return $q.when();
                        //}
                        return UsuarioService.IsEmailUnique(modelValue);
                    };
                }
            };
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=EmailUniqueDirective.js.map
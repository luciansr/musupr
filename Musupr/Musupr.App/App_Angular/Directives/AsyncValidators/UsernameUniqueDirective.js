var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('usernameUnique', ['UsuarioService', function (UsuarioService) {
            return {
                require: 'ngModel',
                link: function (scope, elm, attrs, ctrl) {
                    ctrl.$asyncValidators.usernameUnique = function (modelValue, viewValue) {
                        //if (ctrl.$isEmpty(modelValue)) {
                        //    // consider empty model valid
                        //    return $q.when();
                        //}
                        return UsuarioService.IsUsernameUnique(modelValue);
                    };
                }
            };
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=UsernameUniqueDirective.js.map
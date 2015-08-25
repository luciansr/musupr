var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('rhythmTab', function () {
        return {
            restrict: 'E',
            transclude: true,
            scope: {},
            templateUrl: 'my-dialog.html',
            link: function (scope, element) {
                scope.name = 'Jeff';
            }
        };
    });
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=RhythmTabsDirective.js.map

var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('rhythmTab', function () {
        return {
            restrict: 'EA',
            transclude: true,
            scope: {
                tabs: '=',
                minimal: '@',
                custom: '@'
            },
            templateUrl: 'App_Angular/Directives/RhythmTab/RhythmTabTemplate.html',
            link: function (scope, element) {
                scope.activeTabIndex = 0;
                scope.setTabActive = function (index) {
                    scope.activeTabIndex = index;
                };
            }
        };
    });
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=RhythmTabDirective.js.map
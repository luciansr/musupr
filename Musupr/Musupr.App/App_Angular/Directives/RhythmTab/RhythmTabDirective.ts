module MusuprApp {
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
                link: function (scope: any, element) {
                    scope.activeTabIndex = 0;

                    scope.setTabActive = function (index) {
                        scope.activeTabIndex = index;
                    };


                }
            };
        });
} 
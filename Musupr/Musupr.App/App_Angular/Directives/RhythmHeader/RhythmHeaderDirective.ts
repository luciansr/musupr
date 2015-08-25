module MusuprApp {
    angular.module('MusuprApp').directive('rhythmHeader', ['$window', function ($window: ng.IWindowService) {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                size: '@',
            },
            template: '<div id="rhythmHeader" ng-transclude ng-style=style></div>',
            link: function (scope: any, element, attrs) {
                
                var applyHeight = function () {
                    if (scope.size == 'full') {
                        scope.style = { height: $window.innerHeight + 'px' };
                    }
                    else {
                        scope.style = { height: scope.size };
                    }
                }
                applyHeight();

                angular.element($window).bind('resize', function () {
                    scope.$apply(function () {
                        applyHeight();
                    });
                });

            }
        };
    }]);
} 
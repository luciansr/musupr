module MusuprApp {
    angular.module('MusuprApp').directive('rhythmPagination', function () {
        return {
            restrict: 'EA',
            transclude: true,
            scope: {
                selectedPage: '=',
                maximumPages: '@',
                rangeToShow: '@'
            },
            templateUrl: 'App_Angular/Directives/RhythmPagination/RhythmPaginationTemplate.html',
            controller: ['$scope', function ($scope: any) {
                $scope.maximumPages = parseInt($scope.maximumPages, 10);
                $scope.rangeToShow = parseInt($scope.rangeToShow, 10);

                if ($scope.maximumPages === 0) {
                    $scope.maximumPages = 10;
                }

                if ($scope.rangeToShow === 0) {
                    $scope.rangeToShow = 10;
                }

                $scope.pages = Array.apply(null, new Array($scope.maximumPages)).map(Number.call, Number);

                $scope.selectPage = function (page) {
                    page = parseInt(page);
                    if (page >= 1 && page <= + $scope.maximumPages) { $scope.selectedPage = page; }
                }

                $scope.showFunction = function (index) {
                    return Math.abs($scope.selectedPage - index) <= $scope.rangeToShow - 1;
                };

                }]
        };
    });
} 
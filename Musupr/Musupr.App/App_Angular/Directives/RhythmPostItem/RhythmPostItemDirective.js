var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('rhythmPostItem', function () {
        return {
            restrict: 'EA',
            transclude: false,
            scope: {
                vaga: '='
            },
            templateUrl: 'App_Angular/Directives/RhythmPostItem/RhythmPostItemTemplate.html',
            controllerAs: 'postCtrl'
        };
    });
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=RhythmPostItemDirective.js.map
var MusuprApp;
(function (MusuprApp) {
    var RhythmService = (function () {
        function RhythmService() {
        }
        RhythmService.prototype.HeightInit = function () {
            angular.element(document).ready(function () {
                js_height_init();
            });
        };
        return RhythmService;
    })();
    MusuprApp.RhythmService = RhythmService;
})(MusuprApp || (MusuprApp = {}));

angular.module('MusuprApp').service('RhythmService', MusuprApp.RhythmService);
//# sourceMappingURL=RhythmService.js.map

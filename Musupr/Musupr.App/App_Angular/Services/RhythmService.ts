declare var js_height_init;

module MusuprApp {
    export class RhythmService {
        public HeightInit() {
            angular.element(document).ready(function () {
                js_height_init();

            });

        }
    }
}

angular.module('MusuprApp').service('RhythmService', MusuprApp.RhythmService); 
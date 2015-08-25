module MusuprApp {
    declare var adsbygoogle;
    declare var window;
    angular.module('MusuprApp').directive('googleAdSense', ['$timeout', function ($timeout) {
        return {
            restrict: 'EA',
            transclude: true,
            template: '<div id="adSenseDir" style="margin-bottom:40px;"><ins class="adsbygoogle" style="display:block" data-ad-client="ca-pub-6584286943454761" data-ad-slot="9012646414" data-ad-format="auto"></ins></div>',
            controller: ['$scope', function ($scope) {
                $('#adSenseDir').addClass("vagaAdSense mb-40");
                $timeout(function () {
                    (adsbygoogle = window.adsbygoogle || []).push({});
                }, 100);
            }]
        };
    }]);
} 
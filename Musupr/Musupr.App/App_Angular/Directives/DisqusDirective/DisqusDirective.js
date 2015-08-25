var MusuprApp;
(function (MusuprApp) {
    angular.module('MusuprApp').directive('disqus', ['$window', function ($window) {
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    disqusId: '@',
                    disqusTitle: '@',
                },
                template: '<div id="disqus_thread" ng-transclude></div>',
                link: function (scope, element, attrs) {
                    /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
                    disqus_url = 'http://musupr.com/#!/' + scope.disqusId;
                    disqus_identifier = scope.disqusId;
                    disqus_title = 'Musupr - ' + scope.disqusTitle;
                    /* * * DON'T EDIT BELOW THIS LINE * * */
                    (function () {
                        var dsq = document.createElement('script');
                        dsq.type = 'text/javascript';
                        dsq.async = true;
                        dsq.src = '//musupr1.disqus.com/embed.js';
                        (document.getElementsByTagName('head')[0] || $('body')[0]).appendChild(dsq);
                    })();
                }
            };
        }]);
})(MusuprApp || (MusuprApp = {}));
//# sourceMappingURL=DisqusDirective.js.map
var MusuprApp;
(function (MusuprApp) {
    var LogService = (function () {
        function LogService() {
        }
        LogService.prototype.Warning = function (message, title) {
            toastr.warning(message, title);
            console.log('Warning: ' + message);
        };
        LogService.prototype.Info = function (message, title) {
            toastr.info(message, title);
            console.log('Info: ' + message);
        };
        LogService.prototype.Error = function (message, title) {
            toastr.error(message, title);
            console.log('Error: ' + message);
        };
        LogService.prototype.Success = function (message, title) {
            toastr.success(message, title);
            console.log('Success: ' + message);
        };
        return LogService;
    })();
    MusuprApp.LogService = LogService;
})(MusuprApp || (MusuprApp = {}));
angular.module('MusuprApp').service('LogService', MusuprApp.LogService);
//# sourceMappingURL=LogService.js.map
module MusuprApp {
    export class LogService {
        public Warning(message: string, title?: string) {
            toastr.warning(message, title);
            console.log('Warning: ' + message);
        }

        public Info(message: string, title?: string) {
            toastr.info(message, title);
            console.log('Info: ' + message);
        }

        public Error(message: string, title?: string) {
            toastr.error(message, title);
            console.log('Error: ' + message);
        }

        public Success(message: string, title?: string) {
            toastr.success(message, title);
            console.log('Success: ' + message);
        }
    }
}

angular.module('MusuprApp').service('LogService', MusuprApp.LogService); 
module MusuprApp {
    angular.module('MusuprApp').controller('MeusAnunciosController', ['UsuarioService', 'LogService', '$location', 'AccountService', 'AdminService', 'VagasService',
        function (UsuarioService: UsuarioService, LogService: LogService, $location, AccountService: AccountService, AdminService: AdminService, VagasService: VagasService) {
            var self = this;
            self.items = {
                vagas: []
            };

            self.loading = true;

            self.isAdmin = AccountService.UserIsAdmin();

            self.DesbloquearAnuncio = function (id) {
                AdminService.DesbloquearAnuncio(id).then(
                    function (data) {
                        LogService.Success('Anúncio ' + id + ' desbloqueado com sucesso');
                        loadItems();
                    },
                    function (error) {
                        LogService.Error('Erro ao desbloquear anúncio ' + id);
                    });
            };

            self.BloquearAnuncio = function (id) {
                AdminService.BloquearAnuncio(id).then(
                    function (data) {
                        LogService.Success('Anúncio ' + id + ' bloqueado com sucesso');
                        loadItems();
                    },
                    function (error) {
                        LogService.Error('Erro ao bloquear anúncio ' + id);
                    });
            };

            self.DesbloquearUsuario = function (id) {
                AdminService.DesbloquearUsuario(id).then(
                    function (data) {
                        LogService.Success('Usuário ' + id + ' desbloqueado com sucesso');
                        loadItems();
                    },
                    function (error) {
                        LogService.Error('Erro ao desbloquear usuário ' + id);
                    });
            };

            self.BloquearUsuario = function (id) {
                AdminService.BloquearUsuario(id).then(
                    function (data) {
                        LogService.Success('Usuário ' + id + ' bloqueado com sucesso');
                        loadItems();
                    },
                    function (error) {
                        LogService.Error('Erro ao bloquear usuário ' + id);
                    });
            };

            self.ExpirarAnuncio = function (id) {
                VagasService.ExpirarAnuncio(id).then(
                    function (data) {
                        LogService.Success('Anúncio "' + id + '" expirado com sucesso');
                        loadItems();
                    },
                    function (error) {
                        if (error.Message == '401') {
                            LogService.Error('Você não tem autorização.');
                        } else {
                            LogService.Error('Erro ao expirar anúncio "' + id + '"');
                        }
                    });
            };

            loadItems();
            function loadItems() {
                UsuarioService.GetItensDoUsuario().then(
                    function (data: any) {
                        self.items.vagas = data.vagas;
                        self.items.usuarios = data.usuarios;
                        self.loading = false;
                    },
                    function (error) {
                        LogService.Error('Não foi possível carregar anúncios');
                        $location.path('/');
                    });

            }

        }]);
}

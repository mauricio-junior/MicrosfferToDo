﻿(function (app) {

    var listaController = function ($scope, atividadeService)
    {
        //pega os dados do web api
        atividadeService.getAtividades(0).success(function (data) {
            $scope.atividadestodo = data;
        });

        atividadeService.getAtividades(1).success(function (data) {
            $scope.atividadestodoRealizado = data;
        });
        

        //método que deleta o dado usando web api
        $scope.deleta = function (ativ) {
            atividadeService.deleta(ativ).success(function () {
                removerAtividadePorId(ativ.IdTodo);
            });
        };

        $scope.atualizaStatus = function (ativ, status) {
            atividadeService.atualizar(ativ.IdTodo, ativ.NomeTodo, status).success(function () {
                carregaDados();
                carregaDadosRealizados();
            });
        };

        $scope.salvar = function (ativ) {

            if (document.getElementById("btnSalvar").innerText == "Editar") {
                var _nome = document.getElementById("nomeTodo").value;
                var _id = document.getElementById("IdTodo").value;
                atividadeService.atualizar(_id, _nome, 0).success(function (data) {
                    carregaDados();

                    document.getElementById("btnSalvar").innerText = "Salvar";
                    document.getElementById("nomeTodo").value = "";
                    document.getElementById("IdTodo").value = "";
                });

            } else {
                var _nome = document.getElementById("nomeTodo").value;
                if (_nome.trim().length > 0) {
                    atividadeService.inserir(ativ).success(function (data) {
                        carregaDados();
                    });
                } else {
                    alert("Por favor, digite a atividade.");
                }
            }
        };

        $scope.editarDados = function (ativ) {
            document.getElementById("nomeTodo").value = ativ.NomeTodo;
            document.getElementById("IdTodo").value = ativ.IdTodo;

            document.getElementById("btnSalvar").innerText = "Editar";
        };

        //método privado utilizado para apagar ao invés de atualizar a página com o webapi
        var removerAtividadePorId = function (id) {
            for (var i = 0; i < $scope.atividadestodo.length; i++) {
                if ($scope.atividadestodo[i].IdTodo == id) {
                    $scope.atividadestodo.splice(i, 1);
                    break;
                }
            }
        };

        //carrega os dados
        var carregaDados = function () {
            atividadeService.getAtividades(0).success(function (data) {
                $scope.atividadestodo = data;
            });
        };

        //carrega os dados
        var carregaDadosRealizados = function () {
            atividadeService.getAtividades(1).success(function (data) {
                $scope.atividadestodoRealizado = data;
            });
        };

        
    };

    app.controller('listaController', listaController);

}(angular.module("atividadesModulo")))
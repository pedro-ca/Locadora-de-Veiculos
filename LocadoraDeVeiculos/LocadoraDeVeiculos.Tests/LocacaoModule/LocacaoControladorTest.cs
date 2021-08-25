﻿using FluentAssertions;
using LocadoraDeVeiculos.Controladores.ClientesModule;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.GrupoDeVeiculosModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoDeVeiculosModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoControladorTest
    {
        ControladorLocacao controlador = null;
        ControladorGrupoDeVeiculos controladorGrupoDeVeiculos = null;
        ControladorVeiculo controladorVeiculo = null;
        ControladorFuncionario controladorFuncionario = null;
        ControladorCliente controladorCliente = null;
        GrupoDeVeiculo grupoVeiculos;
        Veiculo veiculo;
        Funcionario funcionario;
        Cliente clienteContratante;
        Cliente clienteCondutor;
        Locacao locacao;

        public LocacaoControladorTest()
        {
            controladorGrupoDeVeiculos = new ControladorGrupoDeVeiculos();
            controladorVeiculo = new ControladorVeiculo();
            controladorFuncionario = new ControladorFuncionario();
            controladorCliente = new ControladorCliente();
            controlador = new ControladorLocacao(controladorVeiculo,controladorFuncionario,controladorCliente);
            Db.Update("DELETE FROM [TBVEICULO]");
            Db.Update("DELETE FROM [TBGRUPOVEICULO]");
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
            Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBLOCACAO]");
        }

        [TestMethod]
        public void TestMethod1()
        {
            grupoVeiculos = new GrupoDeVeiculo(0, "SUV", 10.0, 10.5, 10, 100);
            controladorGrupoDeVeiculos.InserirNovo(grupoVeiculos);
            veiculo = new Veiculo(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, "30000", 4, 5, 'G', true, true, true);
            controladorVeiculo.InserirNovo(veiculo);
            funcionario = new Funcionario(0, "Nome Teste", "954.746.736-04", "Endereco Funcionario", "4932518000", "teste@email.com", 001, "user acesso", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            controladorFuncionario.InserirNovo(funcionario);
            clienteContratante = new Cliente(0, "Nome Teste", "954.746.736-04", "Endereco Cliente", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteContratante);
            clienteCondutor = new Cliente(0, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            controladorCliente.InserirNovo(clienteCondutor);

            locacao = new Locacao(0, veiculo, funcionario, clienteContratante, clienteCondutor, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum");
            controlador.InserirNovo(locacao);

            var locacaoEncontrada = controlador.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(locacao);

        }
    }
}

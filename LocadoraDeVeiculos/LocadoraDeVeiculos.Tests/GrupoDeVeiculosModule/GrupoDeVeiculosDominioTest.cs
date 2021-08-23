using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Dominio.GrupoDeVeiculosModule;
using FluentAssertions;
using System;

namespace LocadoraDeVeiculos.Tests.GrupoDeVeiculosModule
{
    [TestClass]
    public class GrupoDeVeiculosDominioTest
    {
        [TestMethod]
        public void DeveCriarGrupoDeVeiculo_Correto()
        {
            GrupoDeVeiculo grupoDeVeiculos = new GrupoDeVeiculo(0,"nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);

            string resultado = grupoDeVeiculos.Validar();

            Assert.AreEqual("VALIDO", resultado);
        }

        [TestMethod]
        public void DeveApresentarErro_GrupoTotalmenteIncorreto()
        {
            GrupoDeVeiculo grupoDeVeiculos = new GrupoDeVeiculo(0,"",0f,0f,0f,0,0f,0f);

            string resultado = grupoDeVeiculos.Validar();

            Assert.AreEqual("O nome não pode ser nulo\nA taxa do Quilometro Controlado não pode ser nula nem negativa\nA taxa do Plano Diário não pode ser nula nem negativa\nA taxa do Quilometro Livre não pode ser nula nem negativa\nA quantidade de quilômetros não pode ser nulo nem negativo", 
                            resultado);
        }

        [TestMethod]
        public void DeveApresentarErro_SomenteNomeCorreto()
        {
            GrupoDeVeiculo grupoDeVeiculos = new GrupoDeVeiculo(0,"nome", 0f, 0f, 0f, 0, 0f, 0f);

            string resultado = grupoDeVeiculos.Validar();

            Assert.AreEqual("A taxa do Quilometro Controlado não pode ser nula nem negativa\nA taxa do Plano Diário não pode ser nula nem negativa\nA taxa do Quilometro Livre não pode ser nula nem negativa\nA quantidade de quilômetros não pode ser nulo nem negativo",
                            resultado);
        }

        [TestMethod]
        public void DeveApresentarErro_SomenteNomeIncorreto()
        {
            GrupoDeVeiculo grupoDeVeiculos = new GrupoDeVeiculo(0,"", 10f, 10f, 10f, 10, 10f, 10f);

            string resultado = grupoDeVeiculos.Validar();

            Assert.AreEqual("O nome não pode ser nulo\n",
                            resultado);
        }
    }
}

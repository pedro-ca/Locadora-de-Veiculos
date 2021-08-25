﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Dominio.ImagemVeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;

namespace LocadoraDeVeiculos.Controladores.ImagemVeiculoModule
{
    public class ControladorImagemVeiculo : Controlador<ImagemVeiculo>
    {
        #region Queries
        private const string ComandoInserir = @"";
        private const string ComandoEditar = @"";
        private const string ComandoExcluir = @"";
        private const string ComandoSelecionarTodosDoVeiculo = "";
        private const string ComandoSelecionarPorId = "";
        #endregion
        public override string Editar(int id, ImagemVeiculo registro)
        {
            registro.Id = Db.Insert(ComandoInserir,ObtemParametrosImagem(registro));
            return "a";
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override string InserirNovo(ImagemVeiculo registro)
        {
            string resultadoValidacao = "VALIDO";
            registro.Id = Db.Insert(ComandoInserir, ObtemParametrosImagem(registro));

            return resultadoValidacao;
        }

        public override ImagemVeiculo SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ImagemVeiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosImagem(ImagemVeiculo imagemVeiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", imagemVeiculo.Id);
            parametros.Add("ID_VEICULO", imagemVeiculo.idVeiculo);
            parametros.Add("IMAGEM", imagemVeiculo.imagem);

            return parametros;
        }
    }
}
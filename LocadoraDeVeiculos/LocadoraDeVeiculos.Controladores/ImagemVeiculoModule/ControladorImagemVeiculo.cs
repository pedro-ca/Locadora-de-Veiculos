﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ImagemVeiculoModule;

namespace LocadoraDeVeiculos.Controladores.ImagemVeiculoModule
{
    public class ControladorImagemVeiculo : Controlador<ImagemVeiculo>
    {

        private Bitmap bmp;
        #region Queries
        private const string comandoInserir = @"INSERT INTO [DBO].[TBIMAGEMVEICULO] 
                                                (
                                                 [ID_VEICULO],
                                                 [IMAGEM]
                                                )VALUES
                                                (
                                                @ID_VEICULO,
                                                @IMAGEM
                                                );";
        private const string comandoEditar = @"UPDATE [DBO].[TBIMAGEMVEICULO] SET [IMAGEM] = @IMAGEM WHERE [ID] = @ID";
        private const string comandoExcluir = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string comandoExcluirPorId = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string comandoExcluirTodosPorIdDoVeiculo = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO";
        private const string comandoSelecionarTodosDoVeiculo = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO;";
        private const string comandoSelecionarPorId = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string comandoSelecionarPorIdDoVeiculo = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO";
        private const string comandoSelecioarTodos = "SELECT * FROM DBO].[TBIMAGEMVEICULO]";
        #endregion
        public override string Editar(int id, ImagemVeiculo registro)
        {
            registro.Id = Db.Insert(comandoInserir,ObtemParametrosImagem(registro));
            return "";
        }

        public void EditarLista(List<ImagemVeiculo> registros)
        {
            if (registros != null)
            {
                if (registros.Count != 0)
                    ExcluirPorIdDoVeiculo(registros[0].idVeiculo);
                foreach (ImagemVeiculo imagem in registros)
                {
                    InserirNovo(imagem);
                }
            }
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(comandoExcluir, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool ExcluirPorIdDoVeiculo(int idVeiculo)
        {
            try
            {
                Db.Delete(comandoExcluirTodosPorIdDoVeiculo, AdicionarParametro("ID_Veiculo", idVeiculo));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override string InserirNovo(ImagemVeiculo registro)
        {
            string resultadoValidacao = "VALIDO";

            registro.Id = Db.Insert(comandoInserir, ObtemParametrosImagem(registro));

            return resultadoValidacao;
        }

        public override ImagemVeiculo SelecionarPorId(int id)
        {
            return Db.Get(comandoSelecionarPorId,ConverteEmImagemVeiculo,AdicionarParametro("ID",id));
        }
        public List<ImagemVeiculo> SelecionarPorIdDoVeiculo(int id)
        {
            return Db.GetAll(comandoSelecionarPorIdDoVeiculo, ConverteEmImagemVeiculo, AdicionarParametro("ID_VEICULO", id));
        }

        public override List<ImagemVeiculo> SelecionarTodos()
        {
            return Db.GetAll(comandoSelecioarTodos,ConverteEmImagemVeiculo);
        }

        public List<ImagemVeiculo> SelecioanrTodasImagensDeUmVeiculo(int id)
        {
            return Db.GetAll(comandoSelecionarTodosDoVeiculo, ConverteEmImagemVeiculo,AdicionarParametro("ID_VEICULO",id));
        }

        private Dictionary<string, object> ObtemParametrosImagem(ImagemVeiculo imagemVeiculo)
        {
            bmp = imagemVeiculo.imagem;
            MemoryStream memoria = new MemoryStream();
            bmp.Save(memoria,ImageFormat.Bmp);
            byte[] imagemByte = memoria.ToArray();

            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", imagemVeiculo.Id);
            parametros.Add("ID_VEICULO", imagemVeiculo.idVeiculo);
            parametros.Add("IMAGEM", imagemByte);

            return parametros;
        }

        private Bitmap ConverteEmImagem(IDataReader reader)
        {

            byte[] a = (byte[])(reader["IMAGEM"]);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            bmp = (Bitmap)tc.ConvertFrom(a);

            return bmp;
        }

        private ImagemVeiculo ConverteEmImagemVeiculo(IDataReader reader)
        {
            byte[] byteArray= (byte[])(reader["IMAGEM"]);
            var id = Convert.ToInt32(reader["ID"]);
            var idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            bmp = (Bitmap)tc.ConvertFrom(byteArray);
            Bitmap imagem = new Bitmap(bmp);

            return new ImagemVeiculo(id,idVeiculo, imagem);

        }
    }
}

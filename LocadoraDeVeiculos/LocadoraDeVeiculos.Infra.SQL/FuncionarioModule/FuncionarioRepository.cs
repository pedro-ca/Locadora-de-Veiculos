﻿using System;
using System.Collections.Generic;
using System.Data;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.SQL.Shared;

namespace LocadoraDeVeiculos.Controladores.FuncionarioModule
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IRepository<Funcionario>
    {
        #region queries
        protected override string SqlInserirEntidade
        {
            get
            {
                return
                    @"INSERT INTO TBFUNCIONARIO
					(
					    [NOME],
					    [REGISTROUNICO],
					    [ENDERECO],
					    [TELEFONE],
					    [EMAIL],
					    [EHPESSOAFISICA],
					    [MATRICULAINTERNA],
					    [USUARIOACESSO],
                        [SENHA],
					    [CARGO],
					    [SALARIO],
                        [DATAADMISSAO]
					)
					VALUES
					(
					    @NOME,
					    @REGISTROUNICO,
					    @ENDERECO,
					    @TELEFONE,
					    @EMAIL,
					    @EHPESSOAFISICA,
					    @MATRICULAINTERNA,
					    @USUARIOACESSO,
                        @SENHA,
					    @CARGO,
					    @SALARIO,
                        @DATAADMISSAO
					);";
            }
        }
        protected override string SqlEditarEntidade
        {
            get
            {
                return
                    @"UPDATE [TBFUNCIONARIO]
					SET
					    [NOME] = @NOME,
						[REGISTROUNICO] = @REGISTROUNICO,
						[ENDERECO] = @ENDERECO,
						[TELEFONE] = @TELEFONE,
						[EMAIL] = @EMAIL,
						[EHPESSOAFISICA] = @EHPESSOAFISICA,
						[MATRICULAINTERNA] = @MATRICULAINTERNA,
						[USUARIOACESSO] = @USUARIOACESSO,
                        [SENHA] = @SENHA,
						[CARGO] = @CARGO,
						[SALARIO] = @SALARIO,
                        [DATAADMISSAO] = @DATAADMISSAO
					WHERE [ID] = @ID;";
            }
        }
        protected override string SqlExcluirEntidade
        {
            get
            {
                return
                    @"DELETE FROM TBFUNCIONARIO WHERE [ID] = @ID;";
            }
        }
        protected override string SqlSelecionarEntidade
        {
            get
            {
                return
                    "SELECT * FROM [TBFUNCIONARIO] WHERE [ID] = @ID;";
            }
        }
        protected override string SqlSelecionarTodasEntidades
        {
            get
            {
                return
                    @"SELECT * FROM [TBFUNCIONARIO];";
            }
        }
        protected override string SqlExisteEntidade
        {
            get
            {
                return
                    @"SELECT 
                        COUNT(*) 
                    FROM 
                        [TBFUNCIONARIO]
                    WHERE 
                        [ID] = @ID";
            }
        }
        #endregion

        public string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();
            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(SqlEditarEntidade, ObtemParametros(registro));
            }
            return resultadoValidacao;
        }
        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(SqlExcluirEntidade, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool Existe(int id)
        {
            return Db.Exists(SqlSelecionarEntidade, AdicionarParametro("ID", id));
        }
        public string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();
            if (resultadoValidacao == "VALIDO")
                registro.Id = Db.Insert(SqlInserirEntidade, ObtemParametros(registro));

            return resultadoValidacao;
        }
        public Funcionario SelecionarPorId(int id)
        {
            return Db.Get(SqlSelecionarEntidade, ConverterEmEntidade, AdicionarParametro("ID", id));
        }
        public List<Funcionario> SelecionarTodos()
        {
            return Db.GetAll(SqlSelecionarTodasEntidades, ConverterEmEntidade);
        }

        protected override Dictionary<string, object> ObtemParametros(Funcionario entidade)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", entidade.Id);
            parametros.Add("NOME", entidade.Nome);
            parametros.Add("REGISTROUNICO", entidade.RegistroUnico);
            parametros.Add("ENDERECO", entidade.Endereco);
            parametros.Add("TELEFONE", entidade.Telefone);
            parametros.Add("EMAIL", entidade.Email);
            parametros.Add("MATRICULAINTERNA", entidade.MatriculaInterna);
            parametros.Add("USUARIOACESSO", entidade.UsuarioAcesso);
            parametros.Add("SENHA", entidade.Senha);
            parametros.Add("DATAADMISSAO", entidade.DataAdmissao);
            parametros.Add("CARGO", entidade.Cargo);
            parametros.Add("SALARIO", float.Parse(Convert.ToString(entidade.Salario)));
            parametros.Add("EHPESSOAFISICA", Convert.ToBoolean(entidade.EhPessoaFisica));

            return parametros;
        }
        protected override Funcionario ConverterEmEntidade(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string registroUnico = Convert.ToString(reader["REGISTROUNICO"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string email = Convert.ToString(reader["EMAIL"]);
            int matriculaInterna = Convert.ToInt32(reader["MATRICULAINTERNA"]);
            string usuarioAcesso = Convert.ToString(reader["USUARIOACESSO"]);
            string senha = Convert.ToString(reader["SENHA"]);
            DateTime dataAdmissao = Convert.ToDateTime(reader["DATAADMISSAO"]);
            string cargo = Convert.ToString(reader["CARGO"]);
            double salario = Convert.ToDouble(Convert.ToString(reader["SALARIO"]));
            bool ehPessoaFisica = Convert.ToBoolean(reader["EHPESSOAFISICA"]);

            Funcionario funcionario = new Funcionario(id, nome, registroUnico, endereco, telefone, email, matriculaInterna, usuarioAcesso,senha, dataAdmissao, cargo, salario, ehPessoaFisica);

            funcionario.Id = id;

            return funcionario;
        }
    }
}

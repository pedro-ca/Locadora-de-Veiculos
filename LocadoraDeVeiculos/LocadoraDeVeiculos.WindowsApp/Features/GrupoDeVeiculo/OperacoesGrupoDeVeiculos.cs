﻿using LocadoraDeVeiculos.Controladores.GrupoDeVeiculosModule;
using LocadoraDeVeiculos.Dominio.GrupoDeVeiculosModule;
using LocadoraDeVeiculos.WindowsApp.GrupoDeVeiculo;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.GrupoDeVeiculo
{
    public class OperacoesGrupoDeVeiculos : ICadastravel
    {
        private readonly ControladorGrupoDeVeiculos controlador = null;
        private readonly TabelaGrupoDeVeiculosControl tabelaGrupoDeVeiculos = null;

        public OperacoesGrupoDeVeiculos(ControladorGrupoDeVeiculos ctrlGrupoDeVeiculos)
        {
            controlador = ctrlGrupoDeVeiculos;
            tabelaGrupoDeVeiculos = new TabelaGrupoDeVeiculosControl();
        }
        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoDeVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo de Veiculos para poder editar!", "Edição de Grupo de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoDeVeiculos grupoSelecionado = controlador.SelecionarPorId(id);

            TarefaGrupoDeVeiculosForm tela = new TarefaGrupoDeVeiculosForm();

            tela.GrupoDeVeiculos = grupoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.GrupoDeVeiculos);

                List<GrupoDeVeiculos> grupoDeVeiculos = controlador.SelecionarTodos();

                tabelaGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veículos:[{tela.GrupoDeVeiculos.Nome}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaGrupoDeVeiculos.ObtemIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo de Veículos para excluir", "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GrupoDeVeiculos grupoSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Veículos:[{grupoSelecionado.Nome}]?",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<GrupoDeVeiculos> grupos = controlador.SelecionarTodos();

                tabelaGrupoDeVeiculos.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veículos: [{grupoSelecionado.Nome}]removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TarefaGrupoDeVeiculosForm tela = new TarefaGrupoDeVeiculosForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.GrupoDeVeiculos);

                List<GrupoDeVeiculos> grupoDeVeiculos = controlador.SelecionarTodos();

                tabelaGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veículos: [{tela.GrupoDeVeiculos.Nome}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<GrupoDeVeiculos> grupoDeVeiculos = controlador.SelecionarTodos();
            tabelaGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

            return tabelaGrupoDeVeiculos;
        }
    }
}

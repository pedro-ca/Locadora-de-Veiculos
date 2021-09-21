﻿using LocadoraDeVeiculos.Aplicacao.CupomModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Controladores.ClientesModule;
using LocadoraDeVeiculos.Controladores.CupomModule;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.GrupoDeVeiculosModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Controladores.ServicoModule;
using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Aplicacao.ClienteModule;
using LocadoraDeVeiculos.WindowsApp.Features.Clientes;
using LocadoraDeVeiculos.WindowsApp.Features.Cupons;
using LocadoraDeVeiculos.WindowsApp.Features.Dashboards;
using LocadoraDeVeiculos.WindowsApp.Features.Devolucoes;
using LocadoraDeVeiculos.WindowsApp.Features.Funcionarios;
using LocadoraDeVeiculos.WindowsApp.Features.GrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsApp.Features.Locacoes;
using LocadoraDeVeiculos.WindowsApp.Features.Parceiros;
using LocadoraDeVeiculos.WindowsApp.Features.Servicos;
using LocadoraDeVeiculos.WindowsApp.Features.Veiculos;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Windows.Forms;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;

namespace LocadoraDeVeiculos.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;
        private static TelaPrincipalForm instancia;

        private readonly ServicoAppService servicoAppService;
        private readonly ParceiroAppService parceiroAppService;
        private readonly CupomAppService cupomAppService;
        private readonly FuncionarioAppService funcionarioAppService;
        
        public static TelaPrincipalForm Instancia { get => instancia; set => instancia = value; }

        public TelaPrincipalForm()
        {
            InitializeComponent();
            instancia = this;
            MostrarDashBoard();

            servicoAppService = new(new ServicoRepository());       //podemos passar esses AppService como parametro no construtor
            parceiroAppService = new(new ParceiroRepository());
            cupomAppService = new(new CupomRepository());
            funcionarioAppService = new(new FuncionarioRepository());
        }

        #region Opções do menu strip
        private void FuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesFuncionario(funcionarioAppService);

            ConfigurarPainelRegistros();
        }

        private void ServicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoServicoToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesServico(servicoAppService);

            ConfigurarPainelRegistros();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesClientes(new ClienteAppService(new ClienteRepository()));

            ConfigurarPainelRegistros();
        }

        private void VeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesVeiculo(new VeiculoRepository());

            ConfigurarPainelRegistros();
        }

        private void GrupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoDeVeiculosToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoDeVeiculos(new GrupoDeVeiculosRepository());

            ConfigurarPainelRegistros();
        }
        private void LocarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoLocacaoToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesLocacao(new LocacaoRepository(new VeiculoRepository(), new FuncionarioRepository(), new ClienteRepository(), new ServicoRepository(), new CupomRepository()));

            ConfigurarPainelRegistros();
        }

        private void DevoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDevolucaoToolBox configuracao = new();

            ConfigurarToolBox(configuracao, true);
            btnAdicionar.Image = Properties.Resources.car_32px;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesDevolucao(new LocacaoRepository(new VeiculoRepository(), new FuncionarioRepository(), new ClienteRepository(), new ServicoRepository(), new CupomRepository()));

            ConfigurarPainelRegistros();
        }

        private void CuponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoCupomToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesCupom(cupomAppService, parceiroAppService);

            ConfigurarPainelRegistros();
        }

        private void ParceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesParceiro(parceiroAppService);

            ConfigurarPainelRegistros();
        }
        #endregion

        #region Ações dos botões
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }
        #endregion

        #region Métodos privados
        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarPainelDashBoard()
        {
            DashControl tabela = new();     //PASSAR AppServices NO CONSTRUTOR
            tabela.Dock = DockStyle.Fill;
            panelRegistros.Controls.Clear();
            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarToolBox(IConfiguracaoToolBox configuracao, bool possivelFiltrar)
        {
            toolBoxAcoes.Enabled = true;
            if (possivelFiltrar)
                btnFiltrar.Enabled = true;
            else
                btnFiltrar.Enabled = false;
            labelTipoCadastro.Text = configuracao.TipoCadastro;
            btnAdicionar.ToolTipText = configuracao.ToolTipAdicionar;
            btnEditar.ToolTipText = configuracao.ToolTipEditar;
            btnExcluir.ToolTipText = configuracao.ToolTipExcluir;
        }
        #endregion
        public void AtualizarRodape(string mensagem) { labelRodape.Text = mensagem; }
        private void InícioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MostrarDashBoard();
        }
        private void MostrarDashBoard()
        {
            ConfiguracaoDashboardToolBox configuracao = new();
            ConfigurarToolBox(configuracao, false);
            toolBoxAcoes.Enabled = false;
            AtualizarRodape(configuracao.TipoCadastro);
            ConfigurarPainelDashBoard();
        }
    }
}

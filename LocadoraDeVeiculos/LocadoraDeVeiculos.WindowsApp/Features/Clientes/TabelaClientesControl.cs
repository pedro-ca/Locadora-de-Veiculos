﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.WindowsApp.Shared;

namespace LocadoraDeVeiculos.WindowsApp.Clientes
{
    public partial class TabelaClientesControl : UserControl
    {
        public TabelaClientesControl()
        {
            InitializeComponent();
            gridClientes.ConfigurarGridZebrado();
            gridClientes.ConfigurarGridSomenteLeitura();
            gridClientes.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn {DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn {DataPropertyName = "", HeaderText = ""}
           };

            return colunas;
        }
    }
}

using ProjetoFinalEletronicos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalEletronicos
{
    public partial class frmListagemCliente : Form
    {
        Cliente _cliente;
        ClienteServico _clienteServico;
        public frmListagemCliente()
        {
            InitializeComponent();
            _cliente = new Cliente();
            _clienteServico = new ClienteServico();

        }
        public void LoadDgv()
        {
            var listaClientes = _clienteServico.Listar();
            if (dgvListaClientes.Rows.Count > 0)
            {
                dgvListaClientes.Rows.Clear();
            }
            foreach (var cliente in listaClientes)
            {
                dgvListaClientes.Rows.Add(cliente.Id, cliente.Nome,
                    cliente.CPF, cliente.Celular);
            }
        }
        private void frmListagemCliente_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            frmCliente.ShowDialog();
            LoadDgv();
        }

        private void dgvListaCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvListaClientes.Rows[e.RowIndex].Cells[0].Value);
            frmCliente frmCliente = new frmCliente(id);
            frmCliente.ShowDialog();
            LoadDgv();
        }
    }
}

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
    public partial class frmCliente : Form
    {
        Cliente _cliente;
        ClienteServico _clienteServico;
        public frmCliente()
        {
            InitializeComponent();
            _cliente = new Cliente();
            _cliente.Id = 0;
            _clienteServico = new ClienteServico();
        }
        public frmCliente(int id)
        {
            InitializeComponent();
            _cliente = new Cliente();
            _clienteServico = new ClienteServico();
            _cliente = _clienteServico.Selecionar(id);
            txtNome.Text = _cliente.Nome;
            txtCPF.Text = _cliente.CPF;
            txtCelular.Text = _cliente.Celular;
            btnExcluir.Visible = true;
        }
        public void Limpar()
        {
            _cliente = null;
            txtNome.Text = "";
            txtCPF.Text = "";
            txtCelular.Text = "";
            _cliente = new Cliente();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_cliente.Id == 0)
            {
                _cliente.Nome = txtNome.Text;
                _cliente.CPF = txtCPF.Text;
                _cliente.Celular = txtCelular.Text;
                _clienteServico.Adicionar(_cliente);
            }
            else
            {
                _cliente.Nome = txtNome.Text;
                _cliente.CPF = txtCPF.Text;
                _cliente.Celular = txtCelular.Text;
                _clienteServico.Atualiza(_cliente);
                this.Close();
            }
            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja excluir esse cliente " +
                "do banco de dados?", "Excluir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                _clienteServico.Excluir(_cliente);
                MessageBox.Show("Excluido com sucesso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operação de excluir, cancelada");
            }
        }
    }
}

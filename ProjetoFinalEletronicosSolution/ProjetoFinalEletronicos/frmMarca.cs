using ProjetoFinalEletronicos.Modelo;
using ProjetoFinalEletronicos.Service;
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
    public partial class frmMarca : Form
    {
        Marca _marca;
        MarcaServico _marcaServico;
        public frmMarca()
        {
            InitializeComponent();
            _marca = new Marca();
            _marca.Id = 0;
            _marcaServico = new MarcaServico();
        }
        public frmMarca(int id)
        {
            InitializeComponent();
            _marca = new Marca();
            _marcaServico = new MarcaServico();
            _marca = _marcaServico.Selecionar(id);
            txtMarca.Text = _marca.Nome;
            btnExcluir.Visible = true;
        }
        public void Limpar()
        {
            _marca = null;
            txtMarca.Text = "";
            _marca = new Marca();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_marca.Id == 0)
            {
                _marca.Nome = txtMarca.Text;
                _marcaServico.Adicionar(_marca);
            }
            else
            {
                _marca.Nome = txtMarca.Text;
                _marcaServico.Atualiza(_marca);
                this.Close();
            }
            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja excluir essa marca " +
                "do banco de dados?", "Excluir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                _marcaServico.Excluir(_marca);
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

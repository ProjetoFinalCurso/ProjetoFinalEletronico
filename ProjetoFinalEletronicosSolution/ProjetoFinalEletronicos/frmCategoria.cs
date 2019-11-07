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
    public partial class frmCategoria : Form
    {
        Categoria _categoria;
        CategoriaServico _categoriaServico;
        public frmCategoria()
        {
            InitializeComponent();
            _categoria = new Categoria();
            _categoria.Id = 0;
            _categoriaServico = new CategoriaServico();
        }
        
        public frmCategoria(int id)
        {
            InitializeComponent();
            _categoria = new Categoria();
            _categoriaServico = new CategoriaServico();
            _categoria = _categoriaServico.Selecionar(id);
            txtCategoria.Text = _categoria.Nome;
            btnExcluir.Visible = true;
        }
        public void Limpar()
        {
            _categoria = null;
            txtCategoria.Text = "";
            _categoria = new Categoria();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_categoria.Id == 0)
            {
                _categoria.Nome = txtCategoria.Text;
                _categoriaServico.Adicionar(_categoria);
            }
            else
            {
                _categoria.Nome = txtCategoria.Text;
                _categoriaServico.Atualiza(_categoria);
                this.Close();
            }
            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja excluir essa categoria " +
                "do banco de dados?", "Excluir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                _categoriaServico.Excluir(_categoria);
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

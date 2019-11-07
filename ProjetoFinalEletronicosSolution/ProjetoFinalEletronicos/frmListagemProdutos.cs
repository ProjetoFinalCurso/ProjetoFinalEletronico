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
    public partial class frmListagemProdutos : Form
    {
        Produto _produto;
        ProdutoServico _produtoServico;
        public frmListagemProdutos()
        {
            InitializeComponent();
            _produto = new Produto();
            _produtoServico = new ProdutoServico();

        }
        public void LoadDgv()
        {
            MarcaServico marcaServico = new MarcaServico();
            CategoriaServico categoriaServico = new CategoriaServico();

            var listaProdutos = _produtoServico.Listar<Produto>(r => r.Categoria, r => r.Marca);
            if (dgvListaProdutos.Rows.Count > 0)
            {
                dgvListaProdutos.Rows.Clear();
            }
            foreach (var produto in listaProdutos)
            {                
                dgvListaProdutos.Rows.Add(produto.Id, produto.Nome, produto.Descricao,
                    produto.Cor, produto.Quantidade,
                    produto.Marca.Nome, produto.Categoria.Nome);
            }
        }
        private void frmListagemProduto_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmProduto frmProduto = new frmProduto();
            frmProduto.ShowDialog();
            LoadDgv();
        }

        private void dgvListaProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvListaProdutos.Rows[e.RowIndex].Cells[0].Value);
            frmProduto frmProduto = new frmProduto(id);
            frmProduto.ShowDialog();
            LoadDgv();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca frmMarca = new frmMarca();
            frmMarca.ShowDialog();
            LoadDgv();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.ShowDialog();
            LoadDgv();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            frmCliente.ShowDialog();
            LoadDgv();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto frmProduto = new frmProduto();
            frmProduto.ShowDialog();
            LoadDgv();
        }

        private void marcaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListagemMarca frmListagemMarca = new frmListagemMarca();
            frmListagemMarca.ShowDialog();
            LoadDgv();
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListagemCategoria frmListagemCategoria = new frmListagemCategoria();
            frmListagemCategoria.ShowDialog();
            LoadDgv();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListagemCliente frmListagemCliente = new frmListagemCliente();
            frmListagemCliente.ShowDialog();
            LoadDgv();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            frmProduto frmProduto = new frmProduto();
            frmProduto.ShowDialog();
            LoadDgv();
        }
    }
}

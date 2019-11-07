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
    public partial class frmProduto : Form
    {        
        Produto _produto;
        ProdutoServico _produtoServico;
        public frmProduto()
        {
            InitializeComponent();
            _produto = new Produto();
            _produto.Id = 0;
            _produtoServico = new ProdutoServico();
        }
        public frmProduto(int id)
        {
            InitializeComponent();
            _produto = new Produto();
            _produtoServico = new ProdutoServico();
            _produto = _produtoServico.Listar<Produto>(r=>r.Marca, r=>r.Categoria)
                .FirstOrDefault(r=>r.Id == id);

            txtNome.Text = _produto.Nome;
            txtDescricao.Text = _produto.Descricao;
            txtCor.Text = _produto.Cor;
            nudQuantidade.Value = _produto.Quantidade;     
            
            btnExcluir.Visible = true;
        }
        public void Limpar()
        {
            _produto = null;
            txtDescricao.Text = "";
            txtNome.Text = "";
            txtCor.Text = "";
            //Retorna para o primeiro item do CBO
            cboCategoria.SelectedIndex = 0;
            nudQuantidade.Value = 0;
            _produto = new Produto();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_produto.Id == 0)
            {
                _produto.Nome = txtNome.Text;
                _produto.Quantidade = (int)nudQuantidade.Value;
                _produto.Descricao = txtDescricao.Text;
                _produto.Cor = txtNome.Text;
                _produto.CategoriaId = ((KeyValuePair<int, string>)cboCategoria.SelectedItem).Key;
                _produto.MarcaId = Convert.ToInt32(cboMarca.SelectedValue);
                _produtoServico.Adicionar(_produto);
            }
            else
            {
                var produto = new Produto();
                produto.Id = _produto.Id;
                produto.Nome = txtNome.Text;
                produto.Descricao = txtDescricao.Text;
                produto.Quantidade = (int)nudQuantidade.Value;
                produto.Cor = txtNome.Text;
                produto.CategoriaId = ((KeyValuePair<int, string>)cboCategoria.SelectedItem).Key;
                produto.MarcaId = Convert.ToInt32(cboMarca.SelectedValue);
                _produtoServico.Atualiza(produto);
                this.Close();
            }
            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja excluir essa Produto " +
                "do banco de dados?", "Excluir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                _produtoServico.Excluir(_produto);
                MessageBox.Show("Excluido com sucesso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operação de excluir, cancelada");
            }
        }
        

        private void frmProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 
            // '_ProjetoFinalEletronicos_DBDataSet.Produtos'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.marcasTableAdapter.Fill(this._ProjetoFinalEletronicos_DBDataSet.Marcas);
            LoadCBO();
        }

        public void LoadCBO()
        {
            CategoriaServico _categoriaServico = new CategoriaServico();
            foreach (var categoria in _categoriaServico.Listar())
            {
                var item = new KeyValuePair<int, string>(categoria.Id, categoria.Nome);
                cboCategoria.Items.Add(item);
            }
            cboCategoria.DisplayMember = "Value";
            cboCategoria.ValueMember = "Key";
            if (_produto.Id != 0)
            {
                cboMarca.SelectedIndex = cboMarca.FindString(_produto.Marca.Nome);
                cboCategoria.SelectedIndex = cboCategoria.FindStringExact(_produto.Categoria.Nome);
            }
        }
    }
}

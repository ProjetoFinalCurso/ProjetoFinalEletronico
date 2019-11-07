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
    public partial class frmListagemCategoria : Form
    {
        Categoria _categoria;
        CategoriaServico _categoriaServico;
        public frmListagemCategoria()
        {
            InitializeComponent();
            _categoria = new Categoria();
            _categoriaServico = new CategoriaServico();

        }
        public void LoadDgv()
        {
            var listaCategorias = _categoriaServico.Listar();
            if (dgvListaCategoria.Rows.Count > 0)
            {
                dgvListaCategoria.Rows.Clear();
            }
            foreach (var categoria in listaCategorias)
            {
                dgvListaCategoria.Rows.Add(categoria.Id, categoria.Nome);
            }
        }
        private void frmListagemCategoria_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.ShowDialog();
            LoadDgv();
        }

        private void dgvListaCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvListaCategoria.Rows[e.RowIndex].Cells[0].Value);
            frmCategoria frmCategoria = new frmCategoria(id);
            frmCategoria.ShowDialog();
            LoadDgv();
        }
    }
}

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
    public partial class frmListagemMarca : Form
    {
        Marca _marca;
        MarcaServico _marcaServico;
        public frmListagemMarca()
        {
            InitializeComponent();
            _marca = new Marca();
            _marcaServico = new MarcaServico();

        }
        public void LoadDgv()
        {
            var listaMarcas = _marcaServico.Listar();
            if (dgvListaMarcas.Rows.Count > 0)
            {
                dgvListaMarcas.Rows.Clear();
            }
            foreach (var marca in listaMarcas)
            {
                dgvListaMarcas.Rows.Add(marca.Id, marca.Nome);
            }
        }
        private void frmListagemMarca_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmMarca frmMarca = new frmMarca();
            frmMarca.ShowDialog();
            LoadDgv();
        }

        private void dgvListaMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvListaMarcas.Rows[e.RowIndex].Cells[0].Value);
            frmMarca frmMarca = new frmMarca(id);
            frmMarca.ShowDialog();
            LoadDgv();
        }
    }
}

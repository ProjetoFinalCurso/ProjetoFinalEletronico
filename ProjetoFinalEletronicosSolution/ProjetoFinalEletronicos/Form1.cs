using ProjetoFinalEletronicos.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoFinalEletronicos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "José";
            cliente.CPF = "169.792.040-33";
            cliente.Celular = "(19)99888-0254";
            ClienteServico clienteServico = new ClienteServico();
            clienteServico.Adicionar(cliente);
        }
    }
}

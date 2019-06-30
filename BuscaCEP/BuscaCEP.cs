using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaCEP
{
    public partial class BuscaCEP : Form
    {
        public BuscaCEP()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCEP.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCEP.Text))
            {
         
                using (var service = new Correios.CorreiosApi())
                {
                    try
                    {
                        var dados = service.consultaCEP(txtCEP.Text.Trim());
                        txtBairro.Text = dados.bairro;
                        txtCidade.Text = dados.cidade;
                        txtEstado.Text = dados.uf;
                        txtRua.Text = dados.end;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um cep valido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

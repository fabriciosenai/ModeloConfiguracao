using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configuracao
{
    public partial class Formlogin : Form
    {
        public bool Logou;
        public Formlogin()
        {
            InitializeComponent();
            Logou = false;
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                new UsuarioBLL().Altenticar(textBoxUsuário.Text, textBoxSenha.Text);
                Logou = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

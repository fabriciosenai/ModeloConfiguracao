using BLL;
using Models;
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
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.DataSource = new UsuarioBLL().BuscarTodos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (usuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Nao existe registro para ser excluidi. ");
                return;
            }
            if (MessageBox.Show("deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)

                return;

            int id = ((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);
            usuarioBindingSource.RemoveCurrent();
        }

        private void grupoUsuariosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
            Buscar_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)usuarioBindingSource.Current).Id;


            using (FormCadastroUsuario frm = new FormCadastroUsuario(id))
            {
                frm.ShowDialog();
            }
            Buscar_Click(null, null);
        }
    }
}


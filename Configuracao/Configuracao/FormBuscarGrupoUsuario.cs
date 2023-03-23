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
    public partial class FormBuscarGrupoUsuario : Form
    {
        public FormBuscarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarPorTodos();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (grupoUsuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser excluído!");
                return;
            }
            if (MessageBox.Show("Deseja realmente excluir este registro?",
                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).IdGrupo;
            new UsuarioBLL().Excluir(id);
            grupoUsuarioBindingSource.RemoveCurrent();

            MessageBox.Show("Registro excluido com sucesso!");

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;


            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario(id))
            {
                frm.ShowDialog();
            }
          //  Buscar_Click(null, null);
        }
    }
}

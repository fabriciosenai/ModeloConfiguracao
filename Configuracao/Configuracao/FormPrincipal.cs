using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configuracao
{
    public partial class FormPrincipal :Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            Usuario usuario = new Usuario();
            usuario.Nome = "Fabricio";
            usuario.NomeUsuario = "Teste";
            usuario.Ativo = true;
            usuario.CPF = "02323665197";
            usuario.Senha = "dferdf";
            usuario.Email = "contato@gmail.com";

            new UsuarioBLL().Inserir(usuario);
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarUsuario frm = new FormBuscarUsuario())
            {
                frm.ShowDialog();
            }
        }

        private void gruposDedUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarGrupoUsuario frm = new FormBuscarGrupoUsuario())
            {
                frm.ShowDialog();
            }
        }
    }
    }



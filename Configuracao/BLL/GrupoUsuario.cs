using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            ValidarDados(_grupousuario);
            GrupoUsuarioDAL grupousuarioDAL = new GrupoUsuarioDAL();
            grupousuarioDAL.inserir(_grupousuario);
        }
        public void Alterar(GrupoUsuario _grupousuario)
        {
            ValidarDados(_grupousuario);

            GrupoUsuarioDAL grupousuarioDAL = new GrupoUsuarioDAL();
            grupousuarioDAL.Alterar(_grupousuario);
        }
        public void Excluir(int _id)
        {
            new GrupoUsuarioDAL().Excluir(_id);
        }
        public List<GrupoUsuario> BuscarPorId(int _id)
        {
            return new GrupoUsuarioDAL().BuscarPorId(_id);
        }

        public List<GrupoUsuario> BuscarPorNome(string _nomegrupo)
        {
            return new GrupoUsuarioDAL().BuscarPorNome(_nomegrupo);
        }

        public List<GrupoUsuario> BuscarPorTodos()
        {
            return new GrupoUsuarioDAL().BuscarPorTodos();
        }
        private void ValidarDados(GrupoUsuario _grupousuario)

        {
            if (_grupousuario.NomeGrupo.Length <= 3)
            {
                throw new Exception("A senha deve ter menos de 50 caracteres.");
            }


            if (_grupousuario.NomeGrupo.Length == 0)
            {
                throw new Exception("O campo não posse nulo.");
            }

            GrupoUsuarioDAL grupousuarioDAL = new GrupoUsuarioDAL();
            grupousuarioDAL.inserir(_grupousuario);


        }
    }


}

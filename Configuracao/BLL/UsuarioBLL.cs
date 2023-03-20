using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario)
        {
            if (_usuario.Senha.Length <= 3)
                throw new Exception("A senha deve ter mais de 3 caracteres.");


            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.inserir(_usuario);
        }
        public void Alterar(Usuario _usuario)

        {
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
        }
        public void Excluir(int _id)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_id);
          // new UsuarioDAL().Excluir(_id);
        }
        public List<Usuario> BuscarTodos()
        {
            return new UsuarioDAL().BuscarPorTodos();
        }
        public List<Usuario> BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);
        }
        public List<Usuario> BuscarPorCPF(string _cpf)
        {
            return new UsuarioDAL().BuscarPorCPF(_cpf);
        }
        public List<Usuario> BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public List<Usuario> BuscarPorNomeUsuario(string _nomeUsuario)

        {
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
        }
        private void ValidarDados(Usuario _usuario)

        {
            if (_usuario.Senha.Length <= 3)
            {
                throw new Exception("A senha deve ter mais de 3 caracteres.");
            }
            if (_usuario.Senha.Length <= 2)
            {
                throw new Exception("A nome  deve ter mais de 2 caracteres.");
            }

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.inserir(_usuario);




        }



    }
}

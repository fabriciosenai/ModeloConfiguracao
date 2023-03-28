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
        public void Inserir(Usuario _usuario,string _confirmarSenha)
        {
            ValidarDados(_usuario, _confirmarSenha);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);


        }
        private void ValidarDados(Usuario _usuario, string _confirmarSenha)

        {
            if(_usuario.Senha != _confirmarSenha)
            {
                throw new Exception("Os campos de senha devem ser iguais.");
            }
            if (_usuario.Senha.Length <= 3)

                throw new Exception("A senha deve ter mais de 3 caracteres.");

            if (_usuario.Senha.Length <= 2)

                throw new Exception("A nome  deve ter mais de 2 caracteres.");
        }
        public void Alterar(Usuario _usuario, string _confirmaSenha)
        {
            //ValidarPermissao(3);
            ValidarDados(_usuario, _confirmaSenha);
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
        public Usuario BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);
        }
        public Usuario BuscarPorCPF(string _cpf)
        {
            return new UsuarioDAL().BuscarPorCPF(_cpf);
        }
        public Usuario BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)

        {
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
        }
        private void ValidarDado(Usuario _usuario)
        {

        }

        public void ValidarPermissao(int _idPermissao)

        {
            if (!new UsuarioDAL().ValidarPermissao(Constantes.IdUsuarioLogado, _idPermissao))
                throw new Exception("Você não tem permissão dr realizar essa operação. Procure o administrador do sistema.");
        }

        public void Altenticar(string _nomeUsuario, string _Senha)
        {
            Usuario usuario = new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
            if(_Senha == usuario.Senha && usuario.Ativo)
            {
                Constantes.IdUsuarioLogado = usuario.Id;
            }
            else
            {
                throw new Exception("Usuario ou senha inválidos");
            }
        }
    }

    }


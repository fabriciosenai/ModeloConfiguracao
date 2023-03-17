using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissaoBLL
    {

        public void Inserir(Permissao _permissao)
        {
            ValidarDados(_permissao);
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.inserir(_permissao);
        }
        public void Alterar(Permissao _permissao)
        {
            ValidarDados(_permissao);

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_permissao);
        }


        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);
        }

        public List<Permissao> BuscarPorId(int _id)
        {
            return new PermissaoDAL().BuscarPorId(_id);
        }

        public List<Permissao> BuscarPorDescricao(string _descricao)
        {

            return new PermissaoDAL().BuscarPorDescricao(_descricao);
        }
        public List<Permissao> BuscarPorTodos()
        {
            return new PermissaoDAL().BuscarPorTodos();
        }


        private void ValidarDados(Permissao _permissao)

        {
            if (_permissao.Descricao.Length > 150)
            {
                throw new Exception("A senha deve ter menos de 150 caracteres.");
            }


            if (_permissao.Descricao.Length == 0)
            {
                throw new Exception("O campo não posse nulo.");
            }

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.inserir(_permissao);


        }

    }


}

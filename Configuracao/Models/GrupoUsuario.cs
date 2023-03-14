using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class GrupoUsuario
    {
        public int Id { get; set; }

        public string NameGrupo { get; set; }

        public List<Permissao> Permissoes { get; set; }
    }
}

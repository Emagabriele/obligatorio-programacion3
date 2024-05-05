using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ITipoRepository : IRepositorio<Tipo>
    {
        public Tipo GetTipo(string nombre);
        public bool TieneCabañas(Tipo t);
        public Tipo Search(string nombre);
    }
}

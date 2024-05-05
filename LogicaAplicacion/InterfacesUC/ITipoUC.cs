using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesUC
{
    public interface ITipoUC
    {
        public TipoDto Add(TipoDto tipoDto);
        public IEnumerable<TipoDto> GetAll();
        public TipoDto GetTipo(string nombre);
        public void Delete(string nombreTipo);
        public TipoDto Edit(TipoDto TipoDto);
    }
}

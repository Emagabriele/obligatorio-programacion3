using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public void Add(T t);
        public void Delete(T t);
        public void Modify(T t);
        public IEnumerable<T> GetAll();
    }
}

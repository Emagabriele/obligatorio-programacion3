using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    [Owned]
    public class JacuzziPriv
    {
        public bool JacuzziPrivado { get; set; }

        public JacuzziPriv() { }

        public JacuzziPriv(bool jacuzziPrivado)
        {
            JacuzziPrivado = jacuzziPrivado;
        }
    }
}

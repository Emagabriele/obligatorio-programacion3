﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UsuarioDto
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }

    }
}

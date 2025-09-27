﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publicacion
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Texto { get; private set; } = string.Empty;


        public Guid ExAlumnoId { get; private set; }
        public ExAlumno? ExAlumno { get; private set; }

    }
}

﻿using MedidoresModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public interface ILecturaDAL
    {
        void AgregarMedidor(Medidor medidor);

        List<Medidor> ObtenerMedidores();

        void AgregarLectura(Lectura lectura);

        List<Lectura> ObtenerLecturas(Lectura lectura);

    }
}

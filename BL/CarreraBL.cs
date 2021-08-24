using System;
using System.Collections.Generic;
using System.Text;
using ML;
using DAL;

namespace BL
{
    public class CarreraBL
    {
        CarreraADO contexto;
        public CarreraBL()
        {
            contexto = new CarreraADO();
        }
        public List <Carrera> GetCarrera()
        {
            return contexto.GetCarrera();
        }

        public CarreraDB GetCarreraDB(int id)
        {
            return contexto.GetCarreraDB(id);
        }

        public void InsertarCarrera(string nombre,int facultad,int area)
        {
            contexto.InsertarCarrera(nombre, facultad, area);
        }

        public void UpdateCarrera(int id,string nombre,int facultad,int area)
        {
            contexto.updateCarrera(id, nombre, facultad, area);
        }

        public void DeleteCarrera(int id)
        {
            contexto.deleteCarrera(id);
        }

        public List<Carrera> SearchCarrera(string busqueda)
        {
            return contexto.searchCarrera(busqueda);
        }
        public int ContarCarreras()
        {
            return contexto.contarCarreras();
        }
    }
}

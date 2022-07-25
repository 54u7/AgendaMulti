using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class N_class
    {
        D_class obDato = new D_class();

        public List<E_class> ListarDatos(string buscar)
        {
            return obDato.ListarDatos(buscar);
        }

        public void InsertarDatos(E_class dato)
        {
            obDato.InsertarDatos(dato);
        }

        public void EditarDatos(E_class dato)
        {
            obDato.EditarDatos(dato);
        }

        public void EliminarDatos(E_class dato)
        {
            obDato.EliminarDatos(dato);
        }
    }
}

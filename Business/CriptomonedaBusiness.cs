using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CriptomonedaBusiness
    {
        private CriptomonedaDAO criptoDao = new CriptomonedaDAO();
        public void DarAlta(Criptomoneda cripto)
        {
            criptoDao.DarAlta(cripto);
        }
        public List<Criptomoneda> Consultar()
        {
            return criptoDao.GetCriptos();
        }

        public void Modificar(int id, double precio)
        {
            criptoDao.ModificarPrecio(id, precio);
        }

        public void Eliminar( int id)
        {
            criptoDao.Eliminar(id);
        }
    }
}

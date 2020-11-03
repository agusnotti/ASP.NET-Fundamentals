using Agenda.DAL;
using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BLL
{
    public class PaisBLL
    {
        public List<Pais> getPaises()
        {
            //instancio el pais Data Access
            PaisDA da = new PaisDA();

           //instancio lista donde voy a guardar el resultado del data set
            List<Pais> resultado = new List<Pais>();

            try
            {
                //obtengo data set de pais
                DataSet ds = da.getPaises();
                // extraigo la tabla de paises
                DataTable tblpaises = ds.Tables[0];


                foreach (DataRow dr in tblpaises.Rows)
                {
                    Pais pais = new Pais();
                    pais.id = Convert.ToInt32(dr["countryID"]);
                    pais.nombre = Convert.ToString(dr["name"]);
                    resultado.Add(pais);
                }
            }
            catch (Exception error)
            {
                Utils.Helpers.LogHelper.SaveError(error);
            }


            return resultado;
        }

    }
}

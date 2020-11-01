using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.DAL;
using Agenda.Entity;

namespace Agenda.BLL
{
    public class SiNoBLL
    {
        public List<SiNo> getSiNoList()
        {
            SiNoDA da = new SiNoDA();

            DataSet ds = da.getSiNo();

            //instancio lista donde voy a guardar el resultado del data set
            List<SiNo> resultado = new List<SiNo>();

            // extraigo la tabla de paises
            DataTable tblSiNo = ds.Tables[0];

            foreach (DataRow dr in tblSiNo.Rows)
            {
                SiNo si_no = new SiNo();
                si_no.id = Convert.ToInt32(dr["ID"]);
                si_no.valor = Convert.ToString(dr["value"]);
                resultado.Add(si_no);
            }

            return resultado;
        }
    }
}

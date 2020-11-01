using Agenda.DAL;
using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BLL
{
    public class AreaBLL
    {
        public List<Area> getAreas()
        {
            AreaDA da = new AreaDA();
            DataSet ds = da.getAreas();

            List<Area> resultado = new List<Area>();

            DataTable tblArea = ds.Tables[0];

            foreach (DataRow dr in tblArea.Rows)
            {
                Area area = new Area();
                area.id = Convert.ToInt32(dr["areaID"]);
                area.nombre = Convert.ToString(dr["name"]);
                resultado.Add(area);
            }

            return resultado;
        }
    }
}

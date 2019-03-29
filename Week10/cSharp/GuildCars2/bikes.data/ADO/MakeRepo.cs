using bikes.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bikes.models.Tables;

namespace bikes.data.ADO
{
    public class MakeRepoADO : IMakeRepo

    {
        public List<BikeMakeTable> GetAll()
        {
            List<BikeMakeTable> Makes = new List<BikeMakeTable>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
	
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        BikeMakeTable currentRow = new BikeMakeTable();
                        currentRow.BikeMakeId = (int)dr["BikeMakeId"];
                        currentRow.BikeMake = dr["BikeMake"].ToString();

                        Makes.Add(currentRow);
                    }
                }
            }
            return Makes;
        }
    }
}

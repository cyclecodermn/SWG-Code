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
    public class ModelRepoADO : IModelRepo

    {
        public List<BikeModelTable> GetAll()
        {


            List<BikeModelTable> Models = new List<BikeModelTable>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
	
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        BikeModelTable currentRow = new BikeModelTable();
                        currentRow.BikeModelId = (int)dr["BikeModelId"];
                        currentRow.BikeModel = dr["BikeModel"].ToString();

                        Models.Add(currentRow);
                    }
                }
            }
            return Models;
        }
    }
}

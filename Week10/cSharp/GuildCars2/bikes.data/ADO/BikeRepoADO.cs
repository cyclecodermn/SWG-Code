using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bikes.data.Interfaces;
using bikes.models.Tables;

namespace bikes.data.ADO
{
    public class BikeRepoADO : IBikesRepo

    {
        public BikeTable GetById(int BikeId)
        {
            BikeTable bike = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("BikeSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BikeId", BikeId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bike=new BikeTable();

                        bike.BikeModelId = (int)dr["BikeModelId"];
                        bike.BikeFrameColorId = (int)dr["BikeFrameColorId"];
                        bike.BikeTrimColorId = (int)dr["BikeTrimColorId"];
                        bike.BikeFrameId = (int)dr["BikeFrameId"];
                        bike.BikeMsrp = (decimal)dr["BikeMsrp"];
                        bike.BikeListPrice = (decimal)dr["BikeListPrice"];
                        bike.BikeYear = (int)dr["BikeYear"];

                        var intToBool = dr["BikeisNew"];
                        //bike.BikeisNew = (intToBool==1);
                        bike.BikeisNew = (bool)dr["BikeisNew"];
                        bike.BikeCondition = (int)dr["BikeCondition"];
                        bike.BikeNumGears = (int)dr["BikeNumGears"];
                        bike.BikeSerialNum = dr["BikeSerialNum"].ToString();
                        bike.BikeDescription = dr["BikeDescription"].ToString();
                        
                        if (dr["BikePictName"] != DBNull.Value)
                        bike.BikePictName = dr["BikePictName"].ToString();

                        BikeFrameTable currentRow = new BikeFrameTable();
                        currentRow.BikeFrameId = (int)dr["BikeFrameId"];
                        //currentRow.BikeFrame = dr["BikeFrame"].ToString();

                    }
                }
            }
            return bike;
        }

        public void Insert(BikeTable bike)
        {
            throw new NotImplementedException();
        }

        public void Update(BikeTable bike)
        {
            throw new NotImplementedException();
        }

        public void Delete(int BikeId)
        {
            throw new NotImplementedException();
        }
    }
}

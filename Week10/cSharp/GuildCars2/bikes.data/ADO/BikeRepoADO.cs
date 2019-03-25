﻿using System;
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
                        bike = new BikeTable();
//                        bike.BikeId = (int)dr["BikeId"];
                        bike.BikeMakeId = (int)dr["BikeMakeId"];
                        bike.BikeModelId = (int)dr["BikeModelId"];
                        bike.BikeFrameColorId = (int)dr["BikeFrameColorId"];
                        bike.BikeTrimColorId = (int)dr["BikeTrimColorId"];
                        bike.BikeFrameId = (int)dr["BikeFrameId"];
                        bike.BikeMsrp = (decimal)dr["BikeMsrp"];
                        bike.BikeListPrice = (decimal)dr["BikeListPrice"];
                        bike.BikeYear = (int)dr["BikeYear"];

                        var intToBool = dr["BikeisNew"];
                        //bike.BikeisNew = (intToBool==1);
                        bike.BikeIsNew = (bool)dr["BikeisNew"];
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
            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("BikeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@BikeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                //cmd.Parameters.AddWithValue("@BikeId", bike.BikeId);
                cmd.Parameters.AddWithValue("@BikeMakeId", bike.BikeMakeId);
                cmd.Parameters.AddWithValue("@BikeModelId", bike.BikeModelId);
                cmd.Parameters.AddWithValue("@BikeFrameColorId", bike.BikeFrameColorId);
                cmd.Parameters.AddWithValue("@BikeTrimColorId", bike.BikeTrimColorId);
                cmd.Parameters.AddWithValue("@BikeFrameId", bike.BikeFrameId);
                cmd.Parameters.AddWithValue("@BikeMsrp", bike.BikeMsrp);
                cmd.Parameters.AddWithValue("@BikeListPrice", bike.BikeListPrice);
                cmd.Parameters.AddWithValue("@BikeYear", bike.BikeYear);
                cmd.Parameters.AddWithValue("@BikeIsNew", bike.BikeIsNew);
                cmd.Parameters.AddWithValue("@BikeDateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@BikeCondition", bike.BikeCondition);
                cmd.Parameters.AddWithValue("@BikeNumGears", bike.BikeNumGears);
                cmd.Parameters.AddWithValue("@BikeSerialNum", bike.BikeSerialNum);
                cmd.Parameters.AddWithValue("@BikeDescription", bike.BikeDescription);
                cmd.Parameters.AddWithValue("@BikePictName", bike.BikePictName);

                cn.Open();
                cmd.ExecuteNonQuery();
                bike.BikeId = (int) param.Value;


            }
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

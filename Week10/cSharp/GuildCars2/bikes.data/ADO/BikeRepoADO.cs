using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bikes.data.Interfaces;
using bikes.models.Queries;
using bikes.models.Tables;

namespace bikes.data.ADO
{
    public class BikeRepoADO : IBikesRepo

    {
        public InvDetailedItem GetById(int BikeId)
        {
            InvDetailedItem bike = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("OneBikeDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BikeId", BikeId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bike = new InvDetailedItem();
                        //                        bike.BikeId = (int)dr["BikeId"];
                        bike.BikeMake = (string)dr["BikeMake"];
                        bike.BikeModel = (string)dr["BikeModel"];
                        bike.FrameColor = (string)dr["FrameColor"];
                        bike.TrimColor = (string)dr["TrimColor"];
                        bike.BikeFrame = (string)dr["BikeFrame"];
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

                        //InvDetailedItem currentRow = new InvDetailedItem();
                        //currentRow.BikeFrame = (string)dr["BikeFrame"];
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
                bike.BikeId = (int)param.Value;


            }
        }

        public void Update(BikeTable bike)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("BikeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BikeId", bike.BikeId);
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
            }
        }

        public void Delete(int BikeId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("BikeDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BikeId", BikeId);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<FeaturedItem> GetFeatured()
        {
            List<FeaturedItem> FeaturedBikes = new List<FeaturedItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("GetFeaturedBikes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@BikeId", BikeId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedItem row = new FeaturedItem();

                        row.FeatureId = (int)dr["FeatureId"];
                        row.BikeId = (int)dr["BikeId"];
                        row.BikeMake = (string)dr["BikeMake"];
                        row.BikeModel = (string)dr["BikeModel"];
                        row.BikeYear = (int)dr["BikeYear"];
                        row.BikeListPrice = (decimal)dr["BikeListPrice"];

                        if (dr["BikePictName"] != DBNull.Value)
                            row.BikePictName = dr["BikePictName"].ToString();
                        FeaturedBikes.Add(row);
                    }
                }
            }

            return FeaturedBikes;

        }

        public InvDetailedItem GetBikeDetails(int BikeId)
        {
            InvDetailedItem bike = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))

            {
                SqlCommand cmd = new SqlCommand("OneBikeDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BikeId", BikeId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bike = new InvDetailedItem();
                        //                        bike.BikeId = (int)dr["BikeId"];
                        //                        bike.BikeFrameColorId = (int)dr["BikeFrameColorId"];
                        //                        bike.BikeTrimColorId = (int)dr["BikeTrimColorId"];
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

                        bike.BikeMake = dr["BikeMake"].ToString();
                        bike.BikeModel = dr["BikeModel"].ToString();
                        bike.BikeFrame = dr["BikeFrame"].ToString();
                        bike.FrameColor = dr["FrameColor"].ToString();
                        bike.TrimColor = dr["TrimColor"].ToString();

                        if (dr["BikePictName"] != DBNull.Value)
                            bike.BikePictName = dr["BikePictName"].ToString();

                        BikeFrameTable currentRow = new BikeFrameTable();
                        //     currentRow.BikeFrameId = (int)dr["BikeFrameId"];
                        //currentRow.BikeFrame = dr["BikeFrame"].ToString();

                    }
                }
            }
            return bike;
        }
    }
}

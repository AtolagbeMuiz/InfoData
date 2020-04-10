using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using InfoData.Models;

namespace InfoData.DataBase
{
    public class DB
    {
        SqlConnection sqlConn = new SqlConnection("Server=.;Database=InfoData;User Id=muiz;Password=oluwadamilare;");

        //Get all Records
        public DataSet GetAllData()
        {
            SqlCommand cmd = new SqlCommand("SelectAllData", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);

            return dataset;
        }

        //Save Record
        public void InsertData(Register res)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SaveData", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", res.Name);
            cmd.Parameters.AddWithValue("@Email", res.Email);
            cmd.Parameters.AddWithValue("@Address", res.Address);
            cmd.Parameters.AddWithValue("@City", res.City);

            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        //Update Record
        public void UpdateData(Register res)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("UpdateData", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SN", res.SerialNo);
            cmd.Parameters.AddWithValue("@Name", res.Name);
            cmd.Parameters.AddWithValue("@Email", res.Email);
            cmd.Parameters.AddWithValue("@Address", res.Address);
            cmd.Parameters.AddWithValue("@City", res.City);

            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        //Get record by Serial No
        public DataSet GetDataBySN(int SN)
        {
            SqlCommand cmd = new SqlCommand("GetDataBySN", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SN", SN);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);

            return dataset;
        }

        //delete record by Serial No
        public void DeleteDataBySN(int id)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("DeleteDataBySN", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SN", id);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}
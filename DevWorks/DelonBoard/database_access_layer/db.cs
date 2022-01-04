//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;

//namespace DelonBoard.database_access_layer
//{
//    public class db
//    {
//        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DelonEmployeeProgram;Integrated Security=True");

//        //Get Employment Type List

//       public DataSet GetEmploymentType()
//        {
//            SqlCommand com = new SqlCommand("Sp_EmploymentType", con);
//            com.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter da = new SqlDataAdapter(com);
//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            return ds;
//        }

//        public DataSet GetContractDuration()
//        {
//            SqlCommand com = new SqlCommand("Sp_ContractDuration2", con);
//            com.CommandType = CommandType.StoredProcedure;
//            //com.Parameters.AddWithValue("@EmploymentType_id", eid);
//            SqlDataAdapter da = new SqlDataAdapter(com);
//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            return ds;
//        }
//    }
//}

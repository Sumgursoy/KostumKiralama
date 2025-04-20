using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace kostum_kiralama1.DAL
{
    public class accsessconnection
    {
        private readonly string _connectionString;
        public accsessconnection() 
        {
            //string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kostum_kiralama.accdb");
            //string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
           // _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\sumgu\\OneDrive\\Masaüstü\\kostum_kiralama1\\kostum_kiralama.accdb";
            _connectionString = " Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\sumgu\\OneDrive\\Masaüstü\\kostum_kiralama1(2)\\kostum_kiralama.accdb";
        }
        private OleDbConnection GetOleDbConnection()
        {
            OleDbConnection cnn=new OleDbConnection(_connectionString);
            if(cnn.State==ConnectionState.Open)
            {
                cnn.Close();
                cnn.Open();
            }
            else
            {
                cnn.Open();
            }
            return cnn; 
        }
        public OleDbCommand GetOleDbCommand()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = GetOleDbConnection();
            return cmd;
        }

    }
}

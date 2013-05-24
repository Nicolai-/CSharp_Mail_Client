using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Setting = EmailClient.Properties.Settings;
using System.Diagnostics;

namespace EmailClient
{
    class DBHandler
    {
        public DBHandler()
        {
            
            try
            {
                Debug.WriteLine("Trying to create database");
                SQLiteConnection.CreateFile(Setting.Default.db_file_name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            string sql = "CREATE TABLE mailInbox ('mail-id' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                "'sender' NVARCHAR(100) NOT NULL, " +
                "'recipient' NVARCHAR(100) NOT NULL, " +
                "bc NVARCHAR(100), " +
                "cc NVARCHAR(100), " +
                "subject NVARCHAR(500), " +
                "message NVARCHAR(500), " +
                "attachment blob);";
            Debug.WriteLine(sql);
            using (SQLiteConnection db_conn = new SQLiteConnection("Data source=" + Setting.Default.db_file_name + ";Version=3;"))
            {
                try
                {
                    db_conn.Open();
                    Debug.WriteLine("Trying to connect to DB");
                    SQLiteCommand cmd = new SQLiteCommand(sql, db_conn);
                    cmd.ExecuteNonQuery();
    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }  
                
            } 

            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}

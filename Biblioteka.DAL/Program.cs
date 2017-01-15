using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Biblioteka.DAL
{
    class Program
    {
        static string host = "80.65.65.66",
        serviceName = "etflab.db.lab.etf.unsa.ba",
        userID = "EC17455",
        password = "v6ez0w4r";

        static public OracleConnection GetConnection()
        {
            try
            {
                OracleConnection dbConnection = new OracleConnection();
                dbConnection.ConnectionString = string.Format(
                    @"Data Source=
                        (DESCRIPTION =
                                (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = 1521))
                                (CONNECT_DATA =
                                    (SERVER = DEDICATED)
                                    (SERVICE_NAME = {1})
                                )
                        )
                    ;User Id= {2}; Password= {3}; Persist Security Info=True;",
                    host, serviceName, userID, password);
                return dbConnection;
            }
            catch (Exception ex)
            {
                //log exception....
                return null;
            }
        }

        static void Main(string[] args)
        {
            //            string host = "80.65.65.66",
            //serviceName = "ETFLAB",
            //userID = "EC17455",
            //password = "v6ez0w4r";
            //string str = string.Format(
            //        @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={1})));User Id={2};Password={3};PersistSecurityInfo=True;",
            //        host, serviceName, userID, password);

            bool res;

            using (var db = new ApplicationDbContext())
            {
                res = db.Database.Exists();
                Console.WriteLine(db.Database.Connection.ConnectionString);
            }

            Console.WriteLine(res.ToString());


            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

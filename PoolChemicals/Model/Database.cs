using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PoolChemicals.Model
{
    internal class Database
    {
        private readonly string _dbPath = FileAccessHelper.GetLocalFilePath("poolLog.db3");
        private SQLiteConnection? conn;
        private string? StatusMessage;
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<LogTable>();
            // TODO: Add code to initialize the repository         
        }
        public DateTime GetMinDate()
        {
            var sql = "";
            try
            {
                Init();
                sql = "select min(Date) from poolLog";
                var results = conn.ExecuteScalar<DateTime>(sql);
                if (results.Year < 2000)
                    results = DateTime.Now;
                return results;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return DateTime.MinValue;
        }

        public DateTime GetMaxDate()
        {
            var sql = "select max(Date) from poolLog";
            try
            {
                Init();
                var results = conn.ExecuteScalar<DateTime>(sql);
                if (results.Year < 2000)
                    results = DateTime.Now;
                return results;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return DateTime.MinValue;
        }



        public string DeleteAll()
        {
            try
            {
                Init();
                conn.DeleteAll<LogTable>();
                GetAllLogs();
                return "Success";
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete logs. {0}", ex.Message);
                return StatusMessage;
            }

        }

        public string AddNewLog(LogTable logTable)
        {
            int results = 0;
            try
            {
                Init();
                //results = conn.DeleteAll<LogTable>();
                results = conn.Insert(logTable);
                return "Success";
            }
            catch (Exception ex)
            {
                return string.Format("Failed to add log. Error: {0}", ex.Message);
            }
        }

        public string AddNewLog(
            int poolId,
            int volume,
            int temp,
            double si,
            int salt,
            double fc,
            double ph,
            int al,
            int ca,
            int cya,
            int bor)

        {
            DateTime now = DateTime.Now;
            int results;
            try
            {
                Init();

                results = conn.Insert(new LogTable
                {
                    PoolId = poolId,
                    Volume = volume,
                    Tempurature = temp,
                    SaturationIndex = si,
                    Salt = salt,
                    FC = fc,
                    PH = ph,
                    Alkaline = al,
                    Calcium = ca,
                    CYA = cya,
                    Borate = bor,
                    Date = now
                });
                return "";
            }
            catch (Exception ex)
            {
                return string.Format("Failed to add log. Error: {0}", ex.Message);
            }
        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                // result = conn.Insert(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<LogTable> GetAllLogs()
        {
            var sql = "select * from resultsLog";
            List<LogTable> results;
            // var command = conn.CreateCommand();
            try
            {
                Init();
                // results = conn.Query(sql);
                //results = conn.ExecuteScalar<<LogTable>().tolist.(sql);



                results = conn.Table<LogTable>().ToList();
                var sortedDescending = results.OrderByDescending(p => p.Date)
                                                    .ToList();

                return sortedDescending; // conn.Table<LogTable>().ToList();
                // Use the Query<T> method provided by SQLiteConnection instead of ExecuteReader
                //var results = conn.Query<LogTable>(sql);
                //return results;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<LogTable>();
        }
        public string DeleteRecord(int id)
        {
            try
            {
                Init();
                conn.Delete<LogTable>(id);
                return null;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete logs. {0}", ex.Message);
                return StatusMessage;
            }
        }

    }
}

using System;
using System.Data;
using System.Diagnostics;
using System.IO;


namespace isaraerospace.assigment.dal
{
    public static class DAL_Log_Manager
    {
        static string DataPath = System.Environment.CurrentDirectory;
        public static void ErrorLog(string ex, StackFrame f)
        {

            DataSet ds = new DataSet();
            if (!Directory.Exists(DataPath + "\\ErrorLogs\\")) Directory.CreateDirectory(DataPath + "\\ErrorLogs\\");
            try
            {
                if (File.Exists(DataPath + "\\ErrorLogs\\isaraerospace.assigment.dal.xml"))
                {
                    ds.ReadXml(DataPath + "\\ErrorLogs\\isaraerospace.assigment.dal.xml");
                }
                else
                {
                    ds.Tables.Add("Log");
                    ds.Tables[0].Columns.Add("ID");
                    ds.Tables[0].Columns.Add("Date");
                    ds.Tables[0].Columns.Add("File");
                    ds.Tables[0].Columns.Add("Line");
                    ds.Tables[0].Columns.Add("Error");
                    ds.Tables[0].Columns.Add("Count");
                }

                DataRow[] r = ds.Tables[0].Select("Error = '" + ex.Replace("'", " ") + "'");
                if (r.Length > 0)
                {
                    r[0]["Count"] = int.Parse(r[0]["Count"].ToString()) + 1;
                    r[0]["Date"] = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString();
                }
                else
                {
                    ds.Tables[0].Rows.Add(
                        (ds.Tables[0].Rows.Count > 0) ? int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"].ToString()) + 1 : 1,



                        DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString(),
                         f.GetFileName(), f.GetFileLineNumber(), ex.Replace("'", " "), 1);
                }
                ds.AcceptChanges();
                ds.WriteXml(DataPath + "\\ErrorLogs\\isaraerospace.assigment.dal.xml");
            }
            catch { }
        }

    }
}

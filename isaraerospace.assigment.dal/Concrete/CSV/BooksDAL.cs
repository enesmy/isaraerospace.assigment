using isaraerospace.assigment.entities;
using System;
using System.Diagnostics;

namespace isaraerospace.assigment.dal.Concrete.CSV
{
    public class BooksDAL : AbstractDataManager<Book>
    {
    
        public override bool LoadAll()
        {
            try
            {

                AssigmentCsvSerilizer serilizer = new AssigmentCsvSerilizer("Books.csv");

                LastLoad = serilizer.LoadCsv();
               

                return true;
            }
            catch (Exception ex)
            {
                DAL_Log_Manager.ErrorLog(ex.Message, new StackTrace(new StackFrame(true)).GetFrame(0));
                return false;
            }

        }

        public override bool SaveChanges()
        {

            try
            {
                if (LastLoad == null)
                {
                    throw new NullReferenceException("You do not loaded any data!");
                }
                AssigmentCsvSerilizer serilizer = new AssigmentCsvSerilizer("Books.csv");
                serilizer.SaveToFile(LastLoad);
                return true;
            }
            catch (Exception ex)
            {
                DAL_Log_Manager.ErrorLog(ex.Message, new StackTrace(new StackFrame(true)).GetFrame(0));
                return false;
            }

        }
    }
}

using System.Collections.Generic;

namespace isaraerospace.assigment.dal.Concrete
{
    public abstract class AbstractDataManager<T> where T : class
    {

        public abstract bool LoadAll();
        public abstract bool SaveChanges();

        public List<T> LastLoad { get; set; }

    }
}
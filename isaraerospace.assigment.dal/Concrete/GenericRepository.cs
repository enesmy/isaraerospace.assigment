
using isaraerospace.assigment.dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace isaraerospace.assigment.dal.Concrete
{
    public class GenericRepository<T> : IGenericDataRepository<T> where T : class
    {

        AbstractDataManager<T> mng;

        public GenericRepository(AbstractDataManager<T> mng)
        {
            this.mng = mng;
        }

        public void Add(T item)
        {
            var list = GetAll();
            list.Add(item);
        }


        public IList<T> GetAll()
        {
            mng.LoadAll();
            return mng.LastLoad;


        }

        public IList<T> GetList(Func<T, bool> navigationProperty)
        {

           mng.LoadAll();

            return mng.LastLoad.Where(navigationProperty).ToList();

        }



        public T GetSingle(Func<T, bool> navigationProperty)
        {
           mng.LoadAll();
            return mng.LastLoad.Where(navigationProperty).FirstOrDefault();

        }


        public void Remove(T obj)
        {
           mng.LoadAll();

            mng.LastLoad.Remove(obj);

        }



        public void Save()
        {
            mng.SaveChanges();
        }


    }
}

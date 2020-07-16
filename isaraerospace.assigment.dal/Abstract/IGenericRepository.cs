namespace isaraerospace.assigment.dal.Abstract
{
    using System;
    using System.Collections.Generic;


    public interface IGenericDataRepository<T> where T : class
    {
        void Add(T item);
        IList<T> GetAll();
        IList<T> GetList(Func<T, bool> navigationProperty);
        T GetSingle(Func<T, bool> navigationProperty);
        void Remove(T item);

        void Save();
    }
}


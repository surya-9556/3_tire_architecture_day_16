using DriverDALLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransportBLLibrary
{
    public interface IRepo<T>
    {
        bool Add(T t);
        bool Update(T t);
        ICollection<T> GetAll();
    }

    public interface IRepos<F>
    {
        bool Add(F f);
        ICollection<F> GetAll();
        bool UpdateDriverStatus(F f);
        bool UpdateDriverPhone(int id,F f);

    }
}
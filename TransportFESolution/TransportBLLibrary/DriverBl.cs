using DriverDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportBLLibrary
{
    public class DriverBl : IRepos<DriverData>
    {
        DriverDAL dal;
        public DriverBl()
        {
            dal = new DriverDAL();
        }

        public bool Add(DriverData f)
        {
            try
            {
                return dal.DriverAdd(f);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<DriverData> GetAll()
        {
            List<DriverData> drivers;
            try
            {
                drivers = dal.SelectAllDrivers().ToList();
                return drivers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       

        public bool UpdateDriverStatus(DriverData f)
        {
            try
            {
               return dal.UpdateDriverStatus(f);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateDriverPhone(int id,DriverData f)
        {
            try
            {
                return dal.UpdateDriverPhone(f);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

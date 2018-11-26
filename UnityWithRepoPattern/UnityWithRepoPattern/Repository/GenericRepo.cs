using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnityWithRepoPattern.Interface;
using UnityWithRepoPattern.Models;

namespace UnityWithRepoPattern.Repository
{
    public class GenericRepo<T> : _IGenericRepo<T> where T : class
    {

        private ProjectDataEntities _context;

        private IDbSet<T> dbentity;

        public GenericRepo()
        {
            _context = new ProjectDataEntities();
            dbentity = _context.Set<T>();
        }

        public T FindbyID(int modelID)
        {
            return dbentity.Find(modelID);
        }

        public IEnumerable<T> GetAll()
        {
            return dbentity.ToList();
        }

        public void Insert(T model)
        {
            dbentity.Add(model);
        }

        public void Remove(int modelID)
        {
            T model = dbentity.Find(modelID);
            dbentity.Remove(model);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
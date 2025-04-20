using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Model.Shaerd;
using MVCCompanyDataAccess.Repo.InterfaceRepo;

namespace MVCCompanyDataAccess.Repo.ClassRepo
{
    public class GenricRepo<TEntity>(Contexts.AppContext context) : IGenricRepo<TEntity> where TEntity : BaseClass
    {
        private readonly Contexts.AppContext _context = context;
    
            //Contain CRUP oprations
            //Create      [Add]
            //Read        [GetByID]
            //Update      [Edit]
            //Delete      [Delete]
            //GetAll      [GetAll]

           //GET ALL
           //
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _context.Set<TEntity>().Where(e=>e.IsDeleted!=true).ToList();
            }
            else
            {
                    return _context.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();
            }
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>()
                .Where(e => e.IsDeleted != true)
                .Where(filter).ToList();
        }
        
        
        //GET BY ID
        public TEntity? GetByID(int id)
        {

            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        //Add [Create]
        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        //Update
        public int Edit(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            return _context.SaveChanges();
        }
        //Delete
        public int Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        
    }
}

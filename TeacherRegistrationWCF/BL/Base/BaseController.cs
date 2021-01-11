using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomTypes;

namespace BL.Base
{
    public abstract class BaseController<TEntity> : IController<TEntity>
        where TEntity : class, new()
    {
        #region Abstract Members
        public abstract Task<List<TEntity>> GetList(long id);
        protected abstract ActionResult GetErrorMessage(Exception ex, ActionResult result);
        #endregion

        #region Private Members
        private ActionResult GetEntityException(ActionResult result, System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            result.Success = false;
            result.ErrorMessage = ex.EntityValidationErrors.SelectMany(s => s.ValidationErrors)
                                    .Select(s => s.ErrorMessage).ToList();
            return result;
        }
        private Exception FindInnerException(Exception ex)
        {
            if (ex.InnerException != null)
                return FindInnerException(ex.InnerException);
            return ex;
        }
        private ActionResult TranslateException(Exception ex, ActionResult result)
        {
            result.Success = false;

            if (ex is System.Data.Entity.Validation.DbEntityValidationException)
            {
                return GetEntityException(result, (ex as System.Data.Entity.Validation.DbEntityValidationException));
            }

            if (ex is System.Data.Entity.Infrastructure.DbUpdateException)
            {
                Exception sqlException = FindInnerException(ex);
                if (sqlException is System.Data.SqlClient.SqlException)
                {
                    result = GetErrorMessage((sqlException as System.Data.SqlClient.SqlException), result);
                }
                return result;
            }


            //if ((ex is InvalidOperationException) && (ex.Source == "EntityFramework") && ex.Message.Contains("foreign-key"))
            //{
            //    result.ErrorMessage.Add("به دلیل وجود رابطه با این داده، امکان حذف وجود ندارد");
            //    return result;
            //}
            result = GetErrorMessage(ex, result);


            //result.ErrorMessage.Add(ex.Message);
            return result;
        }
        #endregion

        #region Protected Members
        protected DAL.TeacherRegistrationContext _context;
        #endregion

        #region Constructores
        public BaseController()
        {
            _context = new DAL.TeacherRegistrationContext();
        }
        #endregion


        #region properties
        public System.Data.Entity.DbSet<TEntity> EntityCollection

        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        #endregion

        #region CRUD
        protected virtual ActionResult BeforeCreate(TEntity instance)
        {
            return new ActionResult() { Success = true, ErrorMessage = new List<string>() };
        }
        protected virtual ActionResult BeforeDelete(TEntity instance)
        {
            return new ActionResult() { Success = true, ErrorMessage = new List<string>() };
        }
        protected virtual ActionResult BeforeEdit(TEntity instance)
        {
            return new ActionResult() { Success = true, ErrorMessage = new List<string>() };
        }
        public async Task<ActionResult> Create(TEntity instance)
        {
            ActionResult result = BeforeCreate(instance);
            try
            {

                if (!result.Success)
                    return result;

                EntityCollection.Add(instance);
                await _context.SaveChangesAsync();
                return result;
            }

            catch (Exception ex)
            {
                return TranslateException(ex, result);
            }
        }

        public async Task<ActionResult> Delete(TEntity instance)
        {
            ActionResult result = BeforeDelete(instance);
            try
            {
                if (!result.Success)
                    return result;
                //EntityCollection.Remove(instance);
                _context.Entry(instance).State = System.Data.Entity.EntityState.Deleted;
                
                await _context.SaveChangesAsync();
                return result;
            }

            catch (Exception ex)
            {
                return TranslateException(ex, result);
            }
        }

        public async Task<ActionResult> Edit(TEntity instance)
        {
            ActionResult result = BeforeEdit(instance);
            try
            {
                if (!result.Success)
                    return result;
                _context.Entry(instance).State = System.Data.Entity.EntityState.Modified;
                //_context.SaveChanges();
                await _context.SaveChangesAsync();
                return result;
            }

            catch (Exception ex)
            {
                return TranslateException(ex, result);
            }
        }

        public async Task<List<TEntity>> GetList()
        {
            return  EntityCollection.ToList();
        }

      
        
        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Data;

namespace Services
{
    public class BusinessEntityServices
    {
        private AeroEntities db = new AeroEntities();

        public string AddBusinessEntity(BusinessEntity aBusinessEntity)
        {
            aBusinessEntity.SMTPPort = 1;
            aBusinessEntity.CreatedOnUtc = DateTime.Now;
            aBusinessEntity.Deleted = false;
            using (var dbTran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Entry(aBusinessEntity).State = EntityState.Added;
                    db.SaveChanges();
                    dbTran.Commit();
                    return "BusinessEntity Add Successfully!!";
                }
                catch (Exception e)
                {
                    dbTran.Rollback();
                    return "BusinessEntity Add Failed!!";
                }
            }
        }

        public string UpdateBusinessEntity(BusinessEntity aBusinessEntity)
        {
            var bBusinessEntity = db.BusinessEntities.Find(aBusinessEntity.BusinessId);
            if (bBusinessEntity == null) return "BusinessEntity not Found";

            bBusinessEntity.Code = aBusinessEntity.Code;
            bBusinessEntity.Email = aBusinessEntity.Email;
            bBusinessEntity.Name = aBusinessEntity.Name;
            bBusinessEntity.Street = aBusinessEntity.Street;
            bBusinessEntity.City = aBusinessEntity.City;
            bBusinessEntity.State = aBusinessEntity.State;
            bBusinessEntity.Zip = aBusinessEntity.Zip;
            bBusinessEntity.Country = aBusinessEntity.Country;
            bBusinessEntity.Mobile = aBusinessEntity.Mobile;
            bBusinessEntity.Phone = aBusinessEntity.Phone;
            bBusinessEntity.ContactPerson = aBusinessEntity.ContactPerson;
            bBusinessEntity.ReferredBy = aBusinessEntity.ReferredBy;
            bBusinessEntity.Logo = aBusinessEntity.Logo;
            bBusinessEntity.Street = aBusinessEntity.Street;
            bBusinessEntity.Balance = aBusinessEntity.Balance;
            bBusinessEntity.LoginUrl = aBusinessEntity.LoginUrl;
            bBusinessEntity.SecurityCode = aBusinessEntity.SecurityCode;
            bBusinessEntity.SMTPServer = aBusinessEntity.SMTPServer;
            bBusinessEntity.SMTPPort = aBusinessEntity.SMTPPort;
            bBusinessEntity.SMTPUsername = aBusinessEntity.SMTPUsername;
            bBusinessEntity.SMTPPassword = aBusinessEntity.SMTPPassword;
            bBusinessEntity.CreatedOnUtc = aBusinessEntity.CreatedOnUtc;
            bBusinessEntity.UpdatedOnUtc = aBusinessEntity.UpdatedOnUtc;
            bBusinessEntity.CurrentBalance = aBusinessEntity.CurrentBalance;
            bBusinessEntity.Status = aBusinessEntity.Status;
            bBusinessEntity.UpdatedOnUtc = DateTime.Now;

            using (var dbTran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Entry(bBusinessEntity).State = EntityState.Modified;
                    db.SaveChanges();
                    dbTran.Commit();
                    return "BusinessEntity Update Successfully!!";
                }
                catch (Exception e)
                {
                    dbTran.Rollback();
                    return "BusinessEntity Update Failed!!";
                }
            }
        }

        public string DeleteBusinessEntity(int id)
        {
            var aBusinessEntity = db.BusinessEntities.Find(id);
            if (aBusinessEntity == null) return "DeleteBusiness not Found";

            aBusinessEntity.Deleted = true;
            using (var dbTran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Entry(aBusinessEntity).State = EntityState.Modified;
                    db.SaveChanges();
                    dbTran.Commit();
                    return "DeleteBusiness Delete Successfully!!";
                }
                catch (Exception e)
                {
                    dbTran.Rollback();
                    return "DeleteBusiness Delete Failed!!";
                }
            }
        }

        public BusinessEntity GetBusinessEntity(int id)
        {
            return db.BusinessEntities.Find(id);
        }

        public List<BusinessEntity> GetAllBusinessEntity()
        {
            return db.BusinessEntities.Where(m => !m.Deleted).ToList();
        }
    }
}

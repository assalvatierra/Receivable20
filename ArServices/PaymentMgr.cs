using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels;
using ArInterfaces;
using ArModels.Models;
using System.Data.Entity.Core;

namespace ArServices
{
    public class PaymentMgr : iPaymentMgr
    {
        private ArDBContainer db;
        public PaymentMgr()
        {
            db = new ArDBContainer();
        }

        public PaymentMgr(ArDBContainer arDB)
        {
            db = arDB;
        }
        public bool AddPayment(ArPayment payment)
        {
            try
            {
                if (payment != null)
                {
                    db.ArPayments.Add(payment);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Payment");
            }
        }

        public bool DbDispose()
        {
            try
            {
                db.Dispose();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Dispose Db");
            }
           
        }

        public bool EditPayment(ArPayment payment)
        {
            try
            {
                if (payment != null)
                {
                    db.Entry(payment).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Edit Payment");
            }
        }

        public ArPayment GetPaymentById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }

                return db.ArPayments.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Payment by Id");
            }
        }

        public List<ArPayment> GetPayments()
        {
            try
            {
                return db.ArPayments.ToList();
            }
            catch
            {
                //return new List<ArPayment>();

                throw new EntitySqlException("Services: Unable to Get Payments");
            }
        }

        public IEnumerable<ArPaymentType> GetPaymentTypes()
        {
            try
            {
                return db.ArPaymentTypes.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Payments Types");
            }
        }

        public bool RemovePayment(int? id)
        {
            try
            {
                if(id == null)
                {
                    return false;
                }

                ArPayment payment = GetPaymentById(id);
          
                if (payment != null)
                {
                    db.ArPayments.Remove(payment);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
                throw new EntitySqlException("Services: Unable to Remove Payment");
            }
        }

        public bool UpdateDeposit(int id, bool status)
        {
            try
            {
                var payment = GetPaymentById(id);

                if (payment == null)
                {
                    return false;
                }

                if (payment.ArPaymentTypeId != 3)
                {
                    payment.IsDeposited = true;
                    payment.DtDeposit = GetCurrentDate();
                }

                return EditPayment(payment);

            }
            catch
            {
                throw new NotImplementedException();
            }

        }


        public bool UpdateTransDeposit(int id, bool status)
        {
            try
            {
                var arTrans = db.ArTransactions.Find(id);

                if (arTrans == null)
                {
                    return false;
                }

                if (arTrans.ArTransPayments.Count == 0)
                {
                    return false;
                }

                foreach (var payment in arTrans.ArTransPayments.ToList())
                {
                    UpdateDeposit(payment.ArPaymentId, status);
                }

                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        private DateTime GetCurrentDate()
        {
            DateTime _localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"));
            _localTime = _localTime.Date;

            return _localTime;
        }
    }
}

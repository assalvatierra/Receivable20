﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;

namespace ArServices
{
    public class TransactionMgr : iTransactionMgr
    {
        private ArDBContainer db;
        private DateClassMgr dateClassMgr;

        public TransactionMgr()
        {
            db = new ArDBContainer();
            this.dateClassMgr = new DateClassMgr();
        }

        public TransactionMgr(ArDBContainer arDB)
        {
            this.db = arDB;
            this.dateClassMgr = new DateClassMgr();
        }

        public bool AddTransaction(ArTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    db.ArTransactions.Add(transaction);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch 
            {
                throw new EntitySqlException("Services: Unable to Add Transaction");
            }
        }

        public bool CheckRepeatingTrans()
        {
            //try
            //{
                //get transactions with null next
                var repeatingTransList = db.ArTransactions.Where(c => c.NextRef == null && c.IsRepeating == true ).ToList();

                if (repeatingTransList == null)
                {
                    return false;
                }
                else
                {
                    var today = dateClassMgr.GetCurrentDateTime();
                    foreach (var trans in repeatingTransList)
                    {
                        //repeat after interval from invoice date
                        var transDate = trans.DtInvoice;
                        var intervalDate = transDate.AddDays(trans.Interval);

                        //check if today is later then intervalDate
                        if (DateTime.Compare(today, intervalDate) > 0)
                        {
                            //create new transaction
                            //reset status
                            ArTransaction newTrans = new ArTransaction();
                            newTrans.NextRef = null;
                            newTrans.ArTransStatusId = 1;
                            newTrans.DtEncoded = today;
                            newTrans.DtDue = intervalDate;
                            newTrans.DtInvoice = intervalDate;
                            this.AddTransaction(newTrans);

                            //update existing transaction
                            //attach new transaction as reference
                            trans.NextRef = newTrans.Id;
                            this.EditTransaction(trans);
                        }
                    }

                    return true;
                }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //    throw new EntitySqlException("Services: Check repeating transactions");
            //}
        }

        public bool CloseTransactionStatus(int id)
        {
            try
            {
                var transaction = GetTransactionById(id);

                if (transaction == null)
                {
                    return false;
                }

                transaction.ArTransStatusId = 3; // close

                return EditTransaction(transaction);

            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Transaction");
            }
        }

        public bool EditTransaction(ArTransaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return false;
                }

                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Edit Transaction");
            }
        }

        public List<ArTransaction> GetActiveTransactions()
        {
            try
            {
                return GetTransactions().Where(t => t.ArTransStatusId != 6).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Active Transaction");
            }
        }


        public List<ArTransaction> GetApprovedTransactions()
        {
            try
            {
                return GetTransactions().Where(t => t.ArTransStatusId > 2 && t.ArTransStatusId < 6).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Approved Transaction");
            }
        }

        public List<ArTransaction> GetForApprovalTrans()
        {
            try
            {
                return GetTransactions().Where(t => t.ArTransStatusId == 2).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get For Approval Transaction");
            }
        }

        public List<ArTransaction> GetForSettlementTrans()
        {
            try
            {
                return GetTransactions().Where(t => t.ArTransStatusId == 5).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get For Settlement Transaction");
            }
        }

        public int GetTransAccountId(int id)
        {
            try
            {
                return GetTransactionById(id).ArAccountId;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Account ");
            }
        }

        public ArTransaction GetTransactionById(int id)
        {
            try
            {
                return db.ArTransactions.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction by Id ");
            }
        }

        public List<ArTransaction> GetTransactions()
        {
            try
            {
                return db.ArTransactions.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
                throw new EntitySqlException("Services: Unable to Get Transactions ");
            }
        }

        public List<ArTransaction> GetTransactions(string status)
        {
            try
            {
                var transactions = GetTransactions();
                if (!String.IsNullOrWhiteSpace(status))
                {
                    transactions = transactions.Where(t => t.ArTransStatu.Status == status).ToList();
                }

                return transactions.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
                throw new EntitySqlException("Services: Unable to Get Transactions with filter ");
            }
        }

        public List<ArTransaction> GetTransactions(string status, string sortBy, string orderBy)
        {
            try
            {
                var transactions = GetTransactions();
                if (!String.IsNullOrWhiteSpace(status))
                {
                    transactions = transactions.Where(t => t.ArTransStatu.Status == status).ToList();
                }
                else
                {
                    transactions = transactions.Where(t => t.ArTransStatu.Status != "Closed").ToList();
                }

                if (!String.IsNullOrWhiteSpace(sortBy))
                {

                    if (!String.IsNullOrWhiteSpace(orderBy) && orderBy == "DESC")
                    {
                        switch (sortBy)
                        {
                            case "InvoiceDate":
                                transactions = transactions.OrderByDescending(t => t.DtInvoice).ToList();
                                break;
                            case "Amount":
                                transactions = transactions.OrderByDescending(t => t.Amount).ToList();
                                break;
                            case "DueDate":
                                transactions = transactions.OrderByDescending(t => t.DtDue).ToList();
                                break;
                            default:
                                transactions = transactions.OrderByDescending(t => t.DtDue).ToList();
                                break;
                        }
                    }
                    else
                    {
                        switch (sortBy)
                        {
                            case "InvoiceDate":
                                transactions = transactions.OrderBy(t => t.DtInvoice).ToList();
                                break;
                            case "Amount":
                                transactions = transactions.OrderBy(t => t.Amount).ToList();
                                break;
                            case "DueDate":
                                transactions = transactions.OrderBy(t => t.DtDue).ToList();
                                break;
                            default:
                                transactions = transactions.OrderBy(t => t.DtDue).ToList();
                                break;
                        }
                    }
                }
                else
                {
                    transactions = transactions.OrderBy(t => t.DtDue).ToList();
                }


                return transactions.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
                throw new EntitySqlException("Services: Unable to Get Transactions with and filter sortBy");
            }
        }

        public IEnumerable<ArTransStatus> GetTransactionStatus()
        {
            try
            {
                return db.ArTransStatus.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Status ");
            }
        }

        public bool IsClosed(int id)
        {
            try
            {
                var transaction = GetTransactionById(id);

                if (transaction.ArTransStatusId == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Closed Status ");
            }
        }

        public bool RemoveTransaction(ArTransaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return false;
                }

                db.ArTransactions.Remove(transaction);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Remove Transaction ");
            }
        }

        public bool UpdateTransAcc(int transactionId, int accountId)
        {
            try
            {
                if (transactionId != 0)
                {
                    //get transaction
                    ArTransaction transaction = GetTransactionById(transactionId);
                    //edit transaction account id
                    transaction.ArAccountId = accountId;
                    //update transaction
                    return EditTransaction(transaction);
                }
                return false;
            }
            catch 
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Account ");
            }
        }
    }
}

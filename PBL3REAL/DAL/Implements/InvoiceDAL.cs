﻿
using HotelManagement.Extention;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PBL3REAL.DAL.Interfaces;
using PBL3REAL.Model;
using PBL3REAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PBL3REAL.DAL
{
    public class InvoiceDAL : IInvoiceDAL
    {
      
        public InvoiceDAL() {}
        
        public List<Invoice> FindByProperties(int start , int length ,string bookCode, string invCode, CalendarVM searchByDate , string orderBy)
        {
            var predicate = PredicateBuilder.True<Invoice>();
            if (!string.IsNullOrEmpty(invCode)) predicate = predicate.And(x => x.InvCode.Contains(invCode));
            if (!string.IsNullOrEmpty(bookCode)) predicate = predicate.And(x => x.InvIdbookNavigation.BookCode.Contains(bookCode));
            if(searchByDate!=null) predicate = predicate.And(x => x.InvCreatedate >= searchByDate.fromDate && x.InvCreatedate <= searchByDate.toDate);
            IQueryable<Invoice> query = AppDbContext.Instance.Invoices
                               .Where(predicate);
            switch (orderBy)
            {
                case "None": break;
                case "Total Price Asc": query = query.OrderBy(x => x.TotalPrice); break;
                case "Total Price Desc": query = query.OrderByDescending(x => x.TotalPrice); break;
                default: break;
            }

            List<Invoice> list = query.Skip(start).Take(length).AsNoTracking().ToList();
            return list;
        }

        public Invoice FindById(int idinvoice)
        {
            Invoice result = (from inv in AppDbContext.Instance.Invoices
                                  join book in AppDbContext.Instance.Bookings on inv.InvIdbook equals book.IdBook
                                  join client in AppDbContext.Instance.Clients on book.BookIdclient equals client.IdClient
                                  join user in AppDbContext.Instance.Users on book.BookIduser equals user.IdUser
                                  where inv.IdInvoice == idinvoice
                                  select new Invoice()
                                  {
                                      IdInvoice = inv.IdInvoice,
                                      InvCreatedate = inv.InvCreatedate,
                                      InvUpdatedate = inv.InvUpdatedate,
                                      TotalPrice = inv.TotalPrice,
                                      InvCode = inv.InvCode,
                                      InvStatus = inv.InvStatus,
                                      InvIdbookNavigation = new Booking
                                      {
                                          IdBook = book.IdBook,
                                          BookCheckindate = book.BookCheckindate,
                                          BookBookdate = book.BookBookdate,
                                          BookCheckoutdate = book.BookCheckoutdate,
                                          BookCode = book.BookCode,
                                          BookIdclientNavigation = new Client()
                                          {
                                              /*  IdClient = client.IdClient,*/
                                              CliCode = client.CliCode,
                                              CliName = client.CliName,
                                              CliGmail = client.CliGmail,
                                              CliPhone = client.CliPhone
                                          },
                                          BookIduserNavigation = new User()
                                          {
                                          
                                              UserCode = user.UserCode
                                          }
                                      }
                                  }).AsNoTracking().FirstOrDefault();
            return result;               
        }


        public int Add(Invoice invoice)
        {
            int trackedID = 0;
            invoice.InvCreatedate = DateTime.Now;
            invoice.InvUpdatedate = DateTime.Now;
            AppDbContext.Instance.Invoices.Add(invoice);
            AppDbContext.Instance.SaveChanges();
            trackedID = invoice.IdInvoice;
            AppDbContext.Instance.Entry(invoice).State = EntityState.Detached;
            return trackedID;
        }

        public void Delete(int idInvoice)
        {
            Invoice invoice = AppDbContext.Instance.Invoices.AsNoTracking().SingleOrDefault(x => x.IdInvoice == idInvoice);
            AppDbContext.Instance.Remove(invoice);
            AppDbContext.Instance.SaveChanges();
            AppDbContext.Instance.Entry(invoice).State = EntityState.Detached;
        }


        public int GetTotalRow(string code , CalendarVM searchByDate)
        {
            var predicate = PredicateBuilder.True<Invoice>();
            if (!string.IsNullOrEmpty(code)) predicate = predicate.And(x => x.InvCode.Contains(code));
            predicate = predicate.And(x => x.InvCreatedate >= searchByDate.fromDate && x.InvCreatedate <= searchByDate.toDate);
            int result = AppDbContext.Instance.Invoices.Where(predicate).Count();
            return result;
        }

        public List<Statistic1> FindForStatistic(DateTime fromDate, DateTime toDate)
        {
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@pa1";
            parameter1.SqlDbType = SqlDbType.DateTime2;
            parameter1.Value = DateTime.Parse(fromDate.ToString("yyyy/MM/dd"));

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@pa2";
            parameter2.SqlDbType = SqlDbType.DateTime2;
            parameter2.Value = DateTime.Parse(toDate.ToString("yyyy/MM/dd"));


            List<Statistic1> list = new List<Statistic1>();
            using (var command = AppDbContext.Instance.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "exec [Statistic_INV] @fromDate =@pa1, @toDate=@pa2";
                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                AppDbContext.Instance.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        list.Add(new Statistic1 { 
                            TotalPriceByDate = (int)result[0],
                            TotalInvoiceByDate = (int) result[1],
                            Date = (DateTime)result[2]
                        }); ;
                    }
                }
            }
            return list;
        }

       public List<Statistic2> FindForStatistic2(DateTime fromDate, DateTime toDate)
        {
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@pa1";
            parameter1.SqlDbType = SqlDbType.DateTime2;
            parameter1.Value = DateTime.Parse(fromDate.ToString("yyyy/MM/dd"));

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@pa2";
            parameter2.SqlDbType = SqlDbType.DateTime2;
            parameter2.Value = DateTime.Parse(toDate.ToString("yyyy/MM/dd"));


            List<Statistic2> list = new List<Statistic2>();
            using (var command = AppDbContext.Instance.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "exec [Statistic2] @fromDate =@pa1, @toDate=@pa2";
                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                AppDbContext.Instance.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Statistic2 statistic2 = list.Find(x => x.Date.Equals(DateTime.Parse(result[0].ToString())));
                        if(statistic2 != null)
                        {
                            statistic2.TotalGroupBy.Add(result[1].ToString(), (int)result[2]);
                        }
                        else
                        {
                            statistic2 = new Statistic2();
                            statistic2.Date = (DateTime)result[0];
                            statistic2.TotalGroupBy.Add(result[1].ToString(),(int) result[2]);
                            list.Add(statistic2);
                        }
                      
                    }
                }
            }
            return list;
        }

        public int Update(Invoice t)
        {
            throw new NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }
    }
}

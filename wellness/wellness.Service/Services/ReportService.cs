using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Report;
using wellness.Service.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wellness.Service.Services
{
    public class ReportService : CrudService<Report, Database.Report, BaseSearchObject, ReportPostRequest, ReportPostRequest>, IReportService
    {
        private readonly Database.DbWellnessContext _context;
        public ReportService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
        }


        public override IQueryable<Database.Report> AddInclude(IQueryable<Database.Report> query, BaseSearchObject? search = null)
        {
            query=query.Include("MemberShipType");
            return base.AddInclude(query, search);
        }


        public override Task BeforeInsert(Database.Report entity, ReportPostRequest insert)
        {
            var fromDate = DateTime.Parse(insert.DateFrom).Date;
            var toDate = DateTime.Parse(insert.DateTo).Date;

            var transactions = _context.Transactions
                .Where(t => t.Timestamp.Date >= fromDate && t.Timestamp.Date <= toDate && t.MemberShipTypeId == insert.MemberShipTypeId)
                .ToList();

            var totalAmount = transactions.Sum(t => t.Currency == "EUR" ? t.Amount * 1.95m : t.Amount);

            var uniqueUserIds = transactions.Select(t => t.UserId).Distinct();
            var totalUser = uniqueUserIds.Count();

            entity.EarnedMoney = totalAmount;
            entity.TotalUsers = totalUser; 

            return base.BeforeInsert(entity, insert);
        }











    }
}

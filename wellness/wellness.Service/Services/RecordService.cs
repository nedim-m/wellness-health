using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Record;

using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class RecordService : CrudService<Record, Database.Record, RecordSearchObj, RecordPostRequest, RecordPostRequest>, IRecordService
    {
        private readonly Database.DbWellnessContext _context;
        public RecordService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
        }

        public override IQueryable<Database.Record> AddInclude(IQueryable<Database.Record> query, RecordSearchObj? search = null)
        {
            query=_context.Set<Database.Record>().AsQueryable().Include("User");

            return base.AddInclude(query, search);
        }
    }
}

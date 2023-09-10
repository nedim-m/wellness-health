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
        private readonly IMapper _mapper;
        public RecordService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
            _mapper=mapper;
        }

        public override IQueryable<Database.Record> AddInclude(IQueryable<Database.Record> query, RecordSearchObj? search = null)
        {
            query=_context.Set<Database.Record>().AsQueryable().Include("User");

            return base.AddInclude(query, search);
        }

        public override async Task<PagedResult<Record>> Get(RecordSearchObj? search = null)
        {
            var filteredEntity = _context.Set<Database.Record>().AsQueryable().Include("User"); 

            if (!string.IsNullOrWhiteSpace(search?.Prisutni)&& search.Prisutni=="DA")
            {
                filteredEntity=filteredEntity.Where(x => x.LeaveEntryDate==null);
            }


            var list = await filteredEntity.ToListAsync();

            var mappedList = _mapper.Map<List<Record>>(list);

            var result = new PagedResult<Record>
            {
                Result = mappedList,
                Count = mappedList.Count
            };

            return result;
        }
    }
}

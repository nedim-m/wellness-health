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
                filteredEntity=filteredEntity.Where(x => x.User.Prisutan==true && x.User.RoleId==3 && x.LeaveEntryDate==null);
            }
            else
            {
                filteredEntity=filteredEntity.Where(x => x.User.Prisutan!=true && x.User.RoleId==3);
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

        public override async Task<Record> Insert(RecordPostRequest insert)
        {

            var record = _mapper.Map<Database.Record>(insert);
            var userToUpdate = await _context.Users.FindAsync(insert.UserId);
            if(userToUpdate != null)
            userToUpdate.Prisutan=true;


            _context.Records.Add(record);



            await _context.SaveChangesAsync();


            return _mapper.Map<Record>(record);
        }

        public override async Task<Record> Update(int id, RecordPostRequest update)
        {

            var recordToUpdate = await _context.Records.FindAsync(id);
            var userToUpdate = await _context.Users.FindAsync(update.UserId);

            if(userToUpdate != null && recordToUpdate!=null)
            {
                _mapper.Map(update, recordToUpdate);
                userToUpdate.Prisutan=false;
                await _context.SaveChangesAsync();

            }

            return _mapper.Map<Record>(recordToUpdate);
        }
    }
}

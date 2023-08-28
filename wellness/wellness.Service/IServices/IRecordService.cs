using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Record;

namespace wellness.Service.IServices
{
    public interface IRecordService:ICrudService<Record,BaseSearchObject,RecordPostRequest,RecordPostRequest>
    {

    }
}

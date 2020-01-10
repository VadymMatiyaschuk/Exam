using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2.EF.Repository
{
    class CityRepository
    {
        public List<string> GetStreetsName(int cityid)
        {
            using (var ctx = new ExamContext())
            {
                var addresses = ctx.Addresses.Where(x=>x.CityId == cityid).Count();
            }

        }
    }
}

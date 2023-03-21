using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterskayaOptronApplication.DbEntity
{
    public static class DbStorage
    {
        public static MasterskayaOptronEntities DB_s { get; set; } = new MasterskayaOptronEntities();
    }
}

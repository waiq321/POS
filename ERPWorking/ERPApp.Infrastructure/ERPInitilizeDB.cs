using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ERPApp.Infrastructure
{
    class ERPInitilizeDB:DropCreateDatabaseIfModelChanges<ERPContext>
    {
        protected override void Seed(ERPContext context)
        {
            base.Seed(context);
        }
    }
}

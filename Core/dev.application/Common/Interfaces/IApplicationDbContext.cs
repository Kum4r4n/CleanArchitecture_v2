using dev.Domain.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<AppSetting> AppSettings { get; set; }
        Task<int> SaveChangesAsync(); 
    }
}

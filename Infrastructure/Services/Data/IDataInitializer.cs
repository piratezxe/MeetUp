using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.Data
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}

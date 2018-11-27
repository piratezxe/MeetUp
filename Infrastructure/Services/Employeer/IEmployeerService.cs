using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Services.Employeer
{
    public interface IEmployeerService
    {
        Task CreateEmployeer(Employer employeer);
    }
}

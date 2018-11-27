using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;

namespace PlayTogether.Infrastructure.Handler.Employer
{
    public class CreateEmployer : ICommandHandler<CreateEmployeer>
    {
        public Task HandlerAsync(CreateEmployeer command)
        {
            throw new NotImplementedException();
        }
    }
}

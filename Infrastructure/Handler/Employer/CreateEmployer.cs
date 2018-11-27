using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Employeer;

namespace PlayTogether.Infrastructure.Handler.Employer
{
    public class CreateEmployer : ICommandHandler<CreateEmpoloyeer>
    {

        public Task HandlerAsync(CreateEmpoloyeer command)
        {
            throw new NotImplementedException();
        }
    }
}

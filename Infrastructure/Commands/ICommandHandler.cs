﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Commands
{
    public interface ICommandHandler<in T> where T : ICommands
    {
        Task HandlerAsync(T command);
    }
}

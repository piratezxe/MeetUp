using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommands
        {
            //check if command is null
            //pobieranie z kontenerea ioc zarejestrowanego command handlera dla komendy
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    "Command can not be null.");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandlerAsync(command);
        }
    }
}

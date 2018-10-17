using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace PlayTogether.TestEndToEnd
{
    public abstract class TestingBase
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        protected TestingBase()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Services
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string salt, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZIMO.Services
{
    public interface IFirebaseZIMO
    {
        Task<string> LoginWithEmailPassword(string email, string password);
         Task<string> DoRegisterWithEP(string E, string P);

    }
}

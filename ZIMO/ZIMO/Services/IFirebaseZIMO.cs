using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZIMO.Models;

namespace ZIMO.Services
{
    public interface IFirebaseZIMO
    {
        //Task<FirebaseAUTH> LoginWithEmailPassword(string email, string password);
        Task<string[]> LoginWithEmailPassword(string email, string password);
        Task<string[]> DoRegisterWithEP(string E, string P);

    }
}

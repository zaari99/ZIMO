using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZIMO.Services;
using Firebase.Auth;
using Firebase;

namespace ZIMO.Droid.Interfaces
{
    public class AndroAuth : IFirebaseZIMO
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
                
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
        
      
    }
}
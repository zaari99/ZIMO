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
using Xamarin.Forms;
using ZIMO.Droid.Interfaces;

[assembly:Dependency(typeof(AndroAuth))]
namespace ZIMO.Droid.Interfaces
{
    public class AndroAuth : IFirebaseZIMO
    {
        

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;

            }
            catch (FirebaseAuthInvalidUserException notFound)
            {
                return notFound.Message;

            }
            catch (System.Exception err)
            {
                return err.Message;

            } 
        }

        public async Task<string> DoRegisterWithEP(string E, string P)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(E, P);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;

            }
            catch (FirebaseAuthInvalidUserException notFound)
            {
                return notFound.Message;

            }
            catch (System.Exception err)
            {
                return err.Message;

            }

        }
    }
}
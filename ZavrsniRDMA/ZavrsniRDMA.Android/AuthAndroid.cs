using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZavrsniRDMA.Droid;

[assembly: Dependency(typeof(AuthAndroid))]
namespace ZavrsniRDMA.Droid
{
    public class AuthAndroid : AuthHelper 
    {

        public bool IsSignIn()
        {
            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await (newUser.User.GetIdToken(false).AsAsync<GetTokenResult>());
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                ex.PrintStackTrace();
                return String.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                ex.PrintStackTrace();
                return String.Empty;
            }
        }

        public bool SignOut()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> SignUpWithEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var token = await (newUser.User.GetIdToken(false).AsAsync<GetTokenResult>());
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                ex.PrintStackTrace();
                return String.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                ex.PrintStackTrace();
                return String.Empty;
            }
        }
    }
}
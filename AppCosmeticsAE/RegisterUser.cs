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

namespace AppCosmeticsAE
{
    [Activity(Label = "RegisterUser")]
    public class RegisterUser : Activity
    {
        EditText txtUserNameNew;
        EditText txtPasswordNew;
        Button btnRegisterUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterUser); //Linea que se utiliza para mover centros de actividades o para cargar una actividad
            txtUserNameNew = FindViewById<EditText>(Resource.Id.txtUserNameNew);
            txtPasswordNew = FindViewById<EditText>(Resource.Id.txtPasswordNew);
            btnRegisterUser = FindViewById<Button>(Resource.Id.btnRegister);

            btnRegisterUser.Click += BtnRegisterUser_Click;
            // Create your application here
        }

        private void BtnRegisterUser_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!string.IsNullOrEmpty(txtUserNameNew.Text.Trim()) && !string.IsNullOrEmpty(txtPasswordNew.Text.Trim()))
                {
                    new Auxiliar().Guardar(new Login() { Id = 0, Usuario = txtUserNameNew.Text.Trim(), Password = txtPasswordNew.Text.Trim() });
                    Toast.MakeText(this, "Saved Record", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Please enter a user name and a password", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
    }

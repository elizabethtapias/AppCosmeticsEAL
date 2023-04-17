using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AppCosmeticsAE
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUserName;
        EditText txtPassword;
        Button btnLogin;
        Button btnRegister;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);

            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;

            /*user = "admin";
            password = "123";*/

        }

        private void BtnRegister_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegisterUser));
            StartActivity(i);
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            /*if (txtUserName.Text == user && txtPassword.Text == password)
            {
                Intent i = new Intent(this, typeof(Home));
                StartActivity(i);
            }
            else
            {
                Toast.MakeText(this, "Invalid username and/or password(s)", ToastLength.Long).Show();
            }*/


            try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    resultado = new Auxiliar().SelecionarUno(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    if (resultado != null)
                    {
                        txtUserName.Text = resultado.Usuario.ToString();
                        Toast.MakeText(this, "Login successfully completed", ToastLength.Short).Show();
                        var home = new Intent(this, typeof(Home));
                        home.PutExtra("username", FindViewById<EditText>(Resource.Id.txtUserName).Text);
                        StartActivity(home);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Invalid username and/or password(s)", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Username and/or password are empty", ToastLength.Long).Show();
                }

            }
            catch
            {

            }


        }

        //throw new System.NotImplementedException();
    }
}
        
    

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
    [Activity(Label = "AdmManagement")]
    public class AdmManagement : Activity
    {
        EditText txtId;
        EditText txtUserNameNew;
        EditText txtPasswordNew;

        Button btnInsertarRegistro;
        Button btnConsultarRegistro;
        Button btnEliminarRegistro;
        Button BtnActualizarRegistro;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AdmManagement);
            // Create your application here

            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtUserNameNew = FindViewById<EditText>(Resource.Id.txtUserNameNew);
            txtPasswordNew = FindViewById<EditText>(Resource.Id.txtPasswordNew);

            btnInsertarRegistro = FindViewById<Button>(Resource.Id.btnInsertarRegistro);
            btnConsultarRegistro = FindViewById<Button>(Resource.Id.btnConsultarRegistro);
            btnEliminarRegistro = FindViewById<Button>(Resource.Id.btnEliminarRegistro);
            BtnActualizarRegistro = FindViewById<Button>(Resource.Id.btnActualizarRegistro);

            btnInsertarRegistro.Click += BtnInsertarRegistro_Click;
            btnConsultarRegistro.Click += BtnConsultarRegistro_Click;
            btnEliminarRegistro.Click += BtnEliminarRegistro_Click;
            BtnActualizarRegistro.Click += BtnActualizarRegistro_Click;
        }

        private void BtnActualizarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()) && !string.IsNullOrEmpty(txtUserNameNew.Text.Trim()) && !string.IsNullOrEmpty(txtPasswordNew.Text.Trim()))
                {

                    new Auxiliar().GuardarRegistroAdm(new Login()
                    {
                        Id = int.Parse(txtId.Text.Trim()),
                        Usuario = txtUserNameNew.Text.Trim(),
                        Password = txtPasswordNew.Text.Trim(),

                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtUserNameNew.Text = "";
                    txtPasswordNew.Text = "";

                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private void BtnEliminarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    new Auxiliar().EliminarRegistroAdm(int.Parse(txtId.Text));

                    Toast.MakeText(this, "Datos eliminados exitosamente", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtUserNameNew.Text = "";
                    txtPasswordNew.Text = "";


                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un ID valido ", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private void BtnConsultarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!String.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    resultado = new Auxiliar().BuscarRegistroAdm(int.Parse(txtId.Text.Trim()));
                    if (resultado != null)
                    {
                        txtUserNameNew.Text = resultado.Usuario.ToString();
                        txtPasswordNew.Text = resultado.Password.ToString();
                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Error en la consulta, consulte con otro ID", ToastLength.Short).Show();
                        txtUserNameNew.Text = "";
                        txtPasswordNew.Text = "";
                    }


                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private void BtnInsertarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()) && !string.IsNullOrEmpty(txtUserNameNew.Text.Trim()) && !string.IsNullOrEmpty(txtPasswordNew.Text.Trim()))
                {

                    new Auxiliar().Guardar(new Login()
                    {
                        Id = int.Parse(txtId.Text.Trim()),
                        Usuario = txtUserNameNew.Text.Trim(),
                        Password = txtPasswordNew.Text.Trim(),

                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtUserNameNew.Text = "";
                    txtPasswordNew.Text = "";

                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}
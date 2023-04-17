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
    [Activity(Label = "Contact")]
    public class Contact : Activity
    {
        EditText txtId;
        EditText txtName;
        EditText txtLastName;
        EditText txtNumber;
        EditText txtEmail;
        EditText txtNeed;
        Button btnInsertarRegistro;
        Button btnConsultarRegistro;
        Button btnEliminarRegistro;
        Button BtnActualizarRegistro;


        protected override void OnCreate(Bundle savedInstanceState)
        {
             base.OnCreate(savedInstanceState);
             SetContentView(Resource.Layout.Contact);

            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            txtNumber = FindViewById<EditText>(Resource.Id.txtNumber);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtNeed = FindViewById<EditText>(Resource.Id.txtNeed);

            btnInsertarRegistro = FindViewById<Button>(Resource.Id.btnInsertarRegistro);
            btnConsultarRegistro = FindViewById<Button>(Resource.Id.btnConsultarRegistro);
            btnEliminarRegistro = FindViewById<Button>(Resource.Id.btnEliminarRegistro);
            BtnActualizarRegistro = FindViewById<Button>(Resource.Id.btnActualizarRegistro);

            btnInsertarRegistro.Click += BtnInsertarRegistro_Click;
            btnConsultarRegistro.Click += BtnConsultarRegistro_Click;
            btnEliminarRegistro.Click += BtnEliminarRegistro_Click;
            BtnActualizarRegistro.Click += BtnActualizarRegistro_Click;
            // Create your application here
        }

        private void BtnActualizarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtLastName.Text.Trim())
                    && !string.IsNullOrEmpty(txtNumber.Text.Trim()) && !string.IsNullOrEmpty(txtEmail.Text.Trim()) && !string.IsNullOrEmpty(txtNeed.Text.Trim()))
                {

                    new Auxiliar().GuardarRegistro(new contact()
                    {
                        Id = int.Parse(txtId.Text.Trim()),
                        Name = txtName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Number = txtNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Need = txtNeed.Text.Trim(),
                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtName.Text = "";
                    txtLastName.Text = "";
                    txtNumber.Text = "";
                    txtEmail.Text = "";
                    txtNeed.Text = "";

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
                    new Auxiliar().EliminarRegistro(int.Parse(txtId.Text));

                    Toast.MakeText(this, "Datos eliminados exitosamente", ToastLength.Long).Show();
                    txtName.Text = "";
                    txtLastName.Text = "";
                    txtNumber.Text = "";
                    txtEmail.Text = "";
                    txtNeed.Text = "";
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese ID valido ", ToastLength.Long).Show();
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
                contact resultado = null;
                if (!String.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    resultado = new Auxiliar().BuscarRegistro(int.Parse(txtId.Text.Trim()));
                    if (resultado != null)
                    {

                        txtName.Text = resultado.Name.ToString();
                        txtLastName.Text = resultado.LastName.ToString();
                        txtNumber.Text = resultado.Number.ToString();
                        txtEmail.Text = resultado.Email.ToString();
                        txtNeed.Text = resultado.Need.ToString();

                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "Error en la cinsulta,sonsulte otro ID", ToastLength.Short).Show();
                        txtName.Text = "";
                        txtLastName.Text = "";
                        txtNumber.Text = "";
                        txtEmail.Text = "";
                        txtNeed.Text = "";

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
                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    new Auxiliar().GuardarRegistro(new contact()
                    {
                        Id = 0,
                        Name = txtName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Number = txtNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Need = txtNeed.Text.Trim()
                    });
                    Toast.MakeText(this, "Registro Guardado", ToastLength.Long).Show();
                    txtName.Text = "";
                    txtLastName.Text = "";
                    txtNumber.Text = "";
                    txtEmail.Text = "";
                    txtNeed.Text = "";
                }
                else
                {
                    Toast.MakeText(this, "Ingrese los campos requeridos", ToastLength.Long).Show();
                }

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            var layout_home = new Intent(this, typeof(MainActivity));
            StartActivity(layout_home);
            //throw new NotImplementedException();
        }
    }
}
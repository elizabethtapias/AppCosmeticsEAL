using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;
namespace AppCosmeticsAE
{
    #region Uso de datos de un usuario
    public class Login
    {
        public Login() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { set; get; }

        [MaxLength(20)]
        public string Usuario { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }
    }
    #endregion

    #region Uso de datos para contacto
    public class contact  
    {
        public contact() { }
        [PrimaryKey, AutoIncrement] /*cuando no se quiere autoincrementar se debe quitar la palabra AutoIncrement de la clase contact en este caso 
                                     y si estoy utilizando el método guardar se debe mandar el campo y sino va a salir un error en la base de datos
                                     en la línea 70 de Contact.cs Toast.MakeText(this, "Please enter the required fields",ToastLength.Long ).Show();*/

        public int Id { set; get; }
        [MaxLength(50)]
        public string Name { set; get; }
        [MaxLength(50)]
        public string LastName { set; get; }
        [MaxLength(50)]
        public string Number { set; get; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Need { get; set; }

    }

    #endregion

    #region Manejo de datos y conexion a BD
    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;
        public Auxiliar() //Esto es un constructor
        {
            conexion = ConectarBD();
            conexion.CreateTable<Login>();
            conexion.CreateTable<contact>();
        }

        public SQLite.SQLiteConnection ConectarBD()
        {
            SQLiteConnection conexionBaseDatos;
            string nombreArchivo = "asesoria.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }

        //Selecionar 1 registro
        public Login SelecionarUno(string NombreUsuario, string ClaveUsuario)
        {
            lock (locker)
            {

                return conexion.Table<Login>().FirstOrDefault(x => x.Usuario == NombreUsuario && x.Password == ClaveUsuario);
            }
        }

        //Contactar
        public contact SendRequest(string Name)
        {
            lock (locker)
            {
                return conexion.Table<contact>().FirstOrDefault(x => x.Name == Name);
            }
        }

        //Selecionar Muchos{

        public IEnumerable<Login> SeleccionarTodo()
        {
            lock (locker)
            {
                return (from i in conexion.Table<Login>() select i).ToList();
            }
        }

        //Seleccionar todas las solicitudes 
        public IEnumerable<contact> SeleccionarTodosMensajes()
        {
            lock (locker)
            {
                return (from i in conexion.Table<contact>() select i).ToList();
            }
        }

        //Guardar
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        public int GuardarMensaje(contact registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }
        //Eliminar
        public int Eliminar(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }

        public int EliminarMensaje(string Name)
        {
            lock (locker)
            {
                return conexion.Delete<contact>(Name);
            }
        }

        //crud para contacto

        public contact BuscarRegistro(int Id)
        {
            lock (locker)
            {
                return conexion.Table<contact>().FirstOrDefault(x => x.Id == Id);
            }
        }

        public int GuardarRegistro(contact registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        public int EliminarRegistro(int Id)
        {
            lock (locker)
            {
                return conexion.Delete<contact>(Id);
            }
        }


        //crud para administrador

        public Login BuscarRegistroAdm(int Id)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.Id == Id);
            }
        }

        public int GuardarRegistroAdm(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        public int EliminarRegistroAdm(int Id)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(Id);
            }
        }
    }
    #endregion

}


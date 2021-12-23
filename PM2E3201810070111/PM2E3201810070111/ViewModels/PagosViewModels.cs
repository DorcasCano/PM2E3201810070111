using PM2E3201810070111.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PM2E3201810070111.ViewModels
{
    public class PagosViewModels : BaseViewModel
    {

        private int _id_pago;
        private string _descripcion;
        private string _monto;
        private string _fecha;
        private string _photo_recibo;

        public int Id_pago
        {
            get { return _id_pago; }
            set { _id_pago = value; OnPropertyChanged(); }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; OnPropertyChanged(); }
        }

        public string Monto
        {
            get { return _monto; }
            set { _monto = value; OnPropertyChanged(); }
        }

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; OnPropertyChanged(); }
        }

        public string Photo_recibido
        {
            get { return _photo_recibo; }
            set { _photo_recibo = value; OnPropertyChanged(); }
        }

        //lista de comandos a utilizar en pantalla
        public ICommand PantallaListadoCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand ModificarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        //
 



        //acciones ICommand 
        public async void listado()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
            /*
            Nombre = String.Empty;
            Edad = String.Empty;
            Apellido = String.Empty;
            Edad = String.Empty;
            Direccion = String.Empty;
            Puesto = String.Empty;
            */

        }

        public async void modificar()
        {

            var emp = new Models.Pagos
            {
                Id_pago = Id_pago,
                Descripcion = Descripcion,
                Monto = Monto,
                Fecha = Fecha,
                Photo_recibo = Photo_recibido
            };

            var resultado = await App.BaseDatos.GrabarPagos(emp);

            if (resultado == 1)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Advertencia", "Registro Modificado", "OK");

                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo Modificar", "OK");
            }


        }

        public async void Eliminar()
        {
            var emp = new Models.Pagos
            {
                Id_pago = Id_pago,
                Descripcion = Descripcion,
                Monto = Monto,
                Fecha = Fecha,
                Photo_recibo = Photo_recibido
            };

            var resultado = await App.BaseDatos.EliminarPagos(emp);

            if (resultado == 1)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Advertencia", "Registro eliminado", "OK");

                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo eliminar", "OK");
            }


        }

        public async void save()
        {

            var emp = new Models.Pagos
            {
                Id_pago = Id_pago,
                Descripcion = Descripcion,
                Monto = Monto,
                Fecha = Fecha,
                Photo_recibo = Photo_recibido
            };

            var resultado = await App.BaseDatos.GrabarPagos(emp);

            if (resultado == 1)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Registro exitoso!!!", "ok");
                Id_pago = 0;
                Descripcion = String.Empty;
                Monto = String.Empty;
                Fecha = String.Empty;
                Photo_recibido = String.Empty;

            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "No se Pudo Guardar", "OK");

            }

        }

        public PagosViewModels()
        {
            PantallaListadoCommand = new Command(() => listado());
            SaveCommand = new Command(() => save());
            ModificarCommand = new Command(() => modificar());
            EliminarCommand = new Command(() => Eliminar());
        }


    }
}

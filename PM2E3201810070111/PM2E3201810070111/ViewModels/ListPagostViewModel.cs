using PM2E3201810070111.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PM2E3201810070111.ViewModels
{
  public  class ListPagostViewModel: BaseViewModel
    {
        private ObservableCollection<Pagos> _empleados;

        public ObservableCollection<Pagos> EmpleadosC
        {
            get { return _empleados; }
            set { _empleados = value; OnPropertyChanged(); }
        }

        private Pagos _selectedProduct;

        public Pagos SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public ICommand GoToDetailsCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListPagostViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            cargar();

            /*

            EmpleadosC.Add(new Empleados() {id=1,  nombre="qwe",apellido="pasd",edad="21",direccion="asdasd",puesto="da" });
            EmpleadosC.Add(new Empleados() { id = 2, nombre = "qwe", apellido = "pasd", edad = "21", direccion = "asdasd", puesto = "da" });
            EmpleadosC.Add(new Empleados() { id = 3, nombre = "qwe", apellido = "pasd", edad = "21", direccion = "asdasd", puesto = "da" });
            EmpleadosC.Add(new Empleados() { id = 4, nombre = "qwe", apellido = "pasd", edad = "21", direccion = "asdasd", puesto = "da" });

            EmpleadosC.Add(new Empleados() { id = 5, nombre = "qwe", apellido = "pasd", edad = "21", direccion = "asdasd", puesto = "da" });
            */



        }

        public async void cargar()
        {
            EmpleadosC = new ObservableCollection<Pagos>();

            List<Pagos> empleado = new List<Pagos>();
            empleado = await App.BaseDatos.ObtenerListaPagos();


            for (int i = 0; i < empleado.Count; i++)
            {
                EmpleadosC.Add(new Pagos() { Id_pago = empleado[i].Id_pago, Descripcion = empleado[i].Descripcion, Monto = empleado[i].Monto, Fecha = empleado[i].Fecha, Photo_recibo = empleado[i].Photo_recibo });
            }



        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedProduct != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new PagosViewModels()
                {
                    Id_pago = SelectedProduct.Id_pago,
                    Descripcion = SelectedProduct.Descripcion,
                    Monto = SelectedProduct.Monto,
                    Fecha = SelectedProduct.Fecha,
                    Photo_recibido = SelectedProduct.Photo_recibo

                };

                await Navigation.PushAsync(page);
            }
        }
    }
}

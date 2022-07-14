using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFirmas : ContentPage
    {
        public ListFirmas()
        {
            InitializeComponent();
        }

        private void lsFirmas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listFirmas = await App.BaseDatos.ObtenerListaFirmas();
            lsFirmas.ItemsSource = listFirmas;


        }
    }
}
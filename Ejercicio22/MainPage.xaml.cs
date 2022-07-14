using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio22
{
    public partial class MainPage : ContentPage
    {
       
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           Stream  img  = await Sign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
          
           
            BinaryReader br = new BinaryReader(img);

            Byte[] bytes = br.ReadBytes((Int32)img.Length);
            string bs64 = Convert.ToBase64String(bytes,0,bytes.Length);

            try
            {
               

                var firma = new Models.SignatureModel()
                {
                    codigo = 0,
                    Singnature = bs64,
                    nombre = nombre.Text,
                    descripcion = descripcion.Text




                };

                var resultado = await App.BaseDatos.GuardarFirma(firma);

                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Ingreso Exitoso", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la ubicacion", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Agregado", ex.Message.ToString(), "OK");
            }


        }

      

        private async void Lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListFirmas());

        }
    }
}

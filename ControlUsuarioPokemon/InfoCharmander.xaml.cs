using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlUsuarioPokemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InfoCharmander : Page
    {

        MainPage padre;

        public InfoCharmander()
        {
            this.InitializeComponent();
            this.cuCharmander.VerEnergia = false;
            this.cuCharmander.VerVida = false;
            this.cuCharmander.verFondo(false);
            this.cuCharmander.CambiarVisibilidadBotones();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            padre = (MainPage)e.Parameter;
        }

        private void btn_Jugar_Click(object sender, RoutedEventArgs e)
        {
            padre.irAPagina("JugarCharmander");
            padre.NotificacionCharm(null, null);
        }
    }
}

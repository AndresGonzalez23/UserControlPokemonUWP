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
    public sealed partial class CombatePage : Page
    {
        public CombatePage()
        {
            this.InitializeComponent();
            this.combate_Oshawott1.verFondo(false);
            this.combate_Oshawott2.verFondo(false);
            this.combate_Teddiursa1.verFondo(false);
            this.combate_Teddiursa2.verFondo(false);
            this.combate_Charmander1.verFondo(false);
            this.combate_Charmander2.verFondo(false);
        }

        private void elegirOshawott1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Oshawott1.Visibility = Visibility.Visible;
        }

        private void elegirCharmander1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Charmander1.Visibility = Visibility.Visible;
        }

        private void elegirTeddiursa1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Teddiursa1.Visibility = Visibility.Visible;
        }

        private void elegirOshawott2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Oshawott2.Visibility = Visibility.Visible;
        }

        private void elegirCharmander2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Charmander2.Visibility = Visibility.Visible;
        }

        private void elegirTeddiursa2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Teddiursa2.Visibility = Visibility.Visible;
        }
    }
}

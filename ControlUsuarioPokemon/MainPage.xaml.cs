using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ControlUsuarioPokemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

        }

        private void MainPage_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var Width = ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
                sView.IsPaneOpen = true;
            }
            else if (Width >= 360)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                sView.IsPaneOpen = false;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
                sView.IsPaneOpen = false;
            }

        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(typeof(Inicio), this);
        }

        private void btnPokedex_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(typeof(PokedexPage), this);

        }

        private void btnCombate_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(typeof(CombatePage), this);
        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (frMain.BackStack.Any())
            {
                frMain.GoBack();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sView.IsPaneOpen = !sView.IsPaneOpen;
        }

        public void irAPagina(string nombrePagina)
        {
            switch (nombrePagina)
            {
                case "InfoPoke":
                    frMain.Navigate(typeof(InfoPoke), this);
                    break;
                case "InfoOsha":
                    frMain.Navigate(typeof(InfoOsha), this);
                    break;
                case "InfoCharmander":
                    frMain.Navigate(typeof(InfoCharmander), this);
                    break;
                case "JugarCharmander":
                    frMain.Navigate(typeof(JugarCharmander));
                    break;
                case "JugarOsha":
                    frMain.Navigate(typeof(JugarOsha));
                    break;
                case "JugarTeddi":
                    frMain.Navigate(typeof(JugarTeddi));
                    break;
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
          
            string lang = "en-US";

            ApplicationLanguages.PrimaryLanguageOverride = lang;

           
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

     
    }
}
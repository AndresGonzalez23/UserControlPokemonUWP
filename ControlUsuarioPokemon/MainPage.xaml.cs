using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
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
            
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "IPOkemon",
                                HintStyle = AdaptiveTextStyle.Subtitle
                            },
                            new AdaptiveText()
                            {
                                 Text = "Un proyecto de IPO2",
                                 HintStyle = AdaptiveTextStyle.CaptionSubtle
                            },
                        }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "Version 1.0",

                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                            new AdaptiveText()
                            {
                                Text = "IPOkemon",
                                HintStyle = AdaptiveTextStyle.Subtitle
                            },
                            new AdaptiveText()
                            {
                                Text = "Un Proyecto de IPO2",
                                HintStyle = AdaptiveTextStyle.CaptionSubtle
                            },
                            new AdaptiveText()
                            {
                                Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                HintWrap = true,
                            }
                        }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                            new AdaptiveText()
                            {
                                Text = "IPOkemon",
                                HintStyle = AdaptiveTextStyle.Subtitle
                            },
                            new AdaptiveText()
                            {
                                Text = "Un Proyecto de IPO2",
                                HintStyle = AdaptiveTextStyle.CaptionSubtle
                            },
                            new AdaptiveText()
                            {
                                Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                HintStyle = AdaptiveTextStyle.CaptionSubtle
                            }
                        }
                        }
                    },
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(10);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);
 
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

        public void NotificacionSubida(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText("Tu Teddiursa esta disponible")
            .AddText("Puedes ver más información en IPOkemon")
            .AddInlineImage(new Uri("ms-appx:///Assets/Teddiursa.png"))
            .AddAppLogoOverride(new Uri("ms-appx:///Assets/caraTeddi.png"),
            ToastGenericAppLogoCrop.Circle)
            .Show();

        }

        public void NotificacionOsha(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText("Tu Oshawott esta disponible")
            .AddText("Puedes ver más información en IPOkemon")
            .AddInlineImage(new Uri("ms-appx:///Assets/oshawott.png"))
            .AddAppLogoOverride(new Uri("ms-appx:///Assets/caraOsha.png"),
            ToastGenericAppLogoCrop.Circle)
            .Show();

        }

        public void NotificacionCharm(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText("Tu Charmander esta disponible")
            .AddText("Puedes ver más información en IPOkemon")
            .AddInlineImage(new Uri("ms-appx:///Assets/charmander.png"))
            .AddAppLogoOverride(new Uri("ms-appx:///Assets/caraCharm.png"),
            ToastGenericAppLogoCrop.Circle)
            .Show();

        }

        private async void pinTeddiursa(object sender, PointerRoutedEventArgs e)
        {
            SecondaryTile myTile = new SecondaryTile("Favorito", "Dos", "Tres",
            new Uri("ms-appx:///Assets/IconoPokemon.jpg"),
            Windows.UI.StartScreen.TileSize.Square150x150);
            myTile.DisplayName = "IPokemon";
            myTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await myTile.RequestCreateAsync();
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
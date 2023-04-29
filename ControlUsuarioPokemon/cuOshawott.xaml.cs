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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ControlUsuarioPokemon
{
    public sealed partial class cuOshawott : UserControl
    {
        DispatcherTimer dtTime;
        public cuOshawott()
        {
            this.InitializeComponent();
            Storyboard sbPocionRoja = (Storyboard)this.Resources["PocionRoja"];



            if (pbHealth.Value >= 50)
            {
                this.btnCansado.IsEnabled = false;
                this.btnHerido.IsEnabled = false;
            }
            else if (pbHealth.Value < 50 && pbHealth.Value >= 25)
            {
                this.btnEnergia.IsEnabled = false;
                this.btnHerido.IsEnabled = false;
                sbPocionRoja.Begin();
            }
            else if (pbHealth.Value < 25)
            {

                this.btnCansado.IsEnabled = false;
                this.btnEnergia.IsEnabled = false;
                sbPocionRoja.Begin();
            }
        }



        public double Vida
        {
            get { return this.pbHealth.Value; }
            set { this.pbHealth.Value = value; }
        }

        public double Energia
        {
            get { return this.pbPower.Value; }
            set { this.pbPower.Value = value; }
        }

        private bool verEnergia = true;
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[1].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }

        private bool verVida = true;
        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida) this.gridGeneral.RowDefinitions[0].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[0].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }

        public void verFondo(bool verFondo)
        {
            if (!verFondo) { this.imgFondo.Source = null; }
            else
            {
                this.imgFondo.Source = new BitmapImage(new Uri("ms-appx:///Assets/playa.png"));
            }
        }
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imRPotion.Opacity = 0.5;

        }

        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.2;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Opacity = 1;
            }
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbPower.Value += 0.2;
            if (pbPower.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Opacity = 1;
            }
        }

        private void btnAtacar_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbat = (Storyboard)this.Resources["Atacar"];

            Storyboard sbPocionAmarilla = (Storyboard)this.Resources["PocionAmarilla"];

            if (pbPower.Value >= 30)
            {
                sbat.Begin();

                pbPower.Value -= 10.0;

            }
            else
            {

                sbPocionAmarilla.Begin();
            }

        }

        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEnergy;
            dtTime.Start();
            this.imYPotion.Opacity = 0.5;
        }

        private void btnDefensa_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbdef = (Storyboard)this.Resources["Defender"];
            Storyboard sbener = (Storyboard)this.Resources["Enérgico"];
            Storyboard sbPocionAmarilla = (Storyboard)this.Resources["PocionAmarilla"];

            if (pbPower.Value >= 30)
            {
                sbdef.Begin();

                pbPower.Value -= 5.0;
            }
            else
            {

                sbPocionAmarilla.Begin();
            }

        }

        private void btnDescanso_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbdes = (Storyboard)this.Resources["Descansar"];



            if (pbPower.Value < 100)
            {
                sbdes.Begin();
                pbPower.Value += 10.0;
            }

        }

        private void btnEnergia_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sben = (Storyboard)this.Resources["Enérgico"];
            sben.Begin();

        }

        private void btnCansado_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbcan = (Storyboard)this.Resources["Cansado"];
            sbcan.Begin();

        }

        private void btnHerido_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbher = (Storyboard)this.Resources["Herido"];
            sbher.Begin();

        }

        public void CambiarVisibilidadBotones()
        {
            btnAtacar.Visibility = Visibility.Collapsed;
            btnDescanso.Visibility = Visibility.Collapsed;
            btnDefensa.Visibility = Visibility.Collapsed;
            btnEnergia.Visibility = Visibility.Collapsed;
            btnCansado.Visibility = Visibility.Collapsed;
            btnHerido.Visibility = Visibility.Collapsed;
            tbNombre.Visibility = Visibility.Collapsed;
        }
    }
}

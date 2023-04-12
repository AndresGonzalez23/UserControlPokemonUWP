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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ControlUsuarioPokemon
{
    public sealed partial class cuCharmander : UserControl
    {
        DispatcherTimer dtTime;
        public cuCharmander()
        {
            this.InitializeComponent();
        }
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imagenPocionS.Opacity = 0.5;
        }
        public void verFondo(bool verfondo)
        {
            if (!verfondo) { this.imFondo.Source = null; }
            else
            {

            }
        }

        private bool verEnergia = true;
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.GridMain.RowDefinitions[1].Height = new GridLength(0);
                else this.GridMain.RowDefinitions[1].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }

        public double Vida
        {
            get { return this.barraSalud.Value; }
            set { this.barraSalud.Value = value; }
        }

        public double Energia
        {
            get { return this.barraEnergia.Value; }
            set { this.barraEnergia.Value = value; }
        }

        private bool verVida = true;
        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida) this.GridMain.RowDefinitions[0].Height = new GridLength(0);
                else this.GridMain.RowDefinitions[0].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }
        private void increaseHealth(object sender, object e)
        {
            this.barraSalud.Value += 0.2;
            if (barraSalud.Value >= 100)
            {
                this.dtTime.Stop();
                this.imagenPocionS.Opacity = 1;
            }
        }

        private void nombrePokemon_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AtaqueUno(object sender, RoutedEventArgs e)
        {

            escupir();
        }
        private void escupir()
        {

            Storyboard sb = (Storyboard)this.Resources["Ataque1"];
            sb.Begin();
            this.barraEnergia.Value -= 10;
        }
        private void bolas()
        {
            Storyboard sb = (Storyboard)this.Resources["AtaqueBolas"];
            sb.Begin();
            this.barraEnergia.Value -= 10;
        }
        private void AtaqueDos(object sender, RoutedEventArgs e)
        {
            bolas();

        }

        private void subirVida()
        {
            Storyboard sb = (Storyboard)this.Resources["BeberPocionRoja"];
            sb.Begin();
            this.barraSalud.Value = 100;
        }

        private void BeberPocimaRoja(object sender, RoutedEventArgs e)
        {
            subirVida();
        }
        private void subirEnergia()
        {
            Storyboard sb = (Storyboard)this.Resources["beberPocionAmarilla"];
            sb.Begin();
            this.barraEnergia.Value = 100;
        }
        private void BeberPocimaEnergia(object sender, RoutedEventArgs e)
        {
            subirEnergia();
        }



        private void escudo()
        {
            Storyboard sb = (Storyboard)this.Resources["Protegerse"];
            sb.Begin();
        }

        private void Proteccion(object sender, RoutedEventArgs e)
        {
            escudo();
        }
        private void dormir2()
        {
            Storyboard sb = (Storyboard)this.Resources["Dormir"];
            sb.Begin();
            this.barraSalud.Value += 50;
            this.barraEnergia.Value += 50;
        }
        private void Descansar(object sender, RoutedEventArgs e)
        {
            dormir2();
        }

        private void lastimar()
        {
            Storyboard sb = (Storyboard)this.Resources["Herido"];
            sb.Begin();
            barraSalud.Value -= 20;
            if (barraSalud.Value == 0)
            {
                Storyboard sb1 = (Storyboard)this.Resources["Morir"];
                sb1.Begin();
            }

        }
        private void Herirse(object sender, RoutedEventArgs e)
        {

            lastimar();

        }
    }
}

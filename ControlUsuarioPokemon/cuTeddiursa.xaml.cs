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
    public sealed partial class cuTeddiursa : UserControl
    {
        int costeVenganza = 20;
        int costeProteccion = 10;
        int costeDescanso = 15;
        int costeMordisco = 15;
        DispatcherTimer dtReloj;
        DispatcherTimer controlTiempos;
        public cuTeddiursa()
        {
            this.InitializeComponent();
            dtReloj = new DispatcherTimer();
            controlTiempos = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(4000);
            dtReloj.Tick += usePotionRed;
            controlTiempos.Interval = TimeSpan.FromMilliseconds(4000);
            controlTiempos.Tick += useEnergyPotion;

            Storyboard sb = (Storyboard)this.Resources["MoverBrazos"];
            Storyboard sb2 = (Storyboard)this.Resources["MoverOrejas"];
            sb.AutoReverse = true;
            sb2.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb2.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
            sb2.Begin();
        }
        private void usePotionRed(object sender, object e)
        {
            imgPocionUsada.Visibility = Visibility.Collapsed;
            imgPocion.Visibility = Visibility.Visible;
            dtReloj.Stop();

        }

        private void increaseHealth(object sender, PointerRoutedEventArgs e)
        {
            PVida.Value = PVida.Value + 30;
            dtReloj.Start();
            Storyboard sb = (Storyboard)this.Resources["curarVida"];
            sb.Begin();
            imgPocion.Visibility = Visibility.Collapsed;
            imgPocionUsada.Visibility = Visibility.Visible;
        }

        private void increaseEnergy(object sender, PointerRoutedEventArgs e)
        {
            PEnergia.Value = PEnergia.Value + 20;
            if (usarEnergia(0))
            {
                controlTiempos.Start();
                Storyboard sb = (Storyboard)this.Resources["subirEnergia"];
                sb.Begin();
                imgElixir.Visibility = Visibility.Collapsed;
                imgElixirUsada.Visibility = Visibility.Visible;
            }



        }

        private void useEnergyPotion(object sender, object e)
        {
            imgElixirUsada.Visibility = Visibility.Collapsed;
            imgElixir.Visibility = Visibility.Visible;
            controlTiempos.Stop();

        }

        private void morder(object sender, PointerRoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            sb.Children.Add(da);
            sb.BeginTime = TimeSpan.FromSeconds(0);
            ptBoca.RenderTransform = (Transform)new ScaleTransform();
            Storyboard.SetTarget(da, ptBoca.RenderTransform);
            Storyboard.SetTargetProperty(da, "ScaleY");
            da.From = 1;
            da.To = 1.5;
            sb.AutoReverse = true;
            sb.RepeatBehavior = new RepeatBehavior(3);
            sb.Begin();
        }

        private void correr(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["Cosquillas"];
            sb.AutoReverse = true;
            sb.Begin();

        }

        private void usarVenganza(object sender, RoutedEventArgs e)
        {
            if (usarEnergia(costeVenganza))
            {
                Storyboard sb = (Storyboard)this.Resources["Venganza"];
                sb.Begin();
            }
        }

        private void usarProteccion(object sender, RoutedEventArgs e)
        {

            if (usarEnergia(costeProteccion))
            {
                Storyboard sb = (Storyboard)this.Resources["Protección"];
                sb.Begin();
            }
        }

        private void usarDescanso(object sender, RoutedEventArgs e)
        {
            if (usarEnergia(costeDescanso))
            {
                Storyboard sb = (Storyboard)this.Resources["Descanso"];
                sb.Begin();
                PVida.Value = PVida.Value + 20;
            }
        }

        private Boolean usarEnergia(int valorAtaque)
        {
            Storyboard sb = (Storyboard)this.Resources["Cansancio"];
            if (PEnergia.Value >= 10)
            {
                PEnergia.Value = PEnergia.Value - valorAtaque;
                if (PEnergia.Value <= 10)
                {
                    sb.Begin();
                    sb.RepeatBehavior = RepeatBehavior.Forever;
                }
                else
                {
                    sb.Stop();
                }
                return true;
            }
            return false;
        }

        private void tocarBrazoIzquierdo(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["MoverBrazos"];
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }

        private void tocarBrazoDerecho(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["MoverBrazos"];
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }

        private void usarMordisco(object sender, RoutedEventArgs e)
        {
            if (usarEnergia(costeMordisco))
            {
                Storyboard sb = (Storyboard)this.Resources["Mordisco"];
                sb.Begin();
            }
        }

        public Double Vida
        {
            get { return this.PVida.Value; }
            set { this.PVida.Value = value; }
        }

        public Double Energia
        {
            get { return this.PEnergia.Value; }
            set { this.PEnergia.Value = value; }
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
                this.imgFondo.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondoBosque.png"));
            }
        }

        public void CambiarVisibilidadBotones()
        {
            btnAtaque.Visibility = Visibility.Collapsed;
            btnDescanso.Visibility = Visibility.Collapsed; 
            btnMordisco.Visibility = Visibility.Collapsed;
            btnProteccion.Visibility = Visibility.Collapsed;
            fndNombre.Visibility = Visibility.Collapsed;
            txtNombre.Visibility = Visibility.Collapsed;
        }

        public void DesactivarCorrer(bool activar)
        {
            cvCuerpo.PointerReleased -= correr; // Desactiva el evento
            if (activar)
            {
                cvCuerpo.PointerReleased += correr; // Activa el evento
            }
        }

        public void DesactivarBrazos(bool activar)
        {
            elBrazoIzquierdo.PointerReleased -= tocarBrazoIzquierdo; // Desactiva el evento
            elipseBrazoDerecho.PointerReleased-= tocarBrazoDerecho;
            if (activar)
            {
                elBrazoIzquierdo.PointerReleased += tocarBrazoIzquierdo; // Activa el evento
                elipseBrazoDerecho.PointerReleased += tocarBrazoDerecho;
            }
        }

        public void Ataque()
        {
            Storyboard sb = (Storyboard)this.Resources["Mordisco"];
            sb.Begin();
        }
        public void Ataque2()
        {
            Storyboard sb = (Storyboard)this.Resources["Mordisco2"];
            sb.Begin();
        }

        public void Defensa()
        {
            if (usarEnergia(costeProteccion))
            {
                Storyboard sb = (Storyboard)this.Resources["Protección"];
                sb.Begin();
            }
        }

        public void Debil()
        {
            Storyboard sb = (Storyboard)this.Resources["Cansancio"];
            sb.Begin();
        }

    }
}

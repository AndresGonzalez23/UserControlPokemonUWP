using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
       
        private static int turno = 0;
        public CombatePage()
        {
            this.InitializeComponent();

            

            this.combate_Oshawott1.verFondo(false);
            this.combate_Oshawott2.verFondo(false);
            this.combate_Teddiursa1.verFondo(false);
            this.combate_Teddiursa2.verFondo(false);
            this.combate_Charmander1.verFondo(false);
            this.combate_Charmander2.verFondo(false);

            this.combate_Oshawott1.CambiarVisibilidadBotones();
            this.combate_Oshawott2.CambiarVisibilidadBotones();
            this.combate_Teddiursa1.CambiarVisibilidadBotones();
            this.combate_Teddiursa2.CambiarVisibilidadBotones();
            this.combate_Charmander1.CambiarVisibilidadBotones();
            this.combate_Charmander2.CambiarVisibilidadBotones();

            if (this.combate_Oshawott1.Vida <= 30)
            {
                this.combate_Oshawott1.Debil();
            }
            if (this.combate_Oshawott2.Vida <= 30)
            {
                this.combate_Oshawott2.Debil();
            }
            if (this.combate_Teddiursa1.Vida <= 30)
            {
                this.combate_Teddiursa1.Debil();
            }
            if (this.combate_Teddiursa2.Vida <= 30)
            {
                this.combate_Teddiursa2.Debil();
            }
            if (this.combate_Charmander1.Vida <= 30)
            {
                this.combate_Charmander1.Debil();
            }
            if (this.combate_Charmander2.Vida <= 30)
            {
                this.combate_Charmander2.Debil();
            }

        }

        private void elegirOshawott1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Oshawott1.Visibility = Visibility.Visible;
            btnAtaqueOshawott1.Visibility= Visibility.Visible;
            btnDefensaOshawott1.Visibility= Visibility.Visible;
            this.elegirCharmander1.Opacity = 0.5;
            this.elegirTeddiursa1.Opacity = 0.5;
            elegirCharmander1.PointerReleased -= elegirCharmander1_PointerReleased;
            elegirTeddiursa1.PointerReleased -= elegirTeddiursa1_PointerReleased;
        }

        

        private void elegirCharmander1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Charmander1.Visibility = Visibility.Visible;
            btnAtaqueCharmander1.Visibility= Visibility.Visible;
            btnDefensaCharmander1.Visibility= Visibility.Visible;
            this.elegirOshawott1.Opacity = 0.5;
            this.elegirTeddiursa1.Opacity = 0.5;
            elegirOshawott1.PointerReleased -= elegirOshawott1_PointerReleased;
            elegirTeddiursa1.PointerReleased -= elegirTeddiursa1_PointerReleased;
        }

        private void elegirTeddiursa1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Teddiursa1.Visibility = Visibility.Visible;
            btnAtaqueTeddiursa1.Visibility= Visibility.Visible;
            btnDefensaTeddiursa1.Visibility= Visibility.Visible;
            this.elegirCharmander1.Opacity = 0.5;
            this.elegirOshawott1.Opacity = 0.5;
            elegirCharmander1.PointerReleased -= elegirCharmander1_PointerReleased;
            elegirOshawott1.PointerReleased -= elegirTeddiursa1_PointerReleased;


        }

        private void elegirOshawott2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Oshawott2.Visibility = Visibility.Visible;
            btnAtaqueOshawott2.Visibility= Visibility.Visible;
            btnDefensaOshawott2.Visibility= Visibility.Visible;
            this.elegirCharmander2.Opacity = 0.5;
            this.elegirTeddiursa2.Opacity = 0.5;
            elegirCharmander2.PointerReleased -= elegirCharmander2_PointerReleased;
            elegirTeddiursa2.PointerReleased -= elegirTeddiursa2_PointerReleased;




        }

        private void elegirCharmander2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Charmander2.Visibility = Visibility.Visible;
            btnAtaqueCharmander2.Visibility= Visibility.Visible;
            btnDefensaCharmander2.Visibility= Visibility.Visible;
            this.elegirOshawott2.Opacity = 0.5;
            this.elegirTeddiursa2.Opacity = 0.5;
            elegirOshawott2.PointerReleased -= elegirOshawott2_PointerReleased;
            elegirTeddiursa2.PointerReleased -= elegirTeddiursa2_PointerReleased;


        }

        private void btnDefensaOshawott1_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Oshawott1.Defensa();
            this.combate_Oshawott1.Vida += 15;
        }

        private void btnDefensaTeddiursa1_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Teddiursa1.Defensa();
            this.combate_Teddiursa1.Vida += 15;
        }

        private void btnDefensaCharmander1_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Charmander1.Defensa();
            this.combate_Charmander1.Vida += 15;
        }

        private void btnAtaqueOshawott1_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Oshawott1.Ataque();
            
            

            if (this.combate_Teddiursa2.Visibility == Visibility.Visible)
            {
                this.combate_Teddiursa2.Vida -= 25;
                if (this.combate_Teddiursa2.Vida<=30)
                {
                    this.combate_Teddiursa2.Debil();
                }
                comprobarVida1(this.combate_Teddiursa2.Vida);
            }
            else if (this.combate_Charmander2.Visibility == Visibility.Visible)
            {
                this.combate_Charmander2.Vida -= 25;
                if (this.combate_Charmander2.Vida <= 30)
                {
                    this.combate_Charmander2.Debil();
                }
                comprobarVida1(this.combate_Charmander2.Vida);
            }

            

        }

        private void btnAtaqueTeddiursa1_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Teddiursa1.Ataque();

            if (this.combate_Oshawott2.Visibility == Visibility.Visible)
            {
                this.combate_Oshawott2.Vida -= 25;
                if (this.combate_Oshawott2.Vida <= 30)
                {
                    this.combate_Oshawott2.Debil();
                }
                comprobarVida1(this.combate_Oshawott2.Vida);
            }
            else if (this.combate_Charmander2.Visibility == Visibility.Visible)
            {
                this.combate_Charmander2.Vida -= 25;
                if (this.combate_Charmander2.Vida <= 30)
                {
                    this.combate_Charmander2.Debil();
                }
                comprobarVida1(this.combate_Charmander2.Vida);
            }
        }

        private void btnAtaqueCharmander1_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Charmander1.Ataque();

            if (this.combate_Teddiursa2.Visibility == Visibility.Visible)
            {
                this.combate_Teddiursa2.Vida -= 25;
                if (this.combate_Teddiursa2.Vida <= 30)
                {
                    this.combate_Teddiursa2.Debil();
                }
                comprobarVida1(this.combate_Teddiursa2.Vida);
            }
            else if (this.combate_Oshawott2.Visibility == Visibility.Visible)
            {
                this.combate_Oshawott2.Vida -= 25;
                if (this.combate_Oshawott2.Vida <= 30)
                {
                    this.combate_Oshawott2.Debil();
                }
                comprobarVida1(this.combate_Oshawott2.Vida);
            }
        }

        private void btnAtaqueOshawott2_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Oshawott2.Ataque();

            if (this.combate_Teddiursa1.Visibility == Visibility.Visible)
            {
                this.combate_Teddiursa1.Vida -= 25;
                if (this.combate_Teddiursa1.Vida <= 30)
                {
                    this.combate_Teddiursa1.Debil();
                }
                comprobarVida2(this.combate_Teddiursa1.Vida);
            }
            else if (this.combate_Charmander1.Visibility == Visibility.Visible)
            {
                this.combate_Charmander1.Vida -= 25;
                if (this.combate_Charmander1.Vida <= 30)
                {
                    this.combate_Charmander1.Debil();
                }
                comprobarVida2(this.combate_Charmander1.Vida);
            }
        }

        private void btnAtaqueTeddiursa2_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Teddiursa2.Ataque2();

            

            if (this.combate_Oshawott1.Visibility == Visibility.Visible)
            {
                this.combate_Oshawott1.Vida -= 25;
                if (this.combate_Oshawott1.Vida <= 30)
                {
                    this.combate_Oshawott1.Debil();
                }
                comprobarVida2(this.combate_Oshawott1.Vida);
            }
            else if (this.combate_Charmander1.Visibility == Visibility.Visible)
            {
                this.combate_Charmander1.Vida -= 25;
                if (this.combate_Charmander1.Vida <= 30)
                {
                    this.combate_Charmander1.Debil();
                }
                comprobarVida2(this.combate_Charmander1.Vida);
            }
        }

        private void btnAtaqueCharmander2_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Charmander2.Ataque();
            
            

            if (this.combate_Teddiursa1.Visibility == Visibility.Visible)
            {
                
                this.combate_Teddiursa1.Vida -= 25;
                if (this.combate_Teddiursa1.Vida <= 30)
                {
                    this.combate_Teddiursa1.Debil();
                }
                comprobarVida2(this.combate_Teddiursa1.Vida);
                
            }
            else if (this.combate_Oshawott1.Visibility == Visibility.Visible)
            {
                
                this.combate_Oshawott1.Vida -= 25;
                if (this.combate_Oshawott1.Vida <= 30)
                {
                    this.combate_Oshawott1.Debil();
                }
                comprobarVida2(this.combate_Oshawott1.Vida);
            }

            
        }

        private void btnDefensaOshawott2_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Oshawott2.Defensa();
            this.combate_Oshawott2.Vida += 15;
        }

        private void btnDefensaTeddiursa2_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Teddiursa2.Defensa();
            this.combate_Teddiursa2.Vida += 15;
        }

        private void btnDefensaCharmander2_Click(object sender, RoutedEventArgs e)
        {
            this.combate_Charmander2.Defensa();
            this.combate_Charmander2.Vida += 15;
        }

        private void elegirTeddiursa2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.combate_Teddiursa2.Visibility = Visibility.Visible;
            btnAtaqueTeddiursa2.Visibility= Visibility.Visible;
            btnDefensaTeddiursa2.Visibility= Visibility.Visible;
            this.elegirCharmander2.Opacity = 0.5;
            this.elegirOshawott2.Opacity = 0.5;
            elegirCharmander2.PointerReleased -= elegirCharmander2_PointerReleased;
            elegirOshawott2.PointerReleased -= elegirOshawott2_PointerReleased;



        }

        private void comprobarVida1(double vida)
        {
           
            if (vida == 0)
            {
                tbGanador1.Visibility = Visibility.Visible;
            }
        }

        private void comprobarVida2(double vida)
        {
           
            if (vida == 0)
            {
                tbGanador2.Visibility = Visibility.Visible;
            }
        }

        


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Moteur;

namespace KaaReigns
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Carte carte;
        public MainWindow()
        {
            InitializeComponent();
            Carte mCarte = new Carte("Début","Roi");
            mCarte.AjouterReponses("la tarte ", "le soleil");
            mCarte.AjouterModification(new Tuple<int, string>(4,"saucisson"));
            carte = mCarte;
            Console.WriteLine();
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point pos_souris = e.GetPosition(Carte);
            if (pos_souris.X < (Carte.Width / 2))
            {
                Texte.Text = "\n" + carte.Reponse[0];
            }
            else
            {
                Texte.Text = "\n" + carte.Reponse[1];
            }
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Point pos_souris = e.GetPosition(Carte);
            if (pos_souris.X < 0)
            {
                Texte.Text = "\n" + carte.Reponse[0];
            }
            else
            {
                Texte.Text = "\n" + carte.Reponse[1];
            }
        }
    }
}

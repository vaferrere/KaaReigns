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
        FileCarteAJouer fileActive = new FileCarteAJouer();
        private int jaugeReligion = 50;
        private int jaugePeuple = 50;
        private int jaugeArmee = 50;
        private int jaugeCommerce = 50;
        private int gaucheDroite = 0;
        public MainWindow()
        {
            InitializeComponent();

            Moteur.Carte[] tas = new Carte[5];
            
            Carte mCarte = new Carte("Début","Roi", new string[] { "Jambon" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte.AjouterReponses("la tarte ", "le soleil");
            mCarte.AjouterModification(new Tuple<int, string>(4,"saucisson"));

            Carte mCarte1 = new Carte("Milieu","Reine", new string[] { "Jambon" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte1.AjouterReponses("le flan", " la lune");
            mCarte1.AjouterModification(new Tuple<int, string>(12,"pain"));

            Carte mCarte2 = new Carte("Fin", "Fou", new string[] { "Jambon" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte2.AjouterReponses("la ganache", " le fion");
            mCarte2.AjouterModification(new Tuple<int, string>(35, "miel"));

            Carte mCarte3 = new Carte("Gauche", "cavalier", new string[] { "Armée" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte3.AjouterReponses("excellent", " yes we can");
            mCarte3.AjouterModification(new Tuple<int, string>(35, "miel"));

            Carte mCarte4 = new Carte("Droite", "général", new string[] { "Armée" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte4.AjouterReponses("amazing", " un mur ");
            mCarte4.AjouterModification(new Tuple<int, string>(35, "miel"));

            tas[0] = mCarte;
            tas[1] = mCarte1;
            tas[2] = mCarte2;
            tas[3] = mCarte3;
            tas[4] = mCarte4;

            int i = 0;
            Random rand = new Random();
            for (i=0 ; i < 20; i++)
            {
                int value = rand.Next(0, 5);
                fileActive.Enfiler(tas[value]);
            }
            
            //fileActive.SupprimerGroupe("Jambon");
            fileActive.Test();
            carte = fileActive.Defiler();
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            jaugeReligion += carte.JaugeReligion[gaucheDroite];
            jaugeArmee += carte.JaugeArmee[gaucheDroite];
            jaugeCommerce += carte.JaugeCommerce[gaucheDroite];
            jaugePeuple += carte.JaugePeuple[gaucheDroite];
            carte = fileActive.Defiler();
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Point pos_souris = e.GetPosition(Carte);
            if (pos_souris.X < 0)
            {
                Texte.Text = "\n" + carte.Reponse[0];
                gaucheDroite = 0;
            }
            else
            {
                Texte.Text = "\n" + carte.Reponse[1];
                gaucheDroite = 1;
            }
            
        }
    }
}

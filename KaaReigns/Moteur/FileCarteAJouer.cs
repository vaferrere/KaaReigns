using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Moteur
{
    public class FileCarteAJouer
    {
        private List<Carte> FileCartes;

        public FileCarteAJouer()
        {
            FileCartes = new List<Carte>();
        }

        public Carte TêteFile()
        {
            return FileCartes[0];
        }

        public Carte Defiler()
        {
            Carte carte = FileCartes[0];
            FileCartes.RemoveAt(0);
            return carte;
        }

        public void Enfiler(Carte c)
        {
            FileCartes.Add(c);
        }

        public void SupprimerGroupe(string groupe)
        {
            List<Carte> newfileCartes = new List<Carte>();
            FileCartes.ForEach((carte) =>
            {
                if (!carte.Groupe.Contains(groupe))
                    newfileCartes.Add(carte);
            });
            FileCartes = newfileCartes;
        }

        public void SupprimerCarte(string id)
        {
            List<Carte> newfileCartes = new List<Carte>();
            FileCartes.ForEach((carte) =>
            {
                if (!(carte.Id == id))
                    newfileCartes.Add(carte);
            });
            FileCartes = newfileCartes;
        }

        public void Vider()
        {
            FileCartes.Clear();
        }

        public bool EstVide()
        {
            return FileCartes.Count == 0;
        }


        public void Test()
        {
            List<int> tests = new List<int>();
            FileCarteAJouer file = new FileCarteAJouer();
            Carte mCarte = new Carte("Début", "Roi", new string[] {"Jambon"}, new int[2] {10,20}, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte.AjouterReponses("la tarte ", "le soleil");
            mCarte.AjouterModification(new Tuple<int, string>(4, "saucisson"));

            Carte mCarte1 = new Carte("Milieu", "Reine", new string[] { "Jambon" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte1.AjouterReponses("le flan", " la lune");
            mCarte1.AjouterModification(new Tuple<int, string>(12, "pain"));

            Carte mCarte2 = new Carte("Fin", "Fou", new string[] { "Jambon" }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 }, new int[2] { 10, 20 });
            mCarte1.AjouterReponses("la ganache", " le fion");
            mCarte1.AjouterModification(new Tuple<int, string>(35, "miel"));

            file.Enfiler(mCarte);
            file.Enfiler(mCarte1);
            file.Enfiler(mCarte2);

            file.Defiler();
            int test1 = 1;
            if ("Milieu" == file.TêteFile().ToString())
            {
                
                Console.WriteLine("<+> TEST Défilage: OK <+>");
            }
            else
            {
                test1 = 0;
                Console.WriteLine("<-> TEST Défilage: ERROR <->");
            }
            tests.Add(test1);

            file.Enfiler(mCarte);
            int test2 = 1;
            file.Defiler();
            if ("Fin" != file.Defiler().ToString())
                test2 = 0;

            if ("Début" != file.TêteFile().ToString())
                test2 = 0;

            if (test2 == 1)
            {
                Console.WriteLine("<+> TEST Ordre Enfilage: OK <+>");
            }
            else
            {
                Console.WriteLine("<-> TEST Ordre Enfilage: ERROR <->");
            }
            tests.Add(test2);

            int test3 = 1;
            file.Vider();
            file.Enfiler(mCarte);
            file.Enfiler(mCarte1);
            file.Enfiler(mCarte2);

            file.SupprimerGroupe("Jambon");
            if (file.EstVide())
            {
                Console.WriteLine("<+> TEST Supprimer groupe: OK <+>");
            }
            else
            {
                Console.WriteLine("<-> TEST Suprimmer groupe: ERROR <->");
                test3 = 0;
            }
            tests.Add(test3);
            int total = 0;
            tests.ForEach((test) =>
            {
                if (test == 0)
                    total++;
            });
            if (total > 0)
            {
                Console.WriteLine("<-> Il y a " + total + " erreur(s) dans le test de la file de carte à jouer <->");
            }
            else
            {
                Console.WriteLine("<+> Il n'y a pas d'erreur dans le test de la file de carte à jouer <+>");
            }
            

        }
    }
}

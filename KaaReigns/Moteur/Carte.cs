using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteur
{
    public class Carte
    {
        public readonly string Id;
        public readonly string Personnage;
        public readonly string[] Reponse = new string[2];
        public readonly int[] JaugeReligion = new int[2];
        public readonly int[] JaugePeuple = new int[2];
        public readonly int[] JaugeArmee = new int[2];
        public readonly int[] JaugeCommerce = new int[2];
        private readonly bool AjouterCollection;
        public readonly string[] Groupe;
        private readonly bool ModifDeck;
        private readonly List<Tuple<int,string>> Modifications = new List<Tuple<int, string>>();

        public Carte(string id, string personnage, string[] groupe, int[] jaugeReligion, int[] jaugePeuple, int[] jaugeArmee, int[] jaugeCommerce)
        {
            Id = id;
            Personnage = personnage;
            Groupe = groupe;
            JaugeReligion = jaugeReligion;
            JaugeArmee = jaugeArmee;
            JaugeCommerce = jaugeCommerce;
            JaugePeuple = jaugePeuple;
        }

        public void AjouterReponses(string reponse1, string reponse2)
        {
            Reponse[0] = reponse1;
            Reponse[1] = reponse2;
        }

        public void AjouterModification(Tuple<int, string> modification)
        {
            Modifications.Add(new Tuple<int, string>( modification.Item1, modification.Item2 ));
        }

        public override string ToString()
        {
            return Id;
        }
    }
}

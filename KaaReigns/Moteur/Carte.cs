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
        private readonly int[] Consequences = new int[8];
        private readonly bool AjouterCollection;
        private readonly string[] Collection;
        private readonly bool ModifDeck;
        private readonly List<Tuple<int,string>> Modifications = new List<Tuple<int, string>>();

        public Carte(string id, string personnage)
        {
            Id = id;
            Personnage = personnage;
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

        
    }
}

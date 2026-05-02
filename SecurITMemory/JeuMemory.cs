using System;
using System.Collections.Generic;
using System.Linq;

namespace SecurITMemory
{
    public class JeuMemory
    {
        public List<Carte> Cartes { get; private set; }
        private Random random = new Random();

        public JeuMemory(int nombrePaires)
        {
            Cartes = new List<Carte>();
            InitialiserCartes(nombrePaires);
            MelangerCartes();
        }

        private void InitialiserCartes(int nombrePaires)
        {
            string[] symboles =
            {
                "🔒", "🛡️", "🦠", "🔑", "💻", "📡", "🧱", "⚠️",
                "🔐", "🧬", "🌐", "📁", "🧠", "🕵️", "📶", "🖥️",
                "🔍", "🚨"
            };

            for (int i = 0; i < nombrePaires; i++)
            {
                Cartes.Add(new Carte(i, symboles[i]));
                Cartes.Add(new Carte(i, symboles[i]));
            }
        }

        private void MelangerCartes()
        {
            Cartes = Cartes.OrderBy(c => random.Next()).ToList();
        }

        public bool PartieTerminee()
        {
            return Cartes.All(c => c.Etat == EtatCarte.Trouvee);
        }
    }
}
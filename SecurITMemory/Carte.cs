namespace SecurITMemory
{
    public class Carte
    {
        public int IdPaire { get; set; }
        public string Symbole { get; set; }
        public EtatCarte Etat { get; set; }

        public Carte(int idPaire, string symbole)
        {
            IdPaire = idPaire;
            Symbole = symbole;
            Etat = EtatCarte.Cachee;
        }
    }
}
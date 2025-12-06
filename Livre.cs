using System;

namespace BibliothequeNumerique
{
    public class Livre : Document
    {
        public int NombrePages { get; set; }

        public Livre(string titre, string auteur, int annee, int nombrePages)
            : base(titre, auteur, annee)
        {
            NombrePages = nombrePages;
        }

        public Livre(Guid id, string titre, string auteur, int annee, int nombrePages)
            : base(id, titre, auteur, annee)
        {
            NombrePages = nombrePages;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"[LIVRE] {Titre} - {Auteur} ({Annee}) - {NombrePages} pages - ID: {Id}");
        }

        public override string ToCSV()
        {
            return $"Livre;{Id};{Titre};{Auteur};{Annee};{NombrePages}";
        }
    }
}

using System;

namespace BibliothequeNumerique
{
    public class DocumentPDF : Document
    {
        public double TailleEnMo { get; set; }

        public DocumentPDF(string titre, string auteur, int annee, double tailleEnMo)
            : base(titre, auteur, annee)
        {
            TailleEnMo = tailleEnMo;
        }

        public DocumentPDF(Guid id, string titre, string auteur, int annee, double tailleEnMo)
            : base(id, titre, auteur, annee)
        {
            TailleEnMo = tailleEnMo;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"[PDF] {Titre} - {Auteur} ({Annee}) - {TailleEnMo} Mo - ID: {Id}");
        }

        public override string ToCSV()
        {
            return $"DocumentPDF;{Id};{Titre};{Auteur};{Annee};{TailleEnMo}";
        }
    }
}

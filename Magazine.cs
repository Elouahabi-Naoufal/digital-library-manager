using System;

namespace BibliothequeNumerique
{
    public class Magazine : Document
    {
        public int Numero { get; set; }

        public Magazine(string titre, string auteur, int annee, int numero)
            : base(titre, auteur, annee)
        {
            Numero = numero;
        }

        public Magazine(Guid id, string titre, string auteur, int annee, int numero)
            : base(id, titre, auteur, annee)
        {
            Numero = numero;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"[MAGAZINE] {Titre} - {Auteur} ({Annee}) - Numéro {Numero} - ID: {Id}");
        }

        public override string ToCSV()
        {
            return $"Magazine;{Id};{Titre};{Auteur};{Annee};{Numero}";
        }
    }
}

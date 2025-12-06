using System;

namespace BibliothequeNumerique
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque biblio = new Bibliotheque();
            bool continuer = true;

            Console.WriteLine("=== SYSTÈME DE GESTION DE BIBLIOTHÈQUE NUMÉRIQUE ===\n");

            while (continuer)
            {
                try
                {
                    AfficherMenu();
                    string? choix = Console.ReadLine();

                    switch (choix)
                    {
                        case "1":
                            AjouterDocument(biblio);
                            break;
                        case "2":
                            biblio.AfficherTous();
                            break;
                        case "3":
                            RechercherDocument(biblio);
                            break;
                        case "4":
                            SupprimerDocument(biblio);
                            break;
                        case "5":
                            SauvegarderBibliotheque(biblio);
                            break;
                        case "6":
                            ChargerBibliotheque(biblio);
                            break;
                        case "7":
                            continuer = false;
                            Console.WriteLine("Au revoir !");
                            break;
                        default:
                            Console.WriteLine("✗ Choix invalide.");
                            break;
                    }

                    if (continuer)
                    {
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Erreur : {ex.Message}");
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void AfficherMenu()
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Ajouter un document");
            Console.WriteLine("2. Afficher tous les documents");
            Console.WriteLine("3. Rechercher par mot-clé");
            Console.WriteLine("4. Supprimer un document");
            Console.WriteLine("5. Sauvegarder dans un fichier");
            Console.WriteLine("6. Charger depuis un fichier");
            Console.WriteLine("7. Quitter");
            Console.Write("\nVotre choix : ");
        }

        static void AjouterDocument(Bibliotheque biblio)
        {
            Console.WriteLine("\n=== AJOUTER UN DOCUMENT ===");
            Console.WriteLine("Type de document :");
            Console.WriteLine("1. Livre");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("3. Document PDF");
            Console.Write("Choix : ");
            string? typeChoix = Console.ReadLine();

            Console.Write("Titre : ");
            string? titre = Console.ReadLine();
            Console.Write("Auteur : ");
            string? auteur = Console.ReadLine();
            Console.Write("Année : ");
            int annee = int.Parse(Console.ReadLine() ?? "0");

            Document? doc = null;

            switch (typeChoix)
            {
                case "1":
                    Console.Write("Nombre de pages : ");
                    int pages = int.Parse(Console.ReadLine() ?? "0");
                    doc = new Livre(titre ?? "", auteur ?? "", annee, pages);
                    break;
                case "2":
                    Console.Write("Numéro : ");
                    int numero = int.Parse(Console.ReadLine() ?? "0");
                    doc = new Magazine(titre ?? "", auteur ?? "", annee, numero);
                    break;
                case "3":
                    Console.Write("Taille en Mo : ");
                    double taille = double.Parse(Console.ReadLine() ?? "0");
                    doc = new DocumentPDF(titre ?? "", auteur ?? "", annee, taille);
                    break;
                default:
                    Console.WriteLine("✗ Type invalide.");
                    return;
            }

            if (doc != null)
            {
                biblio.AjouterDocument(doc);
            }
        }

        static void RechercherDocument(Bibliotheque biblio)
        {
            Console.Write("\nMot-clé à rechercher : ");
            string? motCle = Console.ReadLine();
            if (!string.IsNullOrEmpty(motCle))
            {
                biblio.Rechercher(motCle);
            }
        }

        static void SupprimerDocument(Bibliotheque biblio)
        {
            Console.Write("\nID du document à supprimer : ");
            string? idStr = Console.ReadLine();
            if (Guid.TryParse(idStr, out Guid id))
            {
                biblio.SupprimerDocument(id);
            }
            else
            {
                Console.WriteLine("✗ ID invalide.");
            }
        }

        static void SauvegarderBibliotheque(Bibliotheque biblio)
        {
            Console.Write("\nNom du fichier (ex: bibliotheque.txt) : ");
            string? fichier = Console.ReadLine();
            if (!string.IsNullOrEmpty(fichier))
            {
                biblio.Sauvegarder(fichier);
            }
        }

        static void ChargerBibliotheque(Bibliotheque biblio)
        {
            Console.Write("\nNom du fichier à charger : ");
            string? fichier = Console.ReadLine();
            if (!string.IsNullOrEmpty(fichier))
            {
                biblio.Charger(fichier);
            }
        }
    }
}

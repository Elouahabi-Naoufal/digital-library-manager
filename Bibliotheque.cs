using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BibliothequeNumerique
{
    public class Bibliotheque
    {
        private List<Document> documents;

        public Bibliotheque()
        {
            documents = new List<Document>();
        }

        public void AjouterDocument(Document d)
        {
            documents.Add(d);
            Console.WriteLine("✓ Document ajouté avec succès.");
        }

        public void SupprimerDocument(Guid id)
        {
            var doc = documents.FirstOrDefault(d => d.Id == id);
            if (doc == null)
            {
                throw new DocumentNonTrouveException($"Document avec ID {id} non trouvé.");
            }
            documents.Remove(doc);
            Console.WriteLine("✓ Document supprimé avec succès.");
        }

        public void Rechercher(string motCle)
        {
            var resultats = documents.Where(d =>
                d.Titre.Contains(motCle, StringComparison.OrdinalIgnoreCase) ||
                d.Auteur.Contains(motCle, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            if (resultats.Count == 0)
            {
                throw new DocumentNonTrouveException($"Aucun document trouvé avec le mot-clé '{motCle}'.");
            }

            Console.WriteLine($"\n=== {resultats.Count} document(s) trouvé(s) ===");
            foreach (var doc in resultats)
            {
                doc.AfficherDetails();
            }
        }

        public void AfficherTous()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("La bibliothèque est vide.");
                return;
            }

            Console.WriteLine($"\n=== {documents.Count} document(s) dans la bibliothèque ===");
            foreach (var doc in documents)
            {
                doc.AfficherDetails();
            }
        }

        public void Sauvegarder(string cheminFichier)
        {
            try
            {
                using (FileStream fs = new FileStream(cheminFichier, FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    foreach (var doc in documents)
                    {
                        writer.WriteLine(doc.ToCSV());
                    }
                }
                Console.WriteLine($"✓ Bibliothèque sauvegardée dans {cheminFichier}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"✗ Erreur d'accès au fichier : {ex.Message}");
                throw;
            }
        }

        public void Charger(string cheminFichier)
        {
            try
            {
                if (!File.Exists(cheminFichier))
                {
                    throw new FileNotFoundException($"Le fichier {cheminFichier} n'existe pas.");
                }

                documents.Clear();

                using (FileStream fs = new FileStream(cheminFichier, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fs))
                {
                    string? ligne;
                    int numeroLigne = 0;

                    while ((ligne = reader.ReadLine()) != null)
                    {
                        numeroLigne++;
                        try
                        {
                            var parties = ligne.Split(';');
                            if (parties.Length < 6)
                            {
                                throw new FormatException($"Format incorrect à la ligne {numeroLigne}");
                            }

                            string type = parties[0];
                            Guid id = Guid.Parse(parties[1]);
                            string titre = parties[2];
                            string auteur = parties[3];
                            int annee = int.Parse(parties[4]);

                            Document doc = type switch
                            {
                                "Livre" => new Livre(id, titre, auteur, annee, int.Parse(parties[5])),
                                "Magazine" => new Magazine(id, titre, auteur, annee, int.Parse(parties[5])),
                                "DocumentPDF" => new DocumentPDF(id, titre, auteur, annee, double.Parse(parties[5])),
                                _ => throw new FormatException($"Type de document inconnu : {type}")
                            };

                            documents.Add(doc);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"⚠ Erreur ligne {numeroLigne} : {ex.Message}");
                        }
                    }
                }

                Console.WriteLine($"✓ {documents.Count} document(s) chargé(s) depuis {cheminFichier}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"✗ Fichier introuvable : {ex.Message}");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"✗ Erreur d'accès au fichier : {ex.Message}");
                throw;
            }
        }
    }
}

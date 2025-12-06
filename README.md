# Bibliothèque Numérique - Projet C# .NET

## Description
Mini-système de gestion pour une bibliothèque numérique développé en C# .NET.

## Fonctionnalités
- Gestion de documents (Livres, Magazines, PDF)
- Sauvegarde/Chargement depuis fichier CSV
- Recherche par mot-clé
- Gestion des erreurs robuste
- Libération propre des ressources

## Comment exécuter le projet

### Prérequis
- .NET SDK installé (version 6 ou supérieure)
- Terminal/Console

### Instructions d'exécution

1. **Ouvrir un terminal dans le dossier du projet**
   ```bash
   cd /home/school/Documents/biblio_numerique
   ```

2. **Compiler le projet**
   ```bash
   dotnet build
   ```

3. **Exécuter l'application**
   ```bash
   dotnet run
   ```

### Utilisation
Le programme affiche un menu avec 7 options :
1. Ajouter un document (Livre/Magazine/PDF)
2. Afficher tous les documents
3. Rechercher par mot-clé
4. Supprimer un document (par ID)
5. Sauvegarder dans un fichier
6. Charger depuis un fichier
7. Quitter

### Exemple de fichier sauvegardé
Le format CSV est : `Type;ID;Titre;Auteur;Annee;ProprieteSpecifique`

```
Livre;a1b2c3d4-e5f6-7890-abcd-ef1234567890;Le Petit Prince;Antoine de Saint-Exupéry;1943;96
Magazine;b2c3d4e5-f6a7-8901-bcde-f12345678901;National Geographic;Various;2023;145
DocumentPDF;c3d4e5f6-a7b8-9012-cdef-123456789012;Guide Python;Guido van Rossum;2022;5.2
```

## Structure du projet
- `Document.cs` - Classe abstraite de base
- `Livre.cs` - Classe dérivée pour les livres
- `Magazine.cs` - Classe dérivée pour les magazines
- `DocumentPDF.cs` - Classe dérivée pour les PDF
- `Bibliotheque.cs` - Gestion de la collection
- `DocumentNonTrouveException.cs` - Exception personnalisée
- `Program.cs` - Point d'entrée et menu console

## Auteur
Projet réalisé pour l'examen pratique de Programmation Objet C#

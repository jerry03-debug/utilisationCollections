using System;
using System.Collections;
using System.Linq;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 3: Utiliser SortedList pour stocker les étudiants
            SortedList lstÉtudiants = new SortedList();

            // Question 5: Gestion de la pagination
            int lignesParPage = DemanderNombreLignesParPage();

            // Question 3: Saisie des étudiants
            while (true)
            {
                Console.WriteLine("Voulez-vous ajouter un étudiant ? (O/N)");
                string reponse = Console.ReadLine().ToUpper();
                
                if (reponse != "O")
                    break;

                // Question 2: Saisie des informations de l'étudiant
                Étudiant étudiant = new Étudiant();

                Console.Write("Numéro d'ordre (NO) : ");
                étudiant.NO = Console.ReadLine();

                Console.Write("Prénom : ");
                étudiant.Prénom = Console.ReadLine();

                Console.Write("Nom : ");
                étudiant.Nom = Console.ReadLine();

                Console.Write("Note de Contrôle Continu : ");
                étudiant.NoteCC = double.Parse(Console.ReadLine());

                Console.Write("Note de Devoir : ");
                étudiant.NoteDevoir = double.Parse(Console.ReadLine());

                // Ajouter l'étudiant à la liste
                lstÉtudiants.Add(étudiant.NO, étudiant);
            }

            // Question 4: Affichage des étudiants avec pagination
            AfficherÉtudiants(lstÉtudiants, lignesParPage);

            // Question 6: Option de sortie
            Console.WriteLine("\nAppuyez sur Entrée pour quitter...");
            Console.ReadLine();
        }

        // Question 5: Méthode pour demander le nombre de lignes par page
        static int DemanderNombreLignesParPage()
        {
            int lignesParPage;
            do
            {
                Console.Write("Combien de lignes voulez-vous par page (1-15) ? ");
                lignesParPage = int.Parse(Console.ReadLine());
            } while (lignesParPage < 1 || lignesParPage > 15);

            return lignesParPage;
        }

        // Question 4: Méthode pour afficher les étudiants avec pagination
        static void AfficherÉtudiants(SortedList lstÉtudiants, int lignesParPage)
        {
            // Calculer la moyenne de la classe
            double moyenneClasse = CalculerMoyenneClasse(lstÉtudiants);

            Console.WriteLine("\n--- Liste des Étudiants ---");
            int compteur = 0;

            foreach (DictionaryEntry entry in lstÉtudiants)
            {
                Étudiant étudiant = (Étudiant)entry.Value;

                // Afficher les détails de l'étudiant
                Console.WriteLine($"NO: {étudiant.NO}, " +
                                  $"Prénom: {étudiant.Prénom}, " +
                                  $"Nom: {étudiant.Nom}, " +
                                  $"Note CC: {étudiant.NoteCC}, " +
                                  $"Note Devoir: {étudiant.NoteDevoir}, " +
                                  $"Moyenne: {étudiant.Moyenne:F2}");

                compteur++;

                // Pagination
                if (compteur % lignesParPage == 0)
                {
                    Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
                    Console.ReadLine();
                }
            }

            // Afficher la moyenne de la classe
            Console.WriteLine($"\nMoyenne de la classe : {moyenneClasse:F2}");
        }

        // Question 4: Calculer la moyenne de la classe
        static double CalculerMoyenneClasse(SortedList lstÉtudiants)
        {
            if (lstÉtudiants.Count == 0) return 0;

            double sommeMoyennes = lstÉtudiants.Values
                .Cast<Étudiant>()
                .Sum(étudiant => étudiant.Moyenne);

            return sommeMoyennes / lstÉtudiants.Count;
        }
    }
}
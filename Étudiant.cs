using System;

namespace UsageCollections
{
    public class Étudiant
    {
        // Question 2: Propriétés requises
        public string NO { get; set; }       // Numéro d'ordre
        public string Prénom { get; set; }   
        public string Nom { get; set; }      
        public double NoteCC { get; set; }   // Note de Contrôle Continu
        public double NoteDevoir { get; set; }

        // Calculer la moyenne (Question 4: Note CC compte pour 33%)
        public double Moyenne 
        { 
            get 
            { 
                return (NoteCC * 0.33) + (NoteDevoir * 0.67); 
            }
        }
    }
}

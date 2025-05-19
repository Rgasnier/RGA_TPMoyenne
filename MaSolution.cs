using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using HNI_TPmoyennes;


class moyennesClasse
    {
        public static string[] Tmatieres = new string[4]; //4 matieres
        public static float[] Tmoyennes = new float[4]; // 4 moyennes
    }


class Classe
{
    public List<Eleve> eleves = new List<Eleve>(); //liste de classe Eleve
    public List<string> matieres = new List<string>(); 

    public string nomClasse { get; } // string récuperant le nom de la classe


    public Classe(string NomClasse)  //récupere nom de la classe
    {
        nomClasse = NomClasse;
    }


    internal void ajouterEleve(string prenom, string nom) // ajoute un nouvelle éleve à la liste
    {
        Eleve nouveau = new Eleve(prenom, nom); 
        eleves.Add(nouveau);
    }

    internal void ajouterMatiere(string matiere) // ajoute une matiere à la liste
    {
        matieres.Add(matiere);
    }

    public float moyenneGeneral() // calcul moyenne général de classe
    {
        float CMG = 0;
        float MoyenneCumuléC = 0;
        int NombreDeMoyenne = 0;
        for (int i = 0; i < matieres.Count; i++) // count devrai être = 4 
        {
            if (moyennesClasse.Tmoyennes[i] > 0) // verifie que la moyenne existe
            {
                MoyenneCumuléC += moyennesClasse.Tmoyennes[i];
                NombreDeMoyenne++;
            }
        }

        CMG += MoyenneCumuléC / NombreDeMoyenne;
        return (float)Math.Round(CMG, 2); // Round fonctionne sur les double besoin de (float)

    }


    public float moyenneMatiere(int m) // moyenne de la classe pour 1 matiere
    {
        float CMM = 0;
        for (int i = 0; i < matieres.Count; i++) // selectionne 1 matiere
        {
            float MoyenneCumuléE = 0;
            int NombreDeNote = 0;
            for (int j = 0; j < eleves.Count; j++) // prend la moyenne de chaque éleve
            {

                MoyenneCumuléE += eleves[j].moyenneMatiere(m);
                NombreDeNote++;
            }
            if (m < 3) // change de matiere
            {
                ++m;
            }

            CMM = MoyenneCumuléE / NombreDeNote;
            moyennesClasse.Tmatieres[i] = matieres[i];
            moyennesClasse.Tmoyennes[i] = (float)Math.Round(CMM, 2);
        }
        return (float)Math.Round(CMM, 2);
    }
}




    class Eleve //classe pour 1 eleve
    {

        public string prenom { get; }
        public string nom { get; }
        public List<Note> notes { get; }


        public float[] NotesMoyenne;

        // prend les noms et prenoms d'un éléve et créé une liste de note lui étant associé
        public Eleve(string prenom, string nom) 
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();
            NotesMoyenne = new float[10];
        }

        internal void ajouterNote(Note note)
        {
            notes.Add(note);
        }

        internal float moyenneMatiere(int m) // moyenne matiere d'1 éleve
        {
            float EMM = 0;
            float NotesCumulé = 0;
            int NombreNote = 0;
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == m) // range les notes conrespondant au matiere
                {
                    NotesCumulé += notes[i].note;
                    NombreNote++;
                }
            }
            EMM += NotesCumulé / NombreNote;
            NotesMoyenne[m] = (float)Math.Round(EMM, 2);
            return (float)Math.Round(EMM, 2);
        }

        internal float moyenneGeneral() // moyenne général d'une matiere
        {
            float MoyenneGeneralE = 0;
            float MoyenneCumuléE = 0;
            int NombreDeMoyenne = 0;
            for (int i = 0; i < NotesMoyenne.Length; i++)
            {
                if (NotesMoyenne[i] > 0) // vérifie que la note existe
                {
                    MoyenneCumuléE += NotesMoyenne[i];
                    NombreDeMoyenne++;
                }
            }
            MoyenneGeneralE += MoyenneCumuléE / NombreDeMoyenne;
            return (float)Math.Round(MoyenneGeneralE, 2);
        }
    }

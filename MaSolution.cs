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
        public static string[] Tmatieres = new string[10];
        public static float[] Tmoyennes = new float[10];
    }


class Classe
{
    public List<Eleve> eleves = new List<Eleve>();
    public List<string> matieres = new List<string>();

    public string nomClasse { get; }


    public Classe(string NomClasse)
    {
        nomClasse = NomClasse;
    }


    internal void ajouterEleve(string prenom, string nom)
    {
        Eleve nouveau = new Eleve(prenom, nom);
        eleves.Add(nouveau);
    }

    internal void ajouterMatiere(string matiere)
    {
        matieres.Add(matiere);
    }

    public float moyenneGeneral()
    {
        float CMG = 0;
        float MoyenneCumuléC = 0;
        int NombreDeMoyenne = 0;
        for (int i = 0; i < matieres.Count; i++)
        {
            if (moyennesClasse.Tmoyennes[i] > 0)
            {
                MoyenneCumuléC += moyennesClasse.Tmoyennes[i];
                NombreDeMoyenne++;
            }
        }
        CMG += MoyenneCumuléC / NombreDeMoyenne;
        return (float)Math.Round(CMG, 2);

    }


    public float moyenneMatiere(int m)
    {
        float CMM = 0;
        for (int i = 0; i < matieres.Count; i++)
        {
            float MoyenneCumuléE = 0;
            int NombreDeNote = 0;
            for (int j = 0; j < eleves.Count; j++)
            {

                MoyenneCumuléE += eleves[j].moyenneMatiere(m);
                NombreDeNote++;
            }
            if (m < 3)
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




    class Eleve
    {

        public string prenom { get; }
        public string nom { get; }
        public List<Note> notes { get; }


        public float[] NotesMoyenne;


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

        internal float moyenneMatiere(int m)
        {
            float EMM = 0;
            float NotesCumulé = 0;
            int NombreNote = 0;
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == m)
                {


                NotesCumulé += notes[i].note;
                    NombreNote++;
                }
            }

            EMM += NotesCumulé / NombreNote;
            NotesMoyenne[m] = (float)Math.Round(EMM, 2);
            return (float)Math.Round(EMM, 2);
        }

        internal float moyenneGeneral()
        {
            float MoyenneGeneralE = 0;
            float MoyenneCumuléE = 0;
            int NombreDeMoyenne = 0;
            for (int i = 0; i < NotesMoyenne.Length; i++)
            {
                if (NotesMoyenne[i] > 0)
                {
                    MoyenneCumuléE += NotesMoyenne[i];
                NombreDeMoyenne++;
                }
            }
            MoyenneGeneralE += MoyenneCumuléE / NombreDeMoyenne;
            return (float)Math.Round(MoyenneGeneralE, 2);
        }
    }

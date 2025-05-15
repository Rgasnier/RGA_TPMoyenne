using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using HNI_TPmoyennes;

public class Classe
{
    public List<Eleve> eleves = new List<Eleve>();
    
    public List<string> matieres = new List<string>();
    internal string nomClasse;

    public Classe(string nomClasse)
    {
        NomClasse = nomClasse;
    }

    public string NomClasse { get; }
    
    internal void ajouterEleve(string Prenom, string Nom)
    {
        Eleve nouveau = new Eleve(Prenom, Nom);
        eleves.Add(nouveau);

    }

    internal void ajouterMatiere(string matiere)
    {
        matieres.Add(matiere);
    }
    internal float moyenneGeneral()
    { 
        float CMG = 0.0f;
        return CMG;
    }
                                  
    internal int moyenneMatiere(int CMM)
    {
        return CMM;
    }
}
public class Eleve
{
    //public List<float> NotesMoyenne { get; set; } = new List<float>();
    float[] NotesMoyenne = new float[20];
    //var NotesMoyenne = Dictionary<int, float>();
    int i = 0;
    public int NombreNote = 0;
    public float NoteCumulé = 0.00f;
    public string prenom { get; set; }
    public string nom { get; set; }
    internal List<Note> Notes { get; set; }

    public Eleve (string Prenom, string Nom)
    {
        prenom = Prenom;
        nom = Nom;
        Notes = new List<Note>();
        Console.WriteLine("Prenom :" + Prenom + "Nom : " + Nom);

    }

    internal void ajouterNote(Note note)
    {
        /*if (NotesMoyenne[i] == 0 && NombreNote == 0)
        {
            Console.WriteLine("1er i = " + i);
            ++i;
            Console.WriteLine("NotesMoyenne : " + NotesMoyenne[0]);
        }*/
        if (NombreNote <5)
        {
            Notes.Add(note);
            NoteCumulé += note.note;
            ++NombreNote;
/*            Console.WriteLine("Nombre de note : " + NombreNote);
            Console.WriteLine("Note cumulé : " + NoteCumulé);
            Console.WriteLine("Note.note : " + note.note);*/
        }
        else
        {
            NotesMoyenne[i] = NoteCumulé / NombreNote;
/*            Console.WriteLine("NotesMoyenne : " + NotesMoyenne[i]);
            Console.WriteLine("i = " + i);*/
            ++i;
            NoteCumulé =  0;
            NombreNote = 0;
        }
        
                //while (NombreNote < 20)
        //{
        //    Notes.Add(note);
        //    NoteCumulé += note.note;
        //    ++NombreNote;
        //    Console.WriteLine("Nombre de note : " + NombreNote);
        //    Console.WriteLine("Note cumulé : " + NoteCumulé);
        //    Console.WriteLine("Note.note : " + note.note);
        //}    
        //if (NombreNote >= 20 && i <= 20)
        //{
        //    Console.WriteLine("i = " + i);
        //    NotesMoyenne[i] = NoteCumulé / NombreNote;
        //    ++i;
        //    Console.WriteLine("NotesMoyenne : " + NotesMoyenne[0]);
        //    NombreNote = 0;
        //    NoteCumulé = 0;
        //}
    }

    internal float moyenneMatiere(float EMM)
    {
        EMM = NotesMoyenne[6*2];
        Console.WriteLine("Note moyenne Matiere : " + EMM);
        return EMM;
    }
    internal float moyenneGeneral()
    {
        i = 0;
        NoteCumulé = 0;
        float EMG = 0.0f;
        while (i < 20)
        {
            NoteCumulé += NotesMoyenne[i];
            i++;
        }
        NombreNote = i;
        EMG = NoteCumulé / NombreNote;
        return EMG;
    }
}



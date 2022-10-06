using System;
using System.Diagnostics;

namespace DeWPF
{
    // Un objet de hasard
    public abstract class ObjetHasard
    {
        protected static readonly Random rnd = new Random();

        public string Nom { get; }

        public Face[] Faces { get; }

        public int NbFaces => Faces.Length;

        public ObjetHasard(string nom, int nbFaces)
        {
            Nom = nom;
            Faces = new Face[nbFaces];
            CreerFaces();

            //Verifie si les parametre recu sont les bons
            Debug.Assert(Nom == "Pièce" || Nom == "Dé 6", "[ObjetHasard()] Nom != Pièce ou != Dé 6");
            Debug.Assert(nbFaces == 2 || nbFaces == 6, "[ObjetHasard()] nbFaces != 2 ou != 6");
        }

        protected virtual void CreerFaces()
        {
            int valeur;

            for (valeur = 1; valeur <= NbFaces; valeur++)
            {
                Faces[valeur - 1] = new Face(valeur, valeur.ToString());
            }

            //Regarde si il passe bien au travers du nombre de faces demander
            Debug.Assert(valeur - 1 == NbFaces, "[CreerFaces()] valeur - 1 != NbFaces");
        }

        public Face Lancer()
        {
            return Faces[rnd.Next(NbFaces)];        
        }
    }
}

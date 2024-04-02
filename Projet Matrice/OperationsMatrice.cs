using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Projet
{
    public partial class Matrice
    {
        /// <summary>
        /// Pour annuler une matrice
        /// </summary>
        private void zero()
        {
            for (int ligne = 0; ligne < _matrice.GetLength(0); ligne++)
                for (int colonne = 0; colonne < _matrice.GetLength(1); colonne++)
                {
                    _matrice[ligne, colonne] = 0.0;
                }
        }
        /// <summary>
        /// Une version statique de création d'une matrice nulle
        /// </summary>
        /// <param name="size"></param>
        /// <returns>La matrice nulle</returns>
        public static Matrice zero(int size)
        {
            var _result = new Matrice(size);
            _result.zero();
            return _result;
        }
        /// <summary>
        /// Vérification que la matrice est identité, rappelons que la matrice
        /// identité est carré avec tout les valeurs sont mises à 1
        /// </summary>
        private void identity()
        {
            if (Lignes != Colonnes)
                throw new InvalidOperationException("La matrice identité doit être carré");
            zero();
            for (int n = 0; n < Lignes; n++)
                _matrice[n, n] = 1.0;
        }

        /// <summary>
        /// Une méthode qui calcule le produit Hadamard de deux matrices
        /// </summary>
        /// <param name="matrice">Représente une matrice</param>
        public void hadamardProduct(Matrice matrice)
        {
            if (Colonnes != matrice.Colonnes || Lignes != matrice.Lignes)
                throw new InvalidOperationException("Il n'est pas possible de multiplier " +
                    "deux matrices qui non pas la même taille");
            for (int _ligne = 0; _ligne < Lignes; _ligne++)
                for (int _colonne = 0; _colonne < Colonnes; _colonne++)
                {
                    _matrice[_ligne, _colonne] *= matrice[_ligne + 1, _colonne + 1];
                }
        }
        /// <summary>
        /// Une méthode qui permet le calcul de somme de deux matrices
        /// </summary>
        /// <param name="matrice">Représente une matrice</param>
        public void addition(Matrice matrice)
        {
            if (Lignes != matrice.Lignes || Colonnes != matrice.Colonnes)
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            for (int _ligne = 0; _ligne < _matrice.GetLength(0); _ligne++)
                for (int _colonne = 0; _colonne < _matrice.GetLength(1); _colonne++)
                {
                    _matrice[_ligne, _colonne] += matrice[_ligne + 1, _colonne + 1];
                }
        }
        /// <summary>
        /// Une méthode qui permet le calcul la différence de deux matrices
        /// </summary>
        /// <param name="matrice">Représente une matrice</param>
        public void soustraction(Matrice matrice)
        {
            if (Lignes != matrice.Lignes || Colonnes != matrice.Colonnes)
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            for (int _ligne = 0; _ligne < _matrice.GetLength(0); _ligne++)
                for (int _colonne = 0; _colonne < _matrice.GetLength(1); _colonne++)
                {
                    _matrice[_ligne, _colonne] -= matrice[_ligne + 1, _colonne + 1];
                }
        }
        /// <summary>
        /// Méthode qui permet le calcul de l'inverse d'une matrice
        /// </summary>
        public void inverser()
        {
            if (!IsSquare)
                throw new InvalidOperationException("Seulement les matrices carré peuvent être inversés");
            int _dimension = Lignes;
            var _result = _matrice.Clone() as double[,];
            var _identité = _matrice.Clone() as double[,];
            //make identity matrix
            for (int _ligne = 0; _ligne < _dimension; _ligne++)
                for (int _colonne = 0; _colonne < _dimension; _colonne++)
                {
                    _identité[_ligne, _colonne] = (_ligne == _colonne) ? 1.0 : 0.0;
                }
            //invert
            for (int i = 0; i < _dimension; i++)
            {
                double _tmp = _result[i, i];
                for (int j = 0; j < _dimension; j++)
                {
                    _result[i, j] = _result[i, j] / _tmp;
                    _identité[i, j] = _identité[i, j] / _tmp;
                }
                for (int k = 0; k < _dimension; k++)
                {
                    if (i != k)
                    {
                        _tmp = _result[k, i];
                        for (int n = 0; n < _dimension; n++)
                        {
                            _result[k, n] = _result[k, n] - _tmp * _result[i, n];
                            _identité[k, n] = _identité[k, n] - _tmp * _identité[i, n];
                        }
                    }
                }
            }
            _matrice = _identité;
        }
        /// <summary>
        /// Méthode qui transpose une matrice
        /// </summary>
        public Matrice transpose()
        {
            Matrice _result = new Matrice(Colonnes, Lignes);
            for (int _ligne = 0; _ligne < _matrice.GetLength(0); _ligne++)
                for (int _colonne = 0; _colonne < _matrice.GetLength(1); _colonne++)
                {
                    _result[_colonne, _ligne] = _matrice[_ligne, _colonne];
                }
            return _result ;
        }
        /// <summary>
        /// Créer des valeur aléatoires de matrice
        /// </summary>
        public Matrice aléa()
        {
            var _result = new Matrice(Lignes, Colonnes);
            for (int _ligne = 0; _ligne < Lignes; _ligne++)
                for (int _colonne = 0; _colonne < Colonnes; _colonne++)
                {
                    _result[_ligne + 1, _colonne + 1] = new Random().Next(1, 50);
                }
            return _result;
        }
        /// <summary>
        /// Clonner une matrice
        /// </summary>
        /// <returns>Retourne une copie de la matrice</returns>
        public Matrice clonner()
        {
            var _result = new Matrice(Lignes, Colonnes);
            for (int _ligne = 0; _ligne < Lignes; _ligne++)
                for (int colonne = 0; colonne < Colonnes; colonne++)
                {
                    _result[_ligne + 1, colonne + 1] = _matrice[_ligne, colonne];
                }
            return _result;
        }
        /// <summary>
        /// Méthode pour afficher une matrice 
        /// </summary>
        public string affiche()
        {
            StringBuilder format = new StringBuilder();
            for (int _ligne = 0; _ligne < Lignes; _ligne++)
            {
                string temp = String.Empty;
                for (int _colonne= 0; _colonne < Colonnes; _colonne++)
                {
                    if (_colonne == 0) temp += "|";
                    temp+= $" {_matrice[_ligne, _colonne]} ";
                    if (_colonne == Colonnes-1) temp += "| ";
                }
                format.AppendLine(temp);
            }
            Debug.Write(format.ToString());
            return format.ToString();
        }


    }
}

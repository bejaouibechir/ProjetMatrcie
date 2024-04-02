using System.Diagnostics;
using System.Text;

namespace Projet
{
    public partial class Matrice
    {
        #region Overloaded operators
        public static Matrice operator ~(Matrice Matrice)
        {
            var result = Matrice.clonner();
            result.inverser();
            return result;
        }

        public static Matrice operator +(Matrice first, Matrice second)
        {
            var result = first.clonner();
            result.addition(second);
            return result;
        }

        public static Matrice operator -(Matrice first, Matrice second)
        {
            var result = first.clonner();
            result.soustraction(second);
            return result;
        }

        public static Matrice operator *(Matrice first, Matrice second)
        {
            var result = first.clonner();
            result.hadamardProduct(second);
            return result;
        }

        public static bool operator !=(Matrice first, Matrice second)
        {
            bool result = (first.Lignes != second.Lignes) || (first.Colonnes != second.Colonnes);
            if (!result)
            {
                for (int row = 1; row <= first.Lignes; row++)
                {
                    for (int col = 1; col <= first.Colonnes; col++)
                    {
                        result |= (first[row, col] != second[row, col]);
                    }
                }
            }
            return result;
        }


        public static bool operator ==(Matrice first, Matrice second)
        {
            bool result = (first.Lignes == second.Lignes) && (first.Colonnes == second.Colonnes);
            if (result)
            {
                for (int row = 1; row <= first.Lignes; row++)
                {
                    for (int col = 1; col <= first.Colonnes; col++)
                    {
                        result &= (first[row, col] == second[row, col]);
                    }
                }
            }
            Debug.WriteLine("J'ajoute quelques choses dans le code");
            return result;
        }

        public static bool operator >(Matrice first, Matrice second)
        {
            return (first.Lignes * first.Colonnes) > (second.Lignes * second.Colonnes);
        }
        public static bool operator <(Matrice first, Matrice second)
        {
            return (first.Lignes * first.Colonnes) < (second.Lignes * second.Colonnes);
        }

        public static bool operator >=(Matrice first, Matrice second)
        {
            return (first.Lignes * first.Colonnes) >= (second.Lignes * second.Colonnes);
        }

        public static bool operator <=(Matrice first, Matrice second)
        {
            return (first.Lignes * first.Colonnes) <= (second.Lignes * second.Colonnes);
        }

        public override bool Equals(object obj)
        {
            var Matrice = obj as Matrice;
            if (obj == null)
            {
                return false;
            }
            bool result = (this.Lignes == Matrice.Lignes) && (this.Colonnes == Matrice.Colonnes);
            if (result)
            {
                for (int row = 1; row <= this.Lignes; row++)
                {
                    for (int col = 1; col <= this.Colonnes; col++)
                    {
                        result &= (this[row, col] == Matrice[row, col]);
                    }
                }
            }
            return result;
        }

        #endregion
    }
}

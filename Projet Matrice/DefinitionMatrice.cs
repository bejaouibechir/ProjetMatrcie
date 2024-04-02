namespace Projet
{
    public partial class Matrice
    {
        /// <summary>
        /// Champ privé qui détient les valeurs de la matrice
        /// </summary>
        private double[,] _matrice;
        /// <summary>
        /// Lignes de la matrice
        /// </summary>
        public int Lignes { get { return _matrice.GetLength(0); } }
        /// <summary>
        /// Colonne de la matrice
        /// </summary>
        public int Colonnes { get { return _matrice.GetLength(1); } }
        /// <summary>
        /// Indexeur de la colonne
        /// </summary>
        /// <param name="ligne">Représente une ligne</param>
        /// <param name="colone">Représente une colonne</param>
        /// <returns></returns>
        public double this[int ligne, int colone]
        {
            get
            {
                return _matrice[ligne-1, colone-1];
            }

            set
            {
                _matrice[ligne-1, colone-1] = value;
            }
        }
        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="Lignes">Représente les lignes</param>
        /// <param name="Colonnes">Représente les colonnes</param>
        public Matrice(int Lignes, int Colonnes)
        {
            _matrice = new double[Lignes, Colonnes];
        }
        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="m">Représente la dimension de la matrice carré</param>
        public Matrice(int m) : this(m, m) { }
    }
}

using System;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrice m1 = new Matrice(3, 3);
            Matrice m2 = new Matrice(3, 3);

            for (int i = 1; i <= 3; i++)
            {
                for (int j =1; j <= 3; j++)
                {
                    m1[i, j] = new Random().Next(10,20);
                }
            }
            Matrice resultat = ~m1;
            Console.WriteLine($"{resultat.affiche()}");
             
            Console.ReadLine();
        }
    }
   
}


using System;
using System.Linq;

namespace AdjacentPointsMaxDistance
{
    public class Solution
    {
        //Ordenar o vetor: O(N* log(N))
        //Encontrar o maior valor: O(N)
        //Como: O(N* log(N) + N) = O(N* log(N))
        public static int GetAdjacentPointsMaxDistance(int[] vector)
        {
            Array.Sort(vector);

            int maxDistance = 0;

            if (vector.Length < 2) return -2;

            for (int i = 0; i < vector.Length - 1; i++)
            {
                maxDistance = Math.Abs(vector[i] - vector[i + 1]) > maxDistance ? Math.Abs(vector[i] - vector[i + 1]) : maxDistance;
            }

            if (maxDistance < -2147483648 || maxDistance > 2147483647) return -1;

            return maxDistance;
        }

        public static int GetAdjacentPointsMaxDistanceLINQ(int[] vector)
        {
            Array.Sort(vector);

            if (vector.Length < 2) return -2;

            var maxDistance = vector.Zip(vector.Skip(1), (x, y) => Math.Abs(x - y)).Max();

            if (maxDistance < -2147483648 || maxDistance > 2147483647) return -1;

            return maxDistance;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Integer V lies strictly between integers U and W if U < V < W or if U > V > W." + Environment.NewLine +
            "A non - empty zero - indexed array A consisting of N integers is given."+ Environment.NewLine +
            "A pair of indices(P, Q), where 0 ≤ P < Q < N, is said to" + Environment.NewLine +
            "have adjacent values if no value in the array lies strictly between values A[P] and A[Q].");

            Console.WriteLine("A[0] = 0" + Environment.NewLine +
            "A[1] = 3 " + Environment.NewLine +
            "A[2] = 3 " + Environment.NewLine +
            "A[3] = 12" + Environment.NewLine +
            "A[4] = 5 " + Environment.NewLine +
            "A[5] = 3 " + Environment.NewLine +
            "A[6] = 7 " + Environment.NewLine +
            "A[7] = 1 " + Environment.NewLine);

            int []  vectorEx = new [] {0,3,3,12,5,3,7,1 };

            Console.WriteLine("O valor da distância máxima dos valores adjacentes é : " + GetAdjacentPointsMaxDistance(vectorEx) + "\n");

            Console.WriteLine("Por favor informe o tamanho do seu vetor.");

            int length = Convert.ToInt32(Console.ReadLine());

            var vector = new int[length];
            Console.WriteLine("Por favor informe " + length + " números inteiros.");
            for (int i = 0; i < length; i++)
            {
                vector[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("O valor da distância máxima dos valores adjacentes é : " + GetAdjacentPointsMaxDistance(vector));

            Console.ReadKey();
        }
    }
}
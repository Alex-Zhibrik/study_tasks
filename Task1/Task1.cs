namespace Task1
{
    internal class Program
    {

        static int x;
        static int y;

        static double a;
        static double b;
        static double c;
        static void Main(string[] args)
        {
            
        }

        static void ReplaceToNull()
        {
            if (x < y) 
            {
                x = 0;
            }
            else if (y < x) 
            {
                y = 0;
            } 
            else 
            {
                y = 0;
                x = 0;
            }
        }

        static void DecreaseBiggest()
        {
            if (a > b && a > c) 
            {
                a -= 0.3;
            }
            else if (b > c && b > a) 
            {
                b -= 0.3;
            } 
            else
            {
                c -= 0.3;
            }
        }

    }
}

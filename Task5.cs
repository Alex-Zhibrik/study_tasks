namespace Task3
{
    internal class Program
    {
        static double z;

        static void Main(string[] args)
        {
            var a = Convert.ToDouble(Console.ReadLine);
            var b = Convert.ToDouble(Console.ReadLine);
            var c = Convert.ToDouble(Console.ReadLine);
            var d = Convert.ToDouble(Console.ReadLine);

            if (c >= d && a < d)
            {
                z = a + b / c;
            }
            else if (c < d && a >= d)
            {
                z = a - b / c;
            }
            else
            {
                z = 0;
            }
        }

       
    }
}

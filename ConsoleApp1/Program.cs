namespace ConsoleApp1
{
    internal class Program
    {
        static String date;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату вашего рождения например 20.01.2004");

            date = Console.ReadLine();
            int days = GetDays(GetParams(date));
            Console.WriteLine($"Вы прожили {days} дней");

        }

        static int[] GetParams(string param)
        {
            int[] iParams = new int[param.Length];
            string[] sParams = param.Split(new char[] { '.' });
            iParams[0] = int.Parse(sParams[0]);
            iParams[1] = int.Parse(sParams[1]);
            iParams[2] = int.Parse(sParams[2]);

            return iParams;
        }
        static int GetDays(int[] date)
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);           
            Console.WriteLine(now);
            DateTime birtday = new DateTime(date[2], date[1], date[0]);
            Console.WriteLine(birtday);
            int counter = 0;
            while (!now.Equals(birtday))
            {
                counter++;
                birtday = birtday.AddDays(1);
                Console.WriteLine(birtday);
            }
            return counter;
        }
    }
}

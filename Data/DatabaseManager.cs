using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiraSodaBot.Data
{
    public class DatabaseManager
    {
        public static void IncrementCounter(int amount)
        {
            int count = 0;
            using (var sr = new StreamReader("counter.txt"))
            {
                count = int.Parse(sr.ReadLine());
                sr.Close();
            }
            count += amount;
            using (var sw = new StreamWriter("counter.txt"))
            {
                sw.WriteLine(count);
                sw.Flush();
                sw.Close();
            }
        }

        public static int ReadCounter()
        {
            int count = 0;
            using (var sr = new StreamReader("counter.txt"))
            {
                count = int.Parse(sr.ReadLine());
            }
            return count;
        }
    }
}

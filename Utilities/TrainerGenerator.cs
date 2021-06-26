using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SearchingSortingPagination.Utilities
{
    public class TrainerGenerator
    {
        public Random Rand { get; private set; }
        public TrainerGenerator()
        {
            Rand = new Random();
        }
        private static string[] fields =
        {
            "Logic", "Mathematics", "Statistics", "Systems Theory", "Decision Theory", "Computer Science",
            "Physics", "Chemistry", "Earth Science", "Astronomy", "Biochemistry", "Microbiology", 
            "Botany", "Zoology", "Ecology", "Sociology", "Psychology", "Medicine", "Economics"
        };
        public static List<Tuple<string, string>> GetFullNames()
        {
            string line;
            StreamReader file = new StreamReader(@"C:\Users\const\Desktop\SearchingSortingPagination\Utilities\ReportFile.txt");

            List<Tuple<string, string>> list = new List<Tuple<string, string>>();

            while ((line = file.ReadLine()) != null)
            {
                string firstname = line.Substring(0, FirstEnd(line));
                string lastname = line.Substring(LastStart(FirstEnd(line), line));
                list.Add(Tuple.Create(firstname, lastname));
            }
            return list;
        }

        /// <summary>
        /// Returns the position of the first character that doesn't belong to the first name.
        /// </summary>
        static int FirstEnd(string s)
        {
            int count;
            for (count = 0; count < s.Length; count++)
            {
                if (s[count] == ' ' && s[count + 1] == ' ' && s[count + 2] == ' ')
                {
                    break;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the position of the first character that belongs to the last name.
        /// </summary>
        static int LastStart(int start, string s)
        {
            for (; start < s.Length; start++)
                if (s[start] != ' ')
                    break;
            return start;
        }
        /// <summary>
        /// Returns a monetary value as a decimal type (values have up to 2 fractional digits). The value may range from 0 to x.
        /// </summary>
        public decimal GetMoney(int lower=500, int upper=3000)
        {
            decimal lo = Math.Abs(lower);
            decimal up = Math.Abs(upper);
            return Math.Round((decimal)Rand.NextDouble() * (up-lo) + lo, 2);
        }

        /// <summary>
        /// Returns a date between the given dates (start and end inclusive).
        /// </summary>
        /// <param name="past"></param>
        /// <param name="future"></param>
        /// <returns></returns>
        public DateTime RandDate(DateTime past, DateTime future)
        {
            if (DateTime.Compare(past, future) > 0)
            {
                DateTime temp = past;
                past = future;
                future = temp;
            }
            int year = 0;
            try
            {
                year = Rand.Next(past.Year, future.Year + 1);
            }
            catch (Exception e)
            {
                throw e;
            }

            int minmonth = year == past.Year ? past.Month : 1;
            int maxmonth = year == future.Year ? future.Month : 12;
            int month = Rand.Next(minmonth, maxmonth + 1);

            int minday = (year == past.Year && month == past.Month) ? past.Day : 1;
            int maxday = (year == future.Year && month == future.Month) ? future.Day : DateTime.DaysInMonth(year, month);
            int day = Rand.Next(minday, maxday+1);

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Gets a valid chance (between 0 and 1) and returns if the event occurs.
        /// </summary>
        /// <param name="w">If w is negative, its absolute value will be taken into account. If it is greater than 1, it will be divided until it isn't.</param>
        /// <returns>True if the event occurs, otherwise false.</returns>
        public bool GetChance(double w = 0.5)
        {
            w = Math.Abs(w);
            while (w > 1.0)
            {
                w /= 10.0;
            }
            return Rand.NextDouble() > w ? false : true;
        }
    }
}
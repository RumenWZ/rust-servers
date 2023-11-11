namespace API.Models
{
    public class RustServer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Region { get; set; }
        public int DaysUntilWipe { get; set; }
        public int? TeamLimit { get; set; }
        public string BattleMetricsUrl { get; set; }
        public int LootGatherRate { get; set; }

        public List<DateTime> CalculateWipeDays()
        {
            List<DateTime> wipeDays = new List<DateTime>();

            // Get the first Thursday of the current month
            DateTime firstThursday = GetFirstThursdayOfMonth(DateTime.Now.Year, DateTime.Now.Month);

            // Add the first wipe day
            wipeDays.Add(firstThursday);

            // Calculate subsequent wipe days based on DaysUntilWipe
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                DateTime nextWipeDay = firstThursday.AddDays(i * DaysUntilWipe);
                if (nextWipeDay.Month == DateTime.Now.Month)
                {
                    wipeDays.Add(nextWipeDay);
                }
                else
                {
                    break; // Stop when the next wipe day is in the next month
                }
            }

            return wipeDays;
        }

        private DateTime GetFirstThursdayOfMonth(int year, int month)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysUntilThursday = (int)DayOfWeek.Thursday - (int)firstDayOfMonth.DayOfWeek;
            if (daysUntilThursday < 0)
            {
                daysUntilThursday += 7;
            }
            return firstDayOfMonth.AddDays(daysUntilThursday);
        }
    }

    
}

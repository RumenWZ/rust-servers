namespace API.DTOs
{
    public class ServerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Region { get; set; }
        public int DaysUntilWipe { get; set; }
        public int? TeamLimit { get; set; }
        public string BattleMetricsUrl { get; set; }
        public int LootGatherRate { get; set; }
        public List<DateTime> WipeDates { get; set; }
    }
}

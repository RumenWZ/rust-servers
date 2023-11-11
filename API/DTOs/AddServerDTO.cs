namespace API.DTOs
{
    public class AddServerDTO
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Region { get; set; }
        public int DaysUntilWipe { get; set; }
        public int? TeamLimit { get; set; }
        public string BattleMetricsUrl { get; set; }
        public int LootGatherRate { get; set; }
    }
}

namespace CountriesApi.Shared
{
    public class Country
    {
        public string Name { get; set; }
        public string Native { get; set; }
        public int[] Phone { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
        public string[] Currency { get; set; }
        public string[] Languages { get; set; }
    }
}

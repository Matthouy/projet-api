namespace APIprojet.Models
{
    public class FastFoodDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PlatsCollectionName { get; set; } = null!;

        public string MenuCollectionName { get; set; } = null!;
    }
}

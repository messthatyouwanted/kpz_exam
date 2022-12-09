
namespace WpfClient.Model
{
    public class SportItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public SportType Type { get; set; }
    }
    public enum SportType
    {
        Football, Volleyball, Basketball, Golf
    }
}

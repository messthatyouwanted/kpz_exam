using SportApi.DbReporsitory.Enums;

namespace SportApi.DbReporsitory.Models
{
    public class GoodsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public SportType Type { get; set; }
    }
}

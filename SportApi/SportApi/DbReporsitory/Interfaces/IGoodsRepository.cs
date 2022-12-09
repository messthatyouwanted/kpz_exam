using SportApi.DbReporsitory.Enums;
using SportApi.DbReporsitory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportApi.DbReporsitory.Interfaces
{
    public interface IGoodsRepository
    {
        public Task<List<GoodsModel>> GetGoods();
        public Task<List<GoodsModel>> GetGoodsByType(SportType type);

        public Task<GoodsModel> AddNewSportItem(GoodsModel itemEntity);

        public Task RemoveItem(GoodsModel itemEntity);

        public Task<GoodsModel> UpdateItem(GoodsModel itemEntity);
    }
}

using SportApi.DbReporsitory.Enums;
using SportApi.DbReporsitory.Interfaces;
using SportApi.DbReporsitory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.DbReporsitory.Reporsitory
{
    public class GoodsRepository : IGoodsRepository
    {
        private EfCoreContext GetContext()
        {
            return new EfCoreContext();
        }
        public async Task<GoodsModel> AddNewSportItem(GoodsModel itemEntity)
        {
            using(var dbcontext = GetContext())
            {
                dbcontext.Goods.Add(itemEntity);
                dbcontext.SaveChanges();
                return itemEntity;
            }
        }

        public async Task<List<GoodsModel>> GetGoods()
        {
            using (var dbcontext = GetContext())
            {
                return dbcontext.Goods.ToList();
            }
        }

        public async Task<List<GoodsModel>> GetGoodsByType(SportType type)
        {
            using (var dbcontext = GetContext())
            {
                return dbcontext.Goods.Where(item => item.Type == type).ToList();
            }
        }

        public async Task RemoveItem(GoodsModel itemEntity)
        {
            using (var dbcontext = GetContext())
            {
                dbcontext.Goods.Remove(itemEntity);
                dbcontext.SaveChanges();
            }
        }

        public async Task<GoodsModel> UpdateItem(GoodsModel itemEntity)
        {
            using (var dbcontext = GetContext())
            {
                var oldItem = dbcontext.Goods.FirstOrDefault(item => item.Id == itemEntity.Id);
                dbcontext.Goods.Remove(oldItem);
                dbcontext.Add(itemEntity);
                dbcontext.SaveChanges();
                return itemEntity;
            }
        }
    }
}

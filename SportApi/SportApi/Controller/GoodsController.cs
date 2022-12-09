using Microsoft.AspNetCore.Mvc;
using SportApi.DbReporsitory.Interfaces;
using SportApi.DbReporsitory.Models;
using System.Threading.Tasks;

namespace SportApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsRepository _goodsRepository;
        public GoodsController(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Goods()
        {
            try
            {
                return Ok(await _goodsRepository.GetGoods());
            }
            catch (System.Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddNewItem(GoodsModel item)
        {
            try
            {
                return Ok(_goodsRepository.AddNewSportItem(item));
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(GoodsModel item)
        {
            try
            {
                return Ok(_goodsRepository.UpdateItem(item));
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(GoodsModel item)
        {
            try
            {
                return Ok(_goodsRepository.RemoveItem(item));
            }
            catch (System.Exception ex)
            {
                return NotFound();
            }
        }
    }
}

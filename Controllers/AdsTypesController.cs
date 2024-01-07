using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GovBE.Models;
using GovBE.Commons;

namespace GovBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsTypesController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;

        public AdsTypesController(GovBE_DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lấy thông tin bảng adstype
        /// </summary>
        /// <returns></returns>
        // GET: api/AdsTypes
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<Adstype>>> GetAdstypes()
        {
            if (_context.Adstypes == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Adstype not found"
                };
            }

            var data = await _context.Adstypes.ToListAsync();
            return new()
            {
                IsError = false,
                Data = data,
                Status = 200
            };
        }

        /// <summary>
        ///  Lấy thông tin adstype của id vừa nhập
        /// </summary>
        /// <param name="id">id của adstype muốn tìm kiếm</param>
        /// <returns></returns>
        // GET: api/AdsTypes/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<Adstype>> GetAdstype(int id)
        {
            if (_context.Adstypes == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Adstype not found"
                };
            }
            var adstype = await _context.Adstypes.FindAsync(id);

            if (adstype == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Adstype not found"
                };
            }

            return new()
            {
                IsError = false,
                Data = adstype
            }; ;
        }

        /// <summary>
        /// Update thông tin adstype của id vừa nhập
        /// </summary>
        /// <param name="id">id của adstype muốn chỉnh sửa</param>
        /// <param name="adstype"></param>
        /// <returns></returns>
        // PUT: api/AdsTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutAdstype(int id, Adstype adstype)
        {
            if (id != adstype.AdsTypeId)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Update failed !!!"
                };
            }

            _context.Entry(adstype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdstypeExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        ErrorMessage = "Ads type not found"
                    };
                }
                else
                {
                    throw;
                }
            }

            return new()
            {
                IsError = false,
                Data = true,
            };
        }
        /// <summary>
        /// Thêm 1 adstype mới
        /// </summary>
        /// <param name="adstype">thông tin adstype mới</param>
        /// <returns></returns>
        // POST: api/AdsTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<bool>> PostAdstype(Adstype adstype)
        {
            if (_context.Adstypes == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'GovBE_DatabaseContext.Adstypes'  is null.",
                    Data = true,
                };
            }
            _context.Adstypes.Add(adstype);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false,
                Data = true,
            };
        }
        /// <summary>
        /// Xóa 1 adstype theo id vừa nhập
        /// </summary>
        /// <param name="id">id của adstype muốn xóa</param>
        /// <returns></returns>
        // DELETE: api/AdsTypes/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteAdstype(int id)
        {
            if (_context.Adstypes == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ads type not found"
                };
            }
            var adstype = await _context.Adstypes.FindAsync(id);
            if (adstype == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ads type not found"
                };
            }

            _context.Adstypes.Remove(adstype);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false,
                Data = true,
            };
        }

        private bool AdstypeExists(int id)
        {
            return (_context.Adstypes?.Any(e => e.AdsTypeId == id)).GetValueOrDefault();
        }
    }
}

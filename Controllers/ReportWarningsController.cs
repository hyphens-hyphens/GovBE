using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GovBE.Models;
using GovBE.Commons;

namespace GovBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportWarningsController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;
        private readonly ILogger<ReportWarningsController> _logger;
        public ReportWarningsController(GovBE_DatabaseContext context, ILogger<ReportWarningsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Lấy thông tin bảng reportwarning
        /// </summary>
        /// <returns></returns>
        // GET: api/ReportWarnings
        [HttpGet]
        public async Task<BaseResponse<List<ReportWarning>>> GetReportWarnings()
        {
            _logger.LogInformation("Call ReportWarningsController.GetReportWarnings");
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }

            var list = await (from a in _context.Reportwarnings
                                 from b in _context.Adsnews.Where(x => x.AdsNewId == a.AdsNewId)
                                 select new ReportWarning()
                                 {
                                     Latitude = b.Latitude,
                                     Longtitude = b.Longtitude,
                                     AdsLocationId = a.AdsLocationId,
                                     AdsNewId = a.AdsNewId,
                                     Comment = a.Comment,
                                     CreateOnUtc = a.CreateOnUtc,
                                     CreateUserId = a.CreateUserId,
                                     Email = a.Email,
                                     FullName = a.FullName,
                                     IsActive = a.IsActive,
                                     LastUpdateOnUtc = a.LastUpdateOnUtc,
                                     PhoneNumber = a.PhoneNumber,
                                     ReportWarningId = a.ReportWarningId,
                                     ReportWarningStatus = a.ReportWarningStatus,
                                     WarningType = a.WarningType
                                 }).ToListAsync();

            return new BaseResponse<List<ReportWarning>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }

        /// <summary>
        /// Lấy thông tin reportwarning của id vừa nhập
        /// </summary>
        /// <param name="id">id của reportwarning muốn tìm kiếm</param>
        /// <returns></returns>
        // GET: api/ReportWarnings/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<ReportWarning?>> GetReportwarning(int id)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }
            //var reportWarning = await _context.Reportwarnings.FindAsync(id);

            var reportWarning = await (from a in _context.Reportwarnings
                         from b in _context.Adsnews.Where(x => x.AdsNewId == a.AdsNewId)
                         select new ReportWarning()
                         {
                             Latitude = b.Latitude,
                             Longtitude = b.Longtitude,
                             AdsLocationId = a.AdsLocationId,
                             AdsNewId = a.AdsNewId,
                             Comment = a.Comment,
                             CreateOnUtc = a.CreateOnUtc,
                             CreateUserId = a.CreateUserId,
                             Email = a.Email,
                             FullName = a.FullName,
                             IsActive = a.IsActive,
                             LastUpdateOnUtc = a.LastUpdateOnUtc,
                             PhoneNumber = a.PhoneNumber,
                             ReportWarningId = a.ReportWarningId,
                             ReportWarningStatus = a.ReportWarningStatus,
                             WarningType = a.WarningType
                         }).FirstOrDefaultAsync();

            if (reportWarning == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }

            return new()
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = reportWarning,
                IsError = false
            };
        }

        /// <summary>
        /// Update thông tin 1 reportwarning của id vừa nhập
        /// </summary>
        /// <param name="id">id của reportwarning muốn chỉnh sửa</param>
        /// <param name="reportwarning"></param>
        /// <returns></returns>
        // PUT: api/ReportWarnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutReportwarning(int id, ReportWarning reportwarning)
        {
            if (id != reportwarning.ReportWarningId)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Update failed"
                };
            }

            _context.Entry(reportwarning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportwarningExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        Data = new(),
                        ErrorMessage = "Report warning not found"
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
            };
        }

        /// <summary>
        /// Thêm 1 reportwarning mới
        /// </summary>
        /// <param name="reportWarning">Thông tin của reportwarning mới</param>
        /// <returns></returns>
        // POST: api/ReportWarnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<ReportWarning>> PostReportwarning(ReportWarning reportWarning)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'Reportwarnings'  is null."
                };
            }

            if (!_context.Adsnews.Any(x => x.AdsNewId == reportWarning.AdsNewId))
            {
                var newAds = new Adsnew()
                {
                    AdsAddress = $"{reportWarning.Comment}",
                    Latitude = reportWarning.Latitude,
                    CreateOnUtc = DateTime.Now,
                    Longtitude = reportWarning.Longtitude,
                    IsActive = true,
                };
                _context.Adsnews.Add(newAds);
                await _context.SaveChangesAsync();

                reportWarning.AdsNewId = newAds.AdsNewId;
            }

            _context.Reportwarnings.Add(reportWarning);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        /// <summary>
        /// Xóa 1 reportwarning theo id
        /// </summary>
        /// <param name="id">id của reportwarning muốn xóa</param>
        /// <returns></returns>
        // DELETE: api/ReportWarnings/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteReportwarning(int id)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Report warning context not found."
                };
            }
            var reportwarning = await _context.Reportwarnings.FindAsync(id);
            if (reportwarning == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Report warning not found."
                };
            }

            _context.Reportwarnings.Remove(reportwarning);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }


        [HttpPost("update-status")]
        public async Task<BaseResponse<bool>> UpdateStatus([FromBody] UpdateStatusRequest request)
        {
            var reportWarning = await _context.Reportwarnings.FindAsync(request.Id);

            if (reportWarning == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }
            reportWarning.ReportWarningStatus = request.ToString();
            _context.Entry(reportWarning).State = EntityState.Modified;

            return new()
            {
                IsError = false
            };
        }


        [HttpGet("report-warning-by-point")]
        public async Task<BaseResponse<ReportWarning>> GetReportWarningByPoint(PointPosition pointPosition)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }

            var reportWarning = await
                (from a in _context.Reportwarnings
                from b in _context.Adsnews.Where(x => x.AdsNewId == a.AdsNewId
                    && x.Longtitude == pointPosition.Longtitude && x.Latitude == pointPosition.Latitude)
                select new ReportWarning()
                {
                    Latitude = pointPosition.Latitude,
                    Longtitude = pointPosition.Longtitude,
                    AdsLocationId = a.AdsLocationId,
                    AdsNewId = a.AdsNewId,
                    Comment = a.Comment,
                    CreateOnUtc = a.CreateOnUtc,
                    CreateUserId = a.CreateUserId,
                    Email = a.Email,
                    FullName = a.FullName,
                    IsActive = a.IsActive,
                    LastUpdateOnUtc = a.LastUpdateOnUtc,
                    PhoneNumber = a.PhoneNumber,
                    ReportWarningId = a.ReportWarningId,
                    ReportWarningStatus = a.ReportWarningStatus,
                    WarningType = a.WarningType
                } ).FirstOrDefaultAsync();

            if (reportWarning == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }

            return new BaseResponse<ReportWarning>
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = reportWarning,
                IsError = false
            };
        }

        private bool ReportwarningExists(int id)
        {
            return (_context.Reportwarnings?.Any(e => e.ReportWarningId == id)).GetValueOrDefault();
        }
    }

    public class ReportWarning : Reportwarning
    {
        public decimal? Longtitude { get; set; }
        public decimal? Latitude { get; set; }
    }

    public class UpdateStatusRequest
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}

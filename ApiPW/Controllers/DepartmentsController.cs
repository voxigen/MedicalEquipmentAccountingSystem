using ApiPW.Data;
using ApiPW.Models;
using ApiPW.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var departments = await _context.Departments
                    .Include(d => d.Equipment)
                    .ToListAsync();

                var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

                return Ok(new ApiResponse<IEnumerable<DepartmentDto>>
                {
                    Success = true,
                    Data = departmentDtos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<IEnumerable<DepartmentDto>>
                {
                    Success = false,
                    Message = "Ошибка при получении отделений",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var department = await _context.Departments
                    .Include(d => d.Equipment)
                    .FirstOrDefaultAsync(d => d.Id == id);

                if (department == null)
                {
                    return NotFound(new ApiResponse<DepartmentDto>
                    {
                        Success = false,
                        Message = "Отделение не найдено"
                    });
                }

                var departmentDto = _mapper.Map<DepartmentDto>(department);

                return Ok(new ApiResponse<DepartmentDto>
                {
                    Success = true,
                    Data = departmentDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<DepartmentDto>
                {
                    Success = false,
                    Message = "Ошибка при получении отделения",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResponse { Success = false, Message = "Неверные данные" });

                var department = _mapper.Map<Department>(createDto);
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();

                var departmentDto = _mapper.Map<DepartmentDto>(department);

                return CreatedAtAction(nameof(GetById), new { id = department.Id }, new ApiResponse<DepartmentDto>
                {
                    Success = true,
                    Data = departmentDto,
                    Message = "Отделение создано успешно"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<DepartmentDto>
                {
                    Success = false,
                    Message = "Ошибка при создании отделения",
                    Error = ex.Message
                });
            }
        }
    }
}
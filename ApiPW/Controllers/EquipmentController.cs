using ApiPW.Models;
using ApiPW.Models.DTOs;
using ApiPW.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiPW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _equipmentService.GetAllEquipmentAsync();
            return StatusCode(response.Success ? 200 : 400, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _equipmentService.GetEquipmentByIdAsync(id);
            return StatusCode(response.Success ? 200 : 404, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse { Success = false, Message = "Неверные данные" });

            var response = await _equipmentService.CreateEquipmentAsync(createDto);
            return StatusCode(response.Success ? 201 : 400, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEquipmentDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse { Success = false, Message = "Неверные данные" });

            var response = await _equipmentService.UpdateEquipmentAsync(id, updateDto);
            return StatusCode(response.Success ? 200 : 404, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _equipmentService.DeleteEquipmentAsync(id);
            return StatusCode(response.Success ? 200 : 404, response);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(EquipmentStatus status)
        {
            var response = await _equipmentService.GetEquipmentByStatusAsync(status);
            return StatusCode(response.Success ? 200 : 400, response);
        }
    }
}
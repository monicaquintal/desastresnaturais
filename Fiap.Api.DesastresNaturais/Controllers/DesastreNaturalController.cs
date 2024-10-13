using AutoMapper;
using Fiap.Api.DesastresNaturais.Data.Contexts;
using Fiap.Api.DesastresNaturais.Models;
using Fiap.Api.DesastresNaturais.Services;
using Fiap.Api.DesastresNaturais.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Api.DesastresNaturais.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesastreNaturalController : ControllerBase
    {
        private readonly IDesastreNaturalService _service;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public DesastreNaturalController(IDesastreNaturalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DesastreNaturalViewModel>> Get()
        {
            var desastre = _service.ListarDesastreNatural();
            var viewModelList = _mapper.Map<IEnumerable<RegistrarDesastreNaturalModel>>(desastre);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<DesastreNaturalViewModel> Get(int id)
        {
            var desastre = _service.ObterDesastreNaturalPorId(id);
            if (desastre == null)
                return NotFound();

            var viewModel = _mapper.Map<DesastreNaturalViewModel>(desastre);
            return Ok(viewModel);
        }


        [HttpPost]
        public ActionResult Post([FromBody] DesastreNaturalCreateViewModel viewModel)
        {
            var desastre = _mapper.Map<RegistrarDesastreNaturalModel>(viewModel);
            _service.AdicionarDesastreNatural(desastre);
            return CreatedAtAction(nameof(Get), new { id = desastre.DesastreNaturalId }, desastre);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DesastreNaturalUpdateViewModel viewModel)
        {
            var desastreExistente = _service.ObterDesastreNaturalPorId(id);
            if (desastreExistente == null)
                return NotFound();

            _mapper.Map(viewModel, desastreExistente);
            _service.AtualizarDesastreNatural(desastreExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeletarDesastreNatural(id);
            return NoContent();
        }
    }
}
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<UsuarioViewModel>> Get() 
        {
            var usuario = _service.ListarUsuarios(); 
            var viewModelList = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuario); 
            return Ok(viewModelList); 
        }

        [HttpGet("{id}")] 
        public ActionResult<UsuarioViewModel> Get(int id) 
        {
            var usuario = _service.ObterUsuarioPorId(id); 
            if (usuario == null) 
                return NotFound(); 
            
            var viewModel = _mapper.Map<UsuarioViewModel>(usuario); 
            return Ok(viewModel);
        }


        [HttpPost]
        public ActionResult Post([FromBody] UsuarioCreateViewModel viewModel)
        {
            var usuario = _mapper.Map<UsuarioModel>(viewModel);
            _service.CriarUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioUpdateViewModel viewModel)
        {
            var usuarioExistente = _service.ObterUsuarioPorId(id);
            if (usuarioExistente == null)
                return NotFound();

            _mapper.Map(viewModel, usuarioExistente);
            _service.AtualizarUsuario(usuarioExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeletarUsuario(id);
            return NoContent();
        }
    }
}
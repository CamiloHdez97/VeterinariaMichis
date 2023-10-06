using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class LaboratoryController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public LaboratoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratoryDto>>> Get()
    {
        var Con = await  _unitofwork.Laboratories.GetAllAsync();
        return _mapper.Map<List<LaboratoryDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratoryDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Laboratories.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<LaboratoryDto>>(pag.registros);
        return new Pager<LaboratoryDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }





   /*  [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratoryxPersonDto>>> Get11([FromQuery] Params rolParams)
    {
        var Con = await  _unitofwork.Laboratories.GetAllAsync(rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
        var lstrol = _mapper.Map<List<LaboratoryxPersonDto>>(Con.registros);
        return new Pager<LaboratoryxPersonDto>(lstrol,Con.totalRegistros,rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
    }
 */
 
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Laboratories.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratory>> Post(LaboratoryDto LaboratoryDto){
        var rol = _mapper.Map<Laboratory>(LaboratoryDto);
        this._unitofwork.Laboratories.Add(rol);
        await _unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
      //  LaboratoryDto.Id = rol.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= LaboratoryDto.ID_Laboratorio}, LaboratoryDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratory>> Put(int id, [FromBody]Laboratory rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Laboratories.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Laboratories.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Laboratories.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}
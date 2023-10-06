using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class MovementDetailController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public MovementDetailController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovementDetailDto>>> Get()
    {
        var Con = await  _unitofwork.MovementDetails.GetAllAsync();
        return _mapper.Map<List<MovementDetailDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovementDetailDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.MovementDetails.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<MovementDetailDto>>(pag.registros);
        return new Pager<MovementDetailDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }





   /*  [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovementDetailxPersonDto>>> Get11([FromQuery] Params rolParams)
    {
        var Con = await  _unitofwork.MovementDetails.GetAllAsync(rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
        var lstrol = _mapper.Map<List<MovementDetailxPersonDto>>(Con.registros);
        return new Pager<MovementDetailxPersonDto>(lstrol,Con.totalRegistros,rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
    }
 */
 
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.MovementDetails.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovementDetail>> Post(MovementDetailDto MovementDetailDto){
        var rol = _mapper.Map<MovementDetail>(MovementDetailDto);
        this._unitofwork.MovementDetails.Add(rol);
        await _unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
       // MovementDetailDto.Id = rol.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= MovementDetailDto.ID_Salida}, MovementDetailDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovementDetail>> Put(int id, [FromBody]MovementDetail rol){
        if(rol == null)
            return NotFound();
        _unitofwork.MovementDetails.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.MovementDetails.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.MovementDetails.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}
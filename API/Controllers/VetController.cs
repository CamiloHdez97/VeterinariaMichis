using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Core.Interfaces;
using Core.Entities;
using API.Controllers;

namespace API.Controller;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class VetContvetler : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public VetContvetler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VetDto>>> Get()
    {
        var Con = await  _unitofwork.Vets.GetAllAsync();
        return _mapper.Map<List<VetDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VetDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Vets.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<VetDto>>(pag.registros);
        return new Pager<VetDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }





   /*  [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VetxPersonDto>>> Get11([FromQuery] Params vetParams)
    {
        var Con = await  _unitofwork.Vets.GetAllAsync(vetParams.PageIndex,vetParams.PageSize,vetParams.Search);
        var lstvet = _mapper.Map<List<VetxPersonDto>>(Con.registros);
        return new Pager<VetxPersonDto>(lstvet,Con.totalRegistros,vetParams.PageIndex,vetParams.PageSize,vetParams.Search);
    }
 */
 
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Vets.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Vet>> Post(VetDto vetDto){
        var vet = _mapper.Map<Vet>(vetDto);
        this._unitofwork.Vets.Add(vet);
        await _unitofwork.SaveAsync();
        if(vet == null)
        {
            return BadRequest();
        }
        //vetDto.Id = vet.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= vetDto.ID_Vet}, vetDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Vet>> Put(int id, [FromBody]Vet vet){
        if(vet == null)
            return NotFound();
        _unitofwork.Vets.Update(vet);
        await _unitofwork.SaveAsync();
        return vet;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Vets.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Vets.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}
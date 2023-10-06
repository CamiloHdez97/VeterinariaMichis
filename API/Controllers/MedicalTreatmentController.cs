using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class MedicalTreatmentController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public MedicalTreatmentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicalTreatmentDto>>> Get()
    {
        var Con = await  _unitofwork.MedicalTreatments.GetAllAsync();
        return _mapper.Map<List<MedicalTreatmentDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicalTreatmentDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.MedicalTreatments.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<MedicalTreatmentDto>>(pag.registros);
        return new Pager<MedicalTreatmentDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }





   /*  [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicalTreatmentxPersonDto>>> Get11([FromQuery] Params rolParams)
    {
        var Con = await  _unitofwork.MedicalTreatments.GetAllAsync(rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
        var lstrol = _mapper.Map<List<MedicalTreatmentxPersonDto>>(Con.registros);
        return new Pager<MedicalTreatmentxPersonDto>(lstrol,Con.totalRegistros,rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
    }
 */
 
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.MedicalTreatments.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicalTreatment>> Post(MedicalTreatmentDto MedicalTreatmentDto){
        var rol = _mapper.Map<MedicalTreatment>(MedicalTreatmentDto);
        this._unitofwork.MedicalTreatments.Add(rol);
        await _unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
        //MedicalTreatmentDto.ID_Tratamiento = rol.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= MedicalTreatmentDto.ID_Tratamiento}, MedicalTreatmentDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicalTreatment>> Put(int id, [FromBody]MedicalTreatment rol){
        if(rol == null)
            return NotFound();
        _unitofwork.MedicalTreatments.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.MedicalTreatments.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.MedicalTreatments.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}
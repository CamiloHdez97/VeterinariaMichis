using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class MedicineController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public MedicineController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicineDto>>> Get()
    {
        var Con = await  _unitofwork.Medicines.GetAllAsync();
        return _mapper.Map<List<MedicineDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicineDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Medicines.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<MedicineDto>>(pag.registros);
        return new Pager<MedicineDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }





   /*  [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicinexPersonDto>>> Get11([FromQuery] Params rolParams)
    {
        var Con = await  _unitofwork.Medicines.GetAllAsync(rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
        var lstrol = _mapper.Map<List<MedicinexPersonDto>>(Con.registros);
        return new Pager<MedicinexPersonDto>(lstrol,Con.totalRegistros,rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
    }
 */
 
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Medicines.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicine>> Post(MedicineDto MedicineDto){
        var rol = _mapper.Map<Medicine>(MedicineDto);
        this._unitofwork.Medicines.Add(rol);
        await _unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
       // MedicineDto.Id = rol.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= MedicineDto.ID_medicamento}, MedicineDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicine>> Put(int id, [FromBody]Medicine rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Medicines.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Medicines.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Medicines.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}
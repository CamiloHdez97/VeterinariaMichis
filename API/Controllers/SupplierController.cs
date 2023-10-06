using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class SupplierController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public SupplierController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
    {
        var Con = await  _unitofwork.Suppliers.GetAllAsync();
        return _mapper.Map<List<SupplierDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<SupplierDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Suppliers.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<SupplierDto>>(pag.registros);
        return new Pager<SupplierDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }





   /*  [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<SupplierxPersonDto>>> Get11([FromQuery] Params rolParams)
    {
        var Con = await  _unitofwork.Suppliers.GetAllAsync(rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
        var lstrol = _mapper.Map<List<SupplierxPersonDto>>(Con.registros);
        return new Pager<SupplierxPersonDto>(lstrol,Con.totalRegistros,rolParams.PageIndex,rolParams.PageSize,rolParams.Search);
    }
 */
 
     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Suppliers.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Supplier>> Post(SupplierDto SupplierDto){
        var rol = _mapper.Map<Supplier>(SupplierDto);
        this._unitofwork.Suppliers.Add(rol);
        await _unitofwork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
     //   SupplierDto.Id = rol.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= SupplierDto.ID_Proveedo}, SupplierDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Supplier>> Put(int id, [FromBody]Supplier rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Suppliers.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Suppliers.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Suppliers.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}
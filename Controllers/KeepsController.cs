using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _kr;
    public KeepsController(KeepRepository kr)
    {
      _kr = kr;
    }
    //GetAll
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null) { return BadRequest(); }
      return Ok(results);
    }
    //GetByUserId
    [HttpGet("user")]
    [Authorize]
    public ActionResult<Keep> GetByUserId()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> found = _kr.GetByUserId(userId);
      if (found == null) { return BadRequest("No"); }
      return Ok(found);
    }
    //GetByVaultId
    [HttpGet("{vaultId}")]
    public ActionResult<Keep> GetByVaultId(int vaultId)
    {
      Keep found = _kr.GetByVaultId(vaultId);
      if (found == null) { return BadRequest("No"); }
      return Ok(found);
    }
    //GetById
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      Keep found = _kr.GetById(id);
      if (found == null) { return BadRequest("No"); }
      return Ok(found);
    }

    //Create
    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Create([FromBody] Keep nKeep)
    {
      nKeep.UserId = HttpContext.User.Identity.Name;
      Keep newKeep = _kr.CreateKeep(nKeep);
      if (newKeep == null) { return BadRequest("No make new Keep"); }
      return Ok(newKeep);
    }

    //Edit
    // [HttpPut("{id}")]
    // public ActionResult<Keep> Edit(int id, [FromBody] Keep editedKeep)
    // {
    //   Keep updatedKeep = _kr.EditKeep(id, editedKeep);
    //   if (updatedKeep == null) { return BadRequest("No edit keep"); }
    //   return Ok(updatedKeep);
    // }

    //Delete
    [HttpDelete("{id}")]

    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful) { return BadRequest("No Delete"); }
      return Ok();
    }
  }
}
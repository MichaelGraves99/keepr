using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _vr;
    public VaultsController(VaultRepository vr)
    {
      _vr = vr;
    }
    // //GetAll
    // [HttpGet]
    // public ActionResult<IEnumerable<Vault>> Get()
    // {
    //   IEnumerable<Vault> results = _vr.GetALL();
    //   if (results == null) { return BadRequest(); }
    //   return Ok(results);
    // }

    //GetByUserId
    [HttpGet]
    [Authorize]
    public ActionResult<Vault> GetVaultById(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Vault> found = _vr.GetVaultById(userId);
      if (found == null) { return BadRequest("No"); }
      return Ok(found);
    }
    //Create
    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Create([FromBody] Vault nVault)
    {
      nVault.UserId = HttpContext.User.Identity.Name;
      Vault newVault = _vr.CreateVault(nVault);
      if (newVault == null) { return BadRequest("No make new Vault"); }
      return Ok(newVault);
    }

    //Edit
    // [HttpPut("{id}")]
    // public ActionResult<Vault> Edit(int id, [FromBody] Vault editedVault)
    // {
    //   Vault updatedVault = _vr.EditVault(id, editedVault);
    //   if (updatedVault == null) { return BadRequest("No edit Vault"); }
    //   return Ok(updatedVault);
    // }

    //Delete
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.Delete(id);
      if (!successful) { return BadRequest("No Delete"); }
      return Ok();
    }
  }
}
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _vkr;
    public VaultKeepsController(VaultKeepRepository vkr)
    {
      _vkr = vkr;
    }
    //GetAll
    // [HttpGet]
    // public ActionResult<IEnumerable<VaultKeep>> Get()
    // {
    //   IEnumerable<VaultKeep> results = _vkr.GetALL();
    //   if (results == null) { return BadRequest(); }
    //   return Ok(results);
    // }
    //GetById
    [HttpGet("{vaultId}")]
    [Authorize]
    public ActionResult<Keep> Get(int vaultId)
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> found = _vkr.GetById(vaultId, UserId);
      if (found == null) { return BadRequest("No"); }
      return Ok(found);
    }

    //Create
    [HttpPost]
    [Authorize]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep nVaultKeep)
    {
      nVaultKeep.UserId = HttpContext.User.Identity.Name;
      VaultKeep newVaultKeep = _vkr.CreateVaultKeep(nVaultKeep);
      if (newVaultKeep == null) { return BadRequest("No make new VaultKeep"); }
      return Ok(newVaultKeep);
    }

    //Edit
    // [HttpPut("{id}")]
    // public ActionResult<VaultKeep> Edit(int id, [FromBody] VaultKeep editedVaultKeep)
    // {
    //   VaultKeep updatedVaultKeep = _vkr.EditVaultKeep(id, editedVaultKeep);
    //   if (updatedVaultKeep == null) { return BadRequest("No edit VaultKeep"); }
    //   return Ok(updatedVaultKeep);
    // }

    //Delete
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.Delete(id);
      if (!successful) { return BadRequest("No Delete"); }
      return Ok();
    }
  }
}
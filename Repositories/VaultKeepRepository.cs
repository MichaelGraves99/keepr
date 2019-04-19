using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }


    //Get by id
    public IEnumerable<Keep> GetById(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId AND vk.userId = @userId) ", new { vaultId, userId });
    }


    //Create VaultKeep
    public VaultKeep CreateVaultKeep(VaultKeep nVaultKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
          INSERT INTO vaultkeeps (vaultId, keepId, userId)
          VALUES (@VaultId, @KeepId, @UserId);
          SELECT LAST_INSERT_ID()", nVaultKeep);
        nVaultKeep.Id = id;
        return nVaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    //Delete VaultKeep
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE id = @Id", new { id });
      return success > 0;
    }

  }
}
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    // // Get all
    // public IEnumerable<Vault> GetALL()
    // {
    //   return _db.Query<Vault>("SELECT * FROM vaults");
    // }

    //Get vault by user id
    public IEnumerable<Vault> GetVaultById(string UserId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId", new { UserId });
    }
    // //Get vault by vault id
    // public Vault GetVaultByVaultId(int Id)
    // {
    //   return _db.Query<Vault>("SELECT * FROM vaults WHERE Id = @Id", new { Id });
    // }

    //Create Vault
    public Vault CreateVault(Vault nVault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
          INSERT INTO vaults (name, description, userId)
          VALUES (@Name, @Description, @UserId);
          SELECT LAST_INSERT_ID()", nVault);
        nVault.Id = id;
        return nVault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    //Delete Vault
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @Id", new { id });
      return success > 0;
    }

  }
}

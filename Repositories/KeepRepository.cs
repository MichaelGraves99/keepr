using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    // Get all
    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    //Get by userId
    public IEnumerable<Keep> GetByUserId(string UserId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @UserId", new { UserId });
    }

    //Get by vaultId
    public Keep GetByVaultId(int VaultId)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE vaultId = @VaultId", new { VaultId });
    }

    //Get by id
    public Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
    }

    //Create keep
    public Keep CreateKeep(Keep nKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
          INSERT INTO keeps (name, description, userId, img)
          VALUES (@Name, @Description, @UserId, @Img);
          SELECT LAST_INSERT_ID()", nKeep);
        nKeep.Id = id;
        return nKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    //Delete keep
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @Id", new { id });
      return success > 0;
    }

  }
}



// CREATE TABLE vaultkeeps(
//     id int NOT NULL AUTO_INCREMENT,
//     vaultId int NOT NULL,
//     keepId int NOT NULL,
//     userId VARCHAR(255) NOT NULL,

//     PRIMARY KEY(id),
//     INDEX(vaultId, keepId),
//     INDEX(userId),

//     FOREIGN KEY(userId)
//         REFERENCES users(id)
//         ON DELETE CASCADE,

//     FOREIGN KEY(vaultId)
//         REFERENCES vaults(id)
//         ON DELETE CASCADE,

//     FOREIGN KEY(keepId)
//         REFERENCES keeps(id)
//         ON DELETE CASCADE
// )

using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }

    public string UserId { get; set; }

  }
}
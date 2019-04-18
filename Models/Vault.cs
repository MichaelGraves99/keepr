// CREATE TABLE vaults(
//     id int NOT NULL AUTO_INCREMENT,
//     name VARCHAR(20) NOT NULL,
//     description VARCHAR(255) NOT NULL,
//     userId VARCHAR(255),
//     INDEX userId(userId),
//     FOREIGN KEY(userId)
//         REFERENCES users(id)
//         ON DELETE CASCADE,  
//     PRIMARY KEY(id)
// );

using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}
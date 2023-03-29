using System.ComponentModel.DataAnnotations;

namespace StudentAccount.Orchestrators.Class.Contract;

public class EditClass
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int DurationInMinutes { get; set; }
}
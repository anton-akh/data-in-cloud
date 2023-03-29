using System.ComponentModel.DataAnnotations;

namespace StudentAccount.Orchestrators.Student.Contract;

public class EditStudent
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}
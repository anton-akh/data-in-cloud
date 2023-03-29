using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAccount.Dal.Student;

[Table("Student")]
public class StudentDao
{
    [Column("id"), Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("second_name")]
    public string LastName { get; set; }
}
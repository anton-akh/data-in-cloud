using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAccount.Dal.Class;

public class ClassDao
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int DurationInMinutes { get; set; }
}
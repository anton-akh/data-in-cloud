using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAccount.Orchestrators.Class.Contract
{
    public class CreateClass
    {
        [Required]
        public string Name { get; set; }
        [Required, Range(typeof(int), "0", "120")]
        public int DurationInMinutes { get; set; }
    }
}

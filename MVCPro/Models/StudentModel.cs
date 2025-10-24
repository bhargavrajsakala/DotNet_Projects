using System.ComponentModel.DataAnnotations;

namespace MVCPro.Models;

public class StudentModel
{
  [Required(ErrorMessage = "StudentId is Mandatory")]
  public int StudentId { get; set; }
  //[Required(ErrorMessage = "Name is Required.")]   
  [StringLength(10, MinimumLength = 2, ErrorMessage = "Name cannot exceed 20 characters and have atleast 2 character.")] 
  public string? Name { get; set; }
  [Range(15, 22, ErrorMessage = "Age should be between 15 and 22")] 
  public int Age { get; set; }
  [EmailAddress(ErrorMessage = "Invalid Email Address.")] 
  public string? Email { get; set; }
}
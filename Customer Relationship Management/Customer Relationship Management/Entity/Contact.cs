public class Contact
{
   
    public required int Id { get; set; }

    
    public required int UserId { get; set; }

    
    public required string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }

    
    public required string? PhoneNumber { get; set;}
    public string? Email { get; set; }
    public User? User { get; set; } 


    public required StatusEnum ContactStatus { get; set; }


    public required DateTime LastChangeContact { get; set; } 


}

 

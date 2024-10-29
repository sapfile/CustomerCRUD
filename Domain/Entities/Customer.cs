namespace Domain.Entities;

public class Customer : EntityBase
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }

    public int Age { get; set; }
}
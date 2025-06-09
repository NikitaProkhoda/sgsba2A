namespace Test2A.Models;

public class Purchase
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public float Price { get; set; }
    public int? Rating { get; set; }
    public int CustomerId { get; set; }
    public int WashingMachineId { get; set; }
    public int ProgramId { get; set; }
    public Customer Customer { get; set; }
    public WashingMachine WashingMachine { get; set; }
    public WashingProgram Program { get; set; }
}
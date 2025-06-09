namespace Test2A.Models;

public class WashingMachine
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = null!;
    public float MaxWeight { get; set; }

    public ICollection<Purchase> Purchases { get; set; }
    public ICollection<WashingMachineProgram> WashingMachinePrograms { get; set; }
}

namespace Test2A.Models;

public class WashingProgram
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Duration { get; set; }
    public ICollection<WashingMachineProgram> WashingMachinePrograms { get; set; }
}
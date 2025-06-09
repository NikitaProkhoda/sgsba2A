namespace Test2A.Models;

public class WashingMachineProgram
{
    public int WashingMachineId { get; set; }
    public int ProgramId { get; set; }
    public float Price { get; set; }
    public WashingMachine WashingMachine { get; set; }
    public WashingProgram Program { get; set; }
}
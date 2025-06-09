namespace Test2A.DTOs;

public class PurchaseDTO
{
    public DateTime Date { get; set; }
    public float Price { get; set; }
    public int? Rating { get; set; }
    public string WashingMachineSerial { get; set; }
    public string ProgramName { get; set; }
    public int ProgramDuration { get; set; }
}
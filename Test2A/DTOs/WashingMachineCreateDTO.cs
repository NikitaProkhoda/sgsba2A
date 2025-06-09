namespace Test2A.DTOs;

public class WashingMachineCreateDTO
{
    public string SerialNumber { get; set; } = null!;
    public float MaxWeight { get; set; }
    public List<ProgramPriceDTO> Programs { get; set; }
}
using Test2A.DTOs;

namespace Test2A.Services;

public interface IWashingMachineService
{
    Task<List<PurchaseDTO>> GetCustomerHistory(int customerId);
    Task AddWashingMachineAsync(WashingMachineCreateDTO dto);
}
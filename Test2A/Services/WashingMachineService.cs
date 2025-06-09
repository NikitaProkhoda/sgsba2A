using Microsoft.EntityFrameworkCore;
using Test2A.Data;
using Test2A.DTOs;
using Test2A.Models;

namespace Test2A.Services;

public class WashingMachineService : IWashingMachineService
{
    private readonly AppDbContext _context;
    public WashingMachineService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PurchaseDTO>> GetCustomerHistory(int customerId)
    {
        return await _context.Purchases
            .Where(p => p.CustomerId == customerId)
            .Select(p => new PurchaseDTO
            {
                Date = p.Date,
                Price = p.Price,
                Rating = p.Rating,
                WashingMachineSerial = p.WashingMachine.SerialNumber,
                ProgramName = p.Program.Name,
                ProgramDuration = p.Program.Duration
            }).ToListAsync();
    }

    public async Task AddWashingMachineAsync(WashingMachineCreateDTO dto)
    {
        if (await _context.WashingMachines.AnyAsync(w => w.SerialNumber == dto.SerialNumber))
            throw new Exception("Washing machine with this serial number already exists.");

        var washingMachine = new WashingMachine
        {
            SerialNumber = dto.SerialNumber,
            MaxWeight = dto.MaxWeight,
            WashingMachinePrograms = new List<WashingMachineProgram>()
        };

        foreach (var programDto in dto.Programs)
        {
            var program = await _context.Programs
                .FirstOrDefaultAsync(p => p.Name == programDto.Name && p.Duration == programDto.Duration);

            if (program == null)
            {
                program = new WashingProgram
                {
                    Name = programDto.Name,
                    Duration = programDto.Duration
                };
                _context.Programs.Add(program);
                await _context.SaveChangesAsync();
            }

            washingMachine.WashingMachinePrograms.Add(new WashingMachineProgram
            {
                ProgramId = program.Id,
                Price = programDto.Price
            });
        }

        _context.WashingMachines.Add(washingMachine);
        await _context.SaveChangesAsync();
    }
}
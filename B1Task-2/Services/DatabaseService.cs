using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using B1Task_2.Models;
using Microsoft.EntityFrameworkCore;

namespace B1Task_2.Services;

public class DatabaseService
{
    private const int Class1InitialLine = 10;
    private const int Class2InitialLine = 84;
    private const int Class3InitialLine = 187;
    private const int Class4InitialLine = 271;
    private const int Class5InitialLine = 298;
    private const int Class6InitialLine = 330;
    private const int Class7InitialLine = 441;
    private const int Class8InitialLine = 454;
    private const int Class9InitialLine = 518;

    private static readonly ApplicationContext applicationContext = new();

    public async Task<bool> AddData(string filePath)
    {
        try
        {
            var fileService = new FileServices();

            var dataOffAllClasses = fileService.ReadFromFile(filePath, 
                Class1InitialLine, Class2InitialLine - 2);
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class2InitialLine, Class3InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class3InitialLine, Class4InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class4InitialLine, Class5InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class5InitialLine, Class6InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class6InitialLine, Class7InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class7InitialLine, Class8InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class8InitialLine, Class9InitialLine - 2));
        
            dataOffAllClasses.AddRange(fileService.ReadFromFile(filePath, 
                Class9InitialLine, Class9InitialLine + 108));

            await applicationContext.Classes.AddRangeAsync(dataOffAllClasses);
            await applicationContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<List<BaseClassModel>> GetData(int id)
    {
        var list = await applicationContext.Classes.ToListAsync();
        
        var resultList = list.GetRange(id * 610, 609);

        return resultList;
    }

    public async Task<bool> AddFile(string filePath)
    {
        try
        {
            var addedFile = new AddedFile
            {
                Title = filePath,
                Data = DateTime.Now
            };

            await applicationContext.AddAsync(addedFile);
            await applicationContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<AddedFile>> GetFile()
    {
        var list = await applicationContext.AddedFiles.ToListAsync();

        return list;
    }
}
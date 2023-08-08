namespace B1Task_2.Models;

public class BaseClassModel
{
    public int Id { get; set; }
    
    public string? Bc { get; set; }
    
    public double OpeningBalanceAssets { get; set; }
        
    public double OpeningBalancePassive { get; set; }
    
    public double TurnoversAssets { get; set; }
    
    public double TurnoversPassive { get; set; }
    
    public double OutgoingBalanceAssets { get; set; }
    
    public double OutgoingBalancePassive { get; set; }
}
using Project_Backend_2024.DTO;
namespace BudgetTracker.Models {
  public class Goal {
    public int Id {get;set;}
    public string Name {get;set;} = "";
    public decimal TargetAmount {get;set;}
    public DateTime TargetDate {get;set;} = DateTime.UtcNow.AddMonths(6);
  }
}
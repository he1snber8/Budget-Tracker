using Project_Backend_2024.DTO;
namespace BudgetTracker.Models {
  public class Expense {
    public int Id {get;set;}
    public string Category {get;set;} = "";
    public decimal Amount {get;set;}
    public DateTime Date {get;set;} = DateTime.UtcNow;
  }
}
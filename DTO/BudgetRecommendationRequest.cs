using Project_Backend_2024.DTO;
namespace BudgetTracker.DTO {
  public class BudgetRecommendationRequest {
    public decimal Income {get;set;}
    public IEnumerable<BudgetTracker.Models.Expense>? Expenses {get;set;}
  }
}
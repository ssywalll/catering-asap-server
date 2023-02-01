using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.FoodDrinkOrders.Queries.GetFoodDrinkOrders
{
    public class FoodDrinkOrderDto : IMapFrom<FoodDrinkOrder>
    {
        public int Id { get; set; }
        public int Food_Drink_Id { get; set; }
        public int Order_Id { get; set; }
    }
}
<Query Kind="Program">
  <Connection>
    <ID>e193b4dd-1844-4202-9965-651ad595080d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	var results = from food in Items 
			where food.MenuCategory.Description.Equals("Entree") && 
				food.Active
			orderby food.CurrentPrice descending
			select new FoodMargin()
			{
				Description = food.Description,
				Price = food.CurrentPrice, 
				Cost = food.CurrentCost,
				Profit = food.CurrentPrice - food.CurrentCost
			};
	results.Dump();
	
	var orders_results = from orders in Bills
			where orders.PaidStatus && 
				orders.BillDate.Month == 9 && 
				orders.BillDate.Year == 2014
			orderby orders.Waiter.LastName, orders.Waiter.FirstName
			select new BillOrders()
			{
				BillID = orders.BillID,
				Waiter = orders.Waiter.LastName + ", " + orders.Waiter.FirstName,
				Orders = orders.BillItems			
			};
			
	orders_results.Dump();
}

// Define other methods and classes here
// Sample of a POCO type class: flat data set no stuctures
public class FoodMargin {

	public string Description { get; set; }
	public decimal Price { get; set; }
	public decimal Cost { get; set; }
	public decimal Profit { get; set; }

	public FoodMargin() {
	
	}
	
}


public class BillOrders {
	
	public int BillID { get; set; }
	public string Waiter {get; set; }
	public IEnumerable Orders { get; set; }
	
}
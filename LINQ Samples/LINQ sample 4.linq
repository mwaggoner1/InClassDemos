<Query Kind="Expression">
  <Connection>
    <ID>e193b4dd-1844-4202-9965-651ad595080d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// more anonymous types
from food in Items 
where food.MenuCategory.Description.Equals("Entree") && 
	food.Active
orderby food.CurrentPrice descending
select new
	{
		Description = food.Description,
		Price = food.CurrentPrice, 
		Cost = food.CurrentCost,
		Profit = food.CurrentPrice - food.CurrentCost
	}
<Query Kind="Expression">
  <Connection>
    <ID>e193b4dd-1844-4202-9965-651ad595080d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// view the waiter data
Waiters

// query syntax to view waiter data
from item in Waiters
select item

// method syntax to view waiter data
Waiters.Select(item => item)

/*   Simple Where Clause   */

// list all tables with more than 3 seats
from item in Tables 
where item.Capacity > 3
select item

// list all items with more than 500 calories
from item in Items
where item.Calories > 500
select item


// list all items with mre than 500 calories and sells for less than $10 
from item in Items
where item.Calories > 500 && item.CurrentPrice < 10
select item

// navigate across tables.
from item in Items
where item.MenuCategory.Description == "Entree"
select item





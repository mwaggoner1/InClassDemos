<Query Kind="Expression">
  <Connection>
    <ID>e193b4dd-1844-4202-9965-651ad595080d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// orderby clause

// default ascending.
from food in Items
orderby food.Description
select food

// change to descending
from food in Items
orderby food.Description descending
select food

// orderby multiple
from food in Items
orderby food.MenuCategoryID descending, food.CurrentPrice ascending
where food.Calories < 600
select food
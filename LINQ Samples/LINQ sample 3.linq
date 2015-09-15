<Query Kind="Expression">
  <Connection>
    <ID>e193b4dd-1844-4202-9965-651ad595080d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// grouping

from food in Items
group food by food.MenuCategory.Description 

// requires the creation of an anonymous type
from food in Items
group food by new {food.MenuCategory.Description, food.CurrentPrice}
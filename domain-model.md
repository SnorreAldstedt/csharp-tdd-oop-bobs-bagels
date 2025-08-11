# Domain Model
```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
```

```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```

```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```

```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```

```
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```

```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```

```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```

```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```

```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```
## Core
| Class | Method/Property | Scenario | Output |
|-------|-----------------|----------|--------|
| Basket | AddItem(IStoreItem item) | Add an Item to a Basket | void |
| Basket | RemoveItem(IStoreItem item) | Remove an Item to a Basket | void |
| Basket | IsFull() | Checks if basket is full | bool |
| Store | ChangeCap() | Changes capacity of baskets | void |
| Basket | BasketHas(IStoreItem item) | Checks if basket has item | bool |
| Basket | Remove(StoreItem item) | Removes item from basket if the basket has that item | void |
| Basket | TotalCost() | Returns total cost of Basket | int | 
| Store | Price(IStoreItem item) | Returns price of Item | int | <!-- This method is relevant for both user story 9 and 7 -->
| Bagel | AddFillings(Filling filling)  | Add filling to bagel | void |
| Bagel | GetTotalPrice()  | Get total cost of bagel including fillings | Decimal |
| IStoreItem | Interface with methods for products | Interface for bagel, filling and coffee |  |
| IStoreItem | Price | attribute that has the price of an IStoreItem | int |
| Store | GetInventory() | function that returns the inventory of the store | List<IStoreItem> |
| IStoreItem | Copy() | function to copy a storeItem, makes it easier to choose a bagel/coffee/filling from a menu | IStoreItem |
| IStoreItem | Equivalent(IstoreItem item) | Checks wheter an item is equivalent to the instance it's called on| bool |


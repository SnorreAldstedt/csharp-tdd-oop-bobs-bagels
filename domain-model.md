# Domain Model

## Core
| Class | Method/Property | Scenario | Output |
|-------|-----------------|----------|--------|
| Basket | AddItem(StoreItem item) | Add an Item to a Basket | void |
| Basket | RemoveItem(StoreItem item) | Remove an Item to a Basket | void |
| Basket | IsFull() | Checks if basket is full | bool |
| Store | ChangeCap() | Changes capacity of baskets | void |
| Basket | BasketHas(StoreItem item) | Checks if basket has item | bool |
| Basket | TotalCost() | Returns total cost of Basket | int | 
| Store | Price(StoreItem item) | Returns price of Item | int | <!-- This method is relevant for both user story 9 and 7 -->
| Bagel | AddFillings(Filling filling)  | Add filling to bagel | void |
| StoreItem | checkCost() | function that checks cost for an Item | int |

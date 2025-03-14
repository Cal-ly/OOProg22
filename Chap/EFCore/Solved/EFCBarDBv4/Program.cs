﻿
Console.WriteLine("Test of IDataService interfaces");
Console.WriteLine();


// Initialize data services
ICocktailDataService ctDataService = new EFCoreCocktailDataService();
IIngredientDataService ingDataService = new EFCoreIngredientDataService();
Helpers.PrintList(ctDataService.GetAll());


// Get ingredients
Ingredient? gin = ingDataService.ReadByName("Gin");
Ingredient? rum = ingDataService.ReadByName("Rum");
Ingredient? tonic = ingDataService.ReadByName("Tonic");
Ingredient? fanta = ingDataService.ReadByName("Fanta");
if ((gin is null) || (rum is null) || (tonic is null) || (fanta is null))
{
	throw new ArgumentException("One of the ingredients were missing...");
}


// Create a new cocktail
List<CocktailIngredient> ciList = new List<CocktailIngredient>
{
	new CocktailIngredient() { IngredientId = gin.Id,   AmountInCl =  3 },
	new CocktailIngredient() { IngredientId = rum.Id,   AmountInCl =  3 },
	new CocktailIngredient() { IngredientId = tonic.Id, AmountInCl = 10 },
	new CocktailIngredient() { IngredientId = fanta.Id, AmountInCl = 10 }
};

Cocktail cocktail = new Cocktail() { Name = "SubZero", CocktailIngredients = ciList.ToHashSet() };
int newId = ctDataService.Create(cocktail);
Helpers.PrintList(ctDataService.GetAll());


// Delete the new cocktail
ctDataService.Delete(newId);
Helpers.PrintList(ctDataService.GetAll());


// Read a single cocktail
Cocktail? ct = ctDataService.Read(2);
Console.WriteLine(ct);


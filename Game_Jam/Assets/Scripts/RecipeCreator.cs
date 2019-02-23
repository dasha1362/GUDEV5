using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public enum Ingredient 
{
	Strawberry, 
	Blueberries, 
	Apricot, 
	Blackberries, 
	Sugar, 
	Water
}

public class RecipeCreator : MonoBehaviour
{

	public Ingredient p1Fruit;
	public Ingredient p2Fruit;
	public List<Ingredient> p1Recipe;
	public List<Ingredient> p2Recipe;
	public int recipeLength;

    // Start is called before the first frame update
    void Start()
    {
    	p1Fruit = (Ingredient)UnityEngine.Random.Range(0, 3);
    	p2Fruit = (Ingredient)UnityEngine.Random.Range(0, 3);
    	while (p2Fruit == p1Fruit)
    	{
    		p2Fruit = (Ingredient)UnityEngine.Random.Range(0, 3);
    	}
    	int numP1Fruits = UnityEngine.Random.Range((recipeLength / 2) - 1, (recipeLength / 2) + 2);
    	int numP2Fruits = UnityEngine.Random.Range((recipeLength / 2) - 1, (recipeLength / 2) + 2);
    	int numP1Sugar = UnityEngine.Random.Range(((recipeLength - numP1Fruits) / 2) - 1, ((recipeLength - numP1Fruits) / 2) + 2);
    	int numP2Sugar = UnityEngine.Random.Range(((recipeLength - numP2Fruits) / 2) - 1, ((recipeLength - numP2Fruits) / 2) + 2);
    	int numP1Water = Math.Max(1, (recipeLength - numP1Fruits - numP1Sugar));
    	int numP2Water = Math.Max(1, (recipeLength - numP2Fruits - numP2Sugar));
    	if ((numP1Fruits + numP1Sugar + numP1Water) > recipeLength) { numP1Sugar--; }
    	if ((numP2Fruits + numP2Sugar + numP2Water) > recipeLength) { numP2Sugar--; }
    	for (int i = 0; i < numP1Fruits; i++) { p1Recipe.Add(p1Fruit); }
    	for (int i = numP1Fruits; i < numP1Fruits + numP1Sugar; i++) { p1Recipe.Add(Ingredient.Sugar); }
    	for (int i = numP1Fruits + numP1Sugar; i < recipeLength; i++) { p1Recipe.Add(Ingredient.Water); }
    	for (int i = 0; i < numP2Fruits; i++) { p2Recipe.Add(p2Fruit); }
    	for (int i = numP2Fruits; i < numP2Fruits + numP2Sugar; i++) { p2Recipe.Add(Ingredient.Sugar); }
    	for (int i = numP2Fruits + numP2Sugar; i < recipeLength; i++) { p2Recipe.Add(Ingredient.Water); }
    	System.Random rnd = new System.Random();
    	p1Recipe = p1Recipe.OrderBy(item => rnd.Next()).ToList();
    	p2Recipe = p2Recipe.OrderBy(item => rnd.Next()).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

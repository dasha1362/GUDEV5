using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

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
    int p1Progress;
    int p2Progress;
	public int recipeLength;
	public Image p1NextIngredient;
	public Image p1NextNextIngredient;
	public Image p2NextIngredient;
	public Image p2NextNextIngredient;
	public Sprite strawberrySprite;
	public Sprite blueberrySprite;
	public Sprite blackberrySprite;
	public Sprite apricotSprite;
	public Sprite sugarSprite;
	public Sprite waterSprite;


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
        p1Progress = 0;
        p2Progress = 0;


		setNextIngedient(p1Recipe[p1Progress], 1);
		setNextIngedient(p2Recipe[p2Progress], 2);
		setNextNextIngedient(p1Recipe[p1Progress+1], 1);
		setNextNextIngedient(p2Recipe[p2Progress+1], 2);
    }

    public void IngredientGathered(Ingredient ingred, int playerNum)
    {
        if (playerNum == 1 && ingred == p1Recipe[p1Progress])
        {
            p1Progress++;

			setNextIngedient(p1Recipe[p1Progress], playerNum);



			if (p1Progress+1 <= recipeLength){
				setNextNextIngedient(p1Recipe[p1Progress+1], playerNum);
			}


        }
        else if (playerNum == 2 && ingred == p2Recipe[p2Progress])
        {
            p2Progress++;

			setNextIngedient(p2Recipe[p2Progress], playerNum);

			if (p1Progress+1 <= recipeLength){
				setNextNextIngedient(p2Recipe[p2Progress+1], playerNum);
			}
        }
        if (p1Progress == recipeLength)
        {
            // TODO PLAYER 1 WINS
            print("Player 1 wins");
        }
        else if (p2Progress == recipeLength)
        {
            // TODO PLAYER 2 WINS
            print("Player 2 wins");
        }
    }

	void setNextIngedient(Ingredient ingred, int playerNum){
		if (playerNum == 1) {
			switch (ingred){
				case Ingredient.Strawberry:
					Debug.Log(playerNum);
					Debug.Log("Strawberry");
					p1NextIngredient.sprite = strawberrySprite;
					break;
				case Ingredient.Blueberries:
					Debug.Log("Strawberry");
					p1NextIngredient.sprite = blueberrySprite;
					break;
				case Ingredient.Apricot:
					Debug.Log("Strawberry");
					p1NextIngredient.sprite = apricotSprite;
					break;
				case Ingredient.Blackberries:
					Debug.Log("Strawberry");
					p1NextIngredient.sprite = blackberrySprite;
					break;
				case Ingredient.Sugar:
					Debug.Log("Strawberry");
					p1NextIngredient.sprite = sugarSprite;
					break;
				case Ingredient.Water:
					Debug.Log("Strawberry");
					p1NextIngredient.sprite = waterSprite;
					break;
			}
		} else {
			switch (ingred){
				case Ingredient.Strawberry:
					p2NextIngredient.sprite = strawberrySprite;
					break;
				case Ingredient.Blueberries:
					p2NextIngredient.sprite = blueberrySprite;
					break;
				case Ingredient.Apricot:
					p2NextIngredient.sprite = apricotSprite;
					break;
				case Ingredient.Blackberries:
					p2NextIngredient.sprite = blackberrySprite;
					break;
				case Ingredient.Sugar:
					p2NextIngredient.sprite = sugarSprite;
					break;
				case Ingredient.Water:
					p2NextIngredient.sprite = waterSprite;
					break;
			}
		}
	}


	void setNextNextIngedient(Ingredient ingred, int playerNum){
		if (playerNum == 1) {
			switch (ingred){
				case Ingredient.Strawberry:
					p1NextNextIngredient.sprite = strawberrySprite;
					break;
				case Ingredient.Blueberries:
					p1NextNextIngredient.sprite = blueberrySprite;
					break;
				case Ingredient.Apricot:
					p1NextNextIngredient.sprite = apricotSprite;
					break;
				case Ingredient.Blackberries:
					p1NextNextIngredient.sprite = blackberrySprite;
					break;
				case Ingredient.Sugar:
					p1NextNextIngredient.sprite = sugarSprite;
					break;
				case Ingredient.Water:
					p1NextNextIngredient.sprite = waterSprite;
					break;
			}
		} else {
			switch (ingred){
				case Ingredient.Strawberry:
					p2NextNextIngredient.sprite = strawberrySprite;
					break;
				case Ingredient.Blueberries:
					p2NextNextIngredient.sprite = blueberrySprite;
					break;
				case Ingredient.Apricot:
					p2NextNextIngredient.sprite = apricotSprite;
					break;
				case Ingredient.Blackberries:
					p2NextNextIngredient.sprite = blackberrySprite;
					break;
				case Ingredient.Sugar:
					p2NextNextIngredient.sprite = sugarSprite;
					break;
				case Ingredient.Water:
					p2NextNextIngredient.sprite = waterSprite;
					break;
			}
		}
	}
    // Update is called once per frame
    void Update()
    {

    }
}

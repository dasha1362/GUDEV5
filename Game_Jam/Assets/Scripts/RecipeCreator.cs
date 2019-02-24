using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TMPro;

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
    TextMeshProUGUI winText;
    GameObject player1;
    GameObject player2;
    public GameObject strawberryJam;
    public GameObject blueberryJam;
    public GameObject apricotJam;
    public GameObject blackberryJam;
    bool gameWon;

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
        winText = GameObject.FindWithTag("Finish").GetComponent<TextMeshProUGUI>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            if (p.GetComponent<PlayerController>().playerNum == 1)
            {
                player1 = p;
            }
            else if (p.GetComponent<PlayerController>().playerNum == 2)
            {
                player2 = p;
            }
        }
    }

    public void IngredientGathered(Ingredient ingred, int playerNum)
    {
        if (playerNum == 1 && ingred == p1Recipe[p1Progress])
        {
            p1Progress++;
        }
        else if (playerNum == 2 && ingred == p2Recipe[p2Progress])
        {
            p2Progress++;
        }

        if (p1Progress == recipeLength && !gameWon)
        {
            winText.text = "P1 Wins!!";
            gameWon = true;
            GameObject p1Jam;
            if (p1Fruit == Ingredient.Strawberry) 
            { 
                p1Jam = Instantiate(strawberryJam);
                var grabChecker = p1Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player1;
                grabChecker.isGrabbed = true;
                player1.GetComponent<PlayerController>().heldItem = p1Jam;
                player1.GetComponent<Animator>().SetBool("holding", true);
            }
            else if (p1Fruit == Ingredient.Blueberries) 
            {
                p1Jam = Instantiate(blueberryJam);
                var grabChecker = p1Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player1;
                grabChecker.isGrabbed = true;
                player1.GetComponent<PlayerController>().heldItem = p1Jam;
                player1.GetComponent<Animator>().SetBool("holding", true);
            }
            else if (p1Fruit == Ingredient.Apricot)
            {
                p1Jam = Instantiate(apricotJam);
                var grabChecker = p1Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player1;
                grabChecker.isGrabbed = true;
                player1.GetComponent<PlayerController>().heldItem = p1Jam;
                player1.GetComponent<Animator>().SetBool("holding", true);
            }
            else if (p1Fruit == Ingredient.Blackberries)
            {
                p1Jam = Instantiate(blackberryJam);
                var grabChecker = p1Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player1;
                grabChecker.isGrabbed = true;
                player1.GetComponent<PlayerController>().heldItem = p1Jam;
                player1.GetComponent<Animator>().SetBool("holding", true);
            }
        }
        if (p2Progress == recipeLength && !gameWon)
        {
            winText.text = "P2 Wins!!";
            gameWon = true;
            GameObject p2Jam;
            if (p2Fruit == Ingredient.Strawberry) 
            { 
                p2Jam = Instantiate(strawberryJam);
                var grabChecker = p2Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player2;
                grabChecker.isGrabbed = true;
                player2.GetComponent<PlayerController>().heldItem = p2Jam;
                player2.GetComponent<Animator>().SetBool("holding", true);
            }
            else if (p2Fruit == Ingredient.Blueberries) 
            {
                p2Jam = Instantiate(blueberryJam);
                var grabChecker = p2Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player2;
                grabChecker.isGrabbed = true;
                player2.GetComponent<PlayerController>().heldItem = p2Jam;
                player2.GetComponent<Animator>().SetBool("holding", true);
            }
            else if (p2Fruit == Ingredient.Apricot)
            {
                p2Jam = Instantiate(apricotJam);
                var grabChecker = p2Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player2;
                grabChecker.isGrabbed = true;
                player2.GetComponent<PlayerController>().heldItem = p2Jam;
                player2.GetComponent<Animator>().SetBool("holding", true);
            }
            else if (p2Fruit == Ingredient.Blackberries)
            {
                p2Jam = Instantiate(blackberryJam);
                var grabChecker = p2Jam.GetComponent<GrabChecker>();
                grabChecker.holdingPlayer = player2;
                grabChecker.isGrabbed = true;
                player2.GetComponent<PlayerController>().heldItem = p2Jam;
                player2.GetComponent<Animator>().SetBool("holding", true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

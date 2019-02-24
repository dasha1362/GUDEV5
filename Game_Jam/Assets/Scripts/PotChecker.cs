using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class PotChecker : MonoBehaviour
{

    public int playerNum;
    GameObject Recipes;


    // Start is called before the first frame update
    void Start()
    {
        Recipes = GameObject.FindWithTag("GameController");
        InvokeRepeating(nameof(CheckSurroundingItems), 1, 1);
    }

    void CheckSurroundingItems()
    {
        var items = GameObject.FindGameObjectsWithTag("Ingredient")
            .Where(t => Vector3.Distance(t.transform.position ,transform.position) < 2.5 && t.GetComponent<GrabChecker>().LastPlayerNumber == playerNum && t.GetComponent<GrabChecker>().holdingPlayer == null).ToArray();
        foreach (var item in items)
        {
            string ingredName = item.name.Substring(0, item.name.Length - 7);
            Ingredient ingred;
            if (Enum.TryParse(ingredName, out ingred))
            {
                Recipes.GetComponent<RecipeCreator>().IngredientGathered(ingred, playerNum);
            }
            Destroy(item);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

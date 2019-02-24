using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayRecipe : MonoBehaviour
{
    public int playerNum;
    GameObject Recipes;

    // Start is called before the first frame update
    void Start()
    {
        Recipes = GameObject.FindWithTag("GameController");
    }

    void UpdateRecipeIndicator() {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

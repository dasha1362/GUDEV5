using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistingData
{
    private static Ingredient jam1, jam2;

    public static Ingredient Jam1
    {
        get
        {
            return jam1;
        }
        set
        {
            jam1 = value;
        }
    }

    public static Ingredient Jam2
    {
        get
        {
            return jam2;
        }
        set
        {
            jam2 = value;
        }
    }
}


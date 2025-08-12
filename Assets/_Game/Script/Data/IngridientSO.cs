using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "ScriptableObjects/IngredientSO", order = 1)]
public class IngridientSO : ScriptableObject
{
    public Ingredient igrd;

    [System.Serializable]
    public class Ingredient
    {
        public EIngredient eIngrType;
        public Sprite sprite;
    }
}

public enum EIngredient
{
    None,
    Lettuce,
    GrilledPatty,
    Cheese,
    Tomato,
    BurgerTop
}

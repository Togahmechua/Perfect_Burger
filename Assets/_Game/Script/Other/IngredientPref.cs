using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientPref : GameUnit
{
    [SerializeField] private SpriteRenderer spr;

    public void OnInit(Sprite sprite, int sortingOrder, Vector3 position)
    {
        transform.position = position;
        spr.sprite = sprite;
        spr.sortingOrder = sortingOrder;
    }
}

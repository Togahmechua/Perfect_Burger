using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : GameUnit, IPointerDownHandler
{
    [SerializeField] private EIngredient eIgrType;
    [SerializeField] private SpriteRenderer spr;

    [Header("Move Up")]
    [SerializeField] private float speed = 2f;

    private void OnEnable()
    {
        SetConfig(RecipeManager.Ins.GetRandomIngredientByEnum());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");

        AddIngredient();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Giới hạn x để không đi lệch ngang
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.5f, 1.5f);
        transform.position = pos;

        // Khi đến y = 6 thì despawn
        if (transform.position.y <= -5f)
        {
            SimplePool.Despawn(this);
        }
    }

    public void AddIngredient()
    {
        RecipeManager.Ins.TryAddIngredient(eIgrType);
    }

    public void SetConfig(IngridientSO ig)
    {
        eIgrType = ig.igrd.eIngrType;
        spr.sprite = ig.igrd.sprite;
    }
}

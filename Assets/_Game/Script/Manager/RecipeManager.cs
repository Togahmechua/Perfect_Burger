using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : Singleton<RecipeManager>
{
    [SerializeField] private List<IngridientSO> ingridientL = new List<IngridientSO>();
    [SerializeField] private RecipeSO recipe;

    private SpriteRenderer burgerSpr;
    private int currentOrderOffset = 0;
    private Vector3 currentSpawnPos;

    private int currentIngredientIndex = 0; // Vị trí đang check trong recipe


    public IngridientSO GetIngredientByEnum(EIngredient eIngredient)
    {
        foreach (var ingr in ingridientL)
        {
            if (ingr.igrd.eIngrType == eIngredient)
                return ingr;
        }
        return null;
    }

    public IngridientSO GetRandomIngredientByEnum()
    {
        return GetIngredientByEnum(RandomEnum());
    }

    private EIngredient RandomEnum()
    {
        EIngredient[] values = (EIngredient[])System.Enum.GetValues(typeof(EIngredient));

        //Bo qua None
        List<EIngredient> filteredValues = new List<EIngredient>(values);
        filteredValues.Remove(EIngredient.None);

        int rand = Random.Range(0, filteredValues.Count);
        return filteredValues[rand];
    }

    public void TryAddIngredient(EIngredient eIngredient)
    {
        if (eIngredient == EIngredient.None)
            return;

        // Nếu đã hoàn thành burger thì bỏ qua luôn
        if (currentIngredientIndex >= recipe.ingredients.Count)
        {
            Debug.Log("Burger đã hoàn thành! Không thể thêm nữa.");
            return;
        }

        IngridientSO correctIngr = recipe.ingredients[currentIngredientIndex];

        if (correctIngr.igrd.eIngrType == eIngredient)
        {
            SpawnIngredient(eIngredient);
            currentIngredientIndex++;

            if (currentIngredientIndex >= recipe.ingredients.Count)
            {
                Debug.Log("Burger hoàn thành!");
            }
        }
        else
        {
            Debug.Log($"Sai nguyên liệu! Cần: {correctIngr.igrd.eIngrType}");
        }
    }

    private void SpawnIngredient(EIngredient eIngredient)
    {
        if (burgerSpr == null)
        {
            burgerSpr = LevelManager.Ins.curLevel.burgerBottom.GetComponent<SpriteRenderer>();
        }

        currentSpawnPos += new Vector3(0f, 0.3f, 0f);
        currentOrderOffset++;

        Sprite sprite = GetIngredientByEnum(eIngredient).igrd.sprite;

        // Lấy từ pool thay vì Instantiate
        IngredientPref ingrObj = SimplePool.Spawn<IngredientPref>(PoolType.Food, currentSpawnPos, Quaternion.identity);
        ingrObj.OnInit(sprite, burgerSpr.sortingOrder + currentOrderOffset, LevelManager.Ins.curLevel.burgerBottom.transform.position + currentSpawnPos);
    }


    public void ResetBurgerStack()
    {
        currentOrderOffset = 0;
        currentSpawnPos = LevelManager.Ins.curLevel.burgerBottom.position;
        currentIngredientIndex = 0;
    }
}

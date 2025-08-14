using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform burgerBottom;
    public bool isDead;

    [SerializeField] private Canvas cv;
    //[SerializeField] private CameraAnchor[] camAnchor;

    private int MaxHP = 3;

    private void Start()
    {
        cv.renderMode = RenderMode.ScreenSpaceCamera;
        cv.worldCamera = Camera.main;

        UIManager.Ins.mainCanvas.ResetUI();
        RecipeManager.Ins.ResetBurgerStack();

        //StartCoroutine(IETurnOff());
    }

    /*private IEnumerator IETurnOff()
    {
        yield return new WaitForSeconds(1f);
        foreach (var cam in camAnchor)
        {
            cam.enabled = false;
        }
    }*/

    #region Damage Receiver
    public void TakeDamge()
    {
        MaxHP--;
        if (MaxHP <= 0)
        {
            isDead = true;
            AudioManager.Ins.PlaySFX(AudioManager.Ins.dead);
            UIManager.Ins.mainCanvas.Hit();
            Debug.Log("Die");

            Invoke(nameof(Loose), 1f);
        }
        else
        {
            AudioManager.Ins.PlaySFX(AudioManager.Ins.hurt);
            UIManager.Ins.mainCanvas.Hit();
            Debug.Log("Take Damge");
        }
    }

    private void Loose()
    {
        UIManager.Ins.TransitionUI<ChangeUICanvas, MainCanvas>(0.5f,
               () =>
               {
                   LevelManager.Ins.DespawnLevel();
                   UIManager.Ins.OpenUI<LooseCanvas>();
               });
    }
    #endregion
}

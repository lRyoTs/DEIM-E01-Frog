using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Frog frog;

    void Start()
    {
        //Configuration Frog
        GameObject frogGameObject = new GameObject("Frog Head");
        SpriteRenderer frogSpriteRenderer = frogGameObject.AddComponent<SpriteRenderer>();
        frogSpriteRenderer.sprite = GameAssets.Instance.frogSprite;
        frog = frogGameObject.AddComponent<Frog>();
    }
}

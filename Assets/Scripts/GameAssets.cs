using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    public Sprite frogSprite;

    void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There are more than 1 Instances");
        }

        Instance = this;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHealth : MonoBehaviour
{
    [HideInInspector]
    public HealthBar healthBar;
    public float startHealth;
    private float currentHeatlh;
    private List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    Color blinkColor = new Color(144, 104, 59, 159);
    private void Start()
    {
        foreach(SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>())
            sprites.Add(child);

        sprites.Add(GetComponent<SpriteRenderer>());

        currentHeatlh = startHealth;
    }
    public void TakeDmg(float amount = 1)
    {
        currentHeatlh -= amount;
        StartCoroutine(FadeSprite(0.3f, 5));
        healthBar.UpdateFillAmount(currentHeatlh / startHealth);
        if (currentHeatlh <= 0)
        {
            Death();
        }
    }
    IEnumerator FadeSprite(float delay, int amount)
    {
        float t = (delay / 2f);
        Color originalColor = sprites[0].color;
        for (int i = 0; i < amount; i++)
        {
            foreach(SpriteRenderer sprite in sprites)                        
                sprite.color = blinkColor;
            
            yield return new WaitForSeconds(t);
            foreach (SpriteRenderer sprite in sprites)
                sprite.color = originalColor;

            yield return new WaitForSeconds(t);
        }
    }
    void Death()
    {
        print(gameObject.name + " Lost");
    }
}
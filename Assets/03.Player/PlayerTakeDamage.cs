using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float reactionTime;
    private bool isDamaged = false;
    public void TakeDamage(int damage)
    {
        if(isDamaged) return;
        GameManager.instance.ReducePlayerHp(damage);
        isDamaged = true;
        StartCoroutine(DamageReaction());
    }

    IEnumerator DamageReaction()
    {
        float time = reactionTime;
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while(time >= 0)
        {
            if(spriteRenderer.color.a == 0)
            {
                spriteRenderer.color
            = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b, 255);
            }
            else
            {
                spriteRenderer.color
            = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b, 0);
            }
            time -= Time.deltaTime;
            time -= 0.1f;
            yield return wait;
        }

        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b, 255);
        isDamaged = false;
    }
}

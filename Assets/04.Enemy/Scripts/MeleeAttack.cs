using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    const string PLAYER = "Player";

    public GameObject hitEffect;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER))
        {
            int temp = other.GetComponent<PlayerTakeDamage>().TakeDamage(1);
            if(temp == 0) return;
            GameObject effect = Instantiate(hitEffect, other.transform.position, other.transform.rotation);
            Destroy(effect, 1.2f);
        }
    }
}

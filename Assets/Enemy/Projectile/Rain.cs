using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    const string PLAYER = "Player";
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER))
        {
            other.GetComponent<PlayerTakeDamage>().TakeDamage(1);
        }
    }
}

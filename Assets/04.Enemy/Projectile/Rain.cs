using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    const string PLAYER = "Player";
    const string WALL = "WALL";
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER))
        {
            other.GetComponent<PlayerTakeDamage>().TakeDamage(1);
            Destroy(gameObject);
        }
        if(other.CompareTag(WALL))
        {
            Destroy(gameObject);
        }
    }
}

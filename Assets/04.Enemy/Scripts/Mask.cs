using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    const string PLAYER = "Player";

    public GameObject hitEffect;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER))
        {
            if(GameManager.instance.GamePhase == 1)
            {
                other.GetComponent<PlayerMove>().SetFast();
            }
            if(GameManager.instance.GamePhase == 2)
            {
                other.GetComponent<PlayerMove>().SetSlow();
            }
            GameObject effect = Instantiate(hitEffect, other.transform.position, other.transform.rotation);
            Destroy(effect, 1.2f);
            Destroy(gameObject);
        }
    }
}

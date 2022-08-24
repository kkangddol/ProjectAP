using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCleaner : MonoBehaviour, ICaution
{

    public float[] magnetStrengths;
    
    public bool isWorking = false;
    public float activateTime;

    private void FixedUpdate() {
        if(!isWorking) return;

        Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach(var item in items)
        {
            if(item.CompareTag("Player"))
            {
                Vector2 direction = transform.position - item.transform.position;
                float distance = Vector2.Distance(transform.position, item.transform.position);
                float speed = (10f / distance) * magnetStrengths[0];
                item.GetComponent<Rigidbody2D>().AddForce(direction * speed);
            }
        }
    }

    public void Activate()
    {
        isWorking = true;
        Invoke("StopWork", activateTime);
    }

    void StopWork()
    {
        isWorking = false;
    }
}

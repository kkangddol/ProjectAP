using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCleaner : MonoBehaviour
{

    public float[] magnetStrengths;
    public float[] magnetLengths;
    
    public bool isWorking = false;
    public float activateTime;

    WaitForSeconds waitForAnimation;
    float waitTime = 1.5f;

    void Start()
    {
        waitForAnimation = new WaitForSeconds(waitTime);
        StartCoroutine(StartRoutine());
    }

    private void FixedUpdate() {
        if(!isWorking) return;

        Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach(var item in items)
        {
            if(item.CompareTag("Player"))
            {
                Vector2 direction = transform.position - item.transform.position;
                float distance = Vector2.Distance(transform.position, item.transform.position);
                float speed = (10f / distance) * magnetStrengths[GameManager.instance.GamePhase];
                item.GetComponent<Rigidbody2D>().AddForce(direction * speed);
            }
        }
    }

    IEnumerator StartRoutine()
    {
        yield return waitForAnimation;
        isWorking = true;
        StartCoroutine(StopRoutine());
    }

    IEnumerator StopRoutine()
    {
        yield return new WaitForSeconds(activateTime);
        
        isWorking = false;
        GetComponent<Animator>().SetTrigger("Disappear");
        yield return waitForAnimation;
        RainManager.instance.banThis = -1;
        Destroy(gameObject);
    }
}

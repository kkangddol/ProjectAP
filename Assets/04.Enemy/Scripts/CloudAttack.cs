using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAttack : MonoBehaviour
{
    public GameObject rainPrefab;
    public float rainSpeed;
    public float maxSpread;
    public int rainCount;
    public float rainInterval;
    WaitForSeconds waitForInterval;



    WaitForSeconds waitForAnimation;
    public int rainMode = 0;

    private float waitTime = 1.5f;

    void Start() {
        waitForAnimation = new WaitForSeconds(waitTime);
        waitForInterval = new WaitForSeconds(rainInterval);
        StartCoroutine(RainRoutine());
    }

    public void RainInit(int mode, int count, float speed)
    {
        rainMode = mode;
        rainCount = count;
        rainSpeed = speed;
    }


    IEnumerator RainRoutine()
    {
        yield return waitForAnimation;
        StartCoroutine(StartRain(rainMode));
        //StartRain(rainMode);
    }


    IEnumerator StartRain(int mode)
    {
        Vector2 direction;
        for(int i = 0; i < rainCount; i++)
        {
            direction = transform.up + new Vector3(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread));
            direction.Normalize();
            GameObject rain = Instantiate(rainPrefab, transform.position, transform.rotation);

            switch(mode)
            {
                case (int)RainMode.Spread:
                rain.transform.up = direction;
                rain.GetComponent<Rigidbody2D>().AddForce(direction * rainSpeed, ForceMode2D.Impulse);
                break;

                case (int)RainMode.Straight:
                rain.GetComponent<Rigidbody2D>().AddForce(transform.up * rainSpeed, ForceMode2D.Impulse);
                break;
            }
            
            yield return waitForInterval;
        }
        
        Destroy(gameObject);
    }
}

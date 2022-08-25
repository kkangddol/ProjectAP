using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatText : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float speed = 1.5f;
    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;

    float stopTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }

    void Stop()
    {
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        gameObject.SetActive(true);
        startPos = transform.position;
        Invoke("Stop", stopTime);
    }
}

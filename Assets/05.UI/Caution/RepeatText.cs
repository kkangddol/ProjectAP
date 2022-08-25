using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatText : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float speed = 1.5f;
    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;

    float stopTime = 8f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        gameObject.SetActive(false);
    }
}

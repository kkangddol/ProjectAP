using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskManager : MonoBehaviour
{
    public GameObject maskPrefab;
    public Transform[] fireTr;
    float fireDelay = 15f;
    float maskSpeed = 1.5f;

    GameObject player;
    
    bool isFired = false;

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {
        if(isFired) return;

        if(GameManager.instance.GamePhase >= 3) return;

        isFired = true;
        
        int index = Random.Range(0, fireTr.Length);
        GameObject mask = Instantiate(maskPrefab, fireTr[index].position, fireTr[index].rotation);
        mask.transform.up = (player.transform.position - fireTr[index].position).normalized;
        mask.GetComponent<Rigidbody2D>().AddForce(mask.transform.up * maskSpeed, ForceMode2D.Impulse);
        
        StartCoroutine(Cooling());
    }

    IEnumerator Cooling()
    {
        yield return new WaitForSeconds(fireDelay);
        isFired = false;
    }

}

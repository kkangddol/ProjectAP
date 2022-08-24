using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RainMode
{
    Spread,
    Straight,
}

public class RainManager : MonoBehaviour
{

    public Transform[] cloudPositions;
    public GameObject cloudPrefab;

    int count;

    private void Start() {
        count = cloudPositions.Length;
        StartCoroutine(CloudRoutine());
    }

    IEnumerator CloudRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0,1.0f));
            MakeCloud(Random.Range(0,count));
        }
    }

    void MakeCloud(int index)
    {
        GameObject cloud = Instantiate(cloudPrefab, cloudPositions[index].position, cloudPositions[index].rotation);
        cloud.GetComponent<CloudAttack>().RainInit((int)RainMode.Spread, 3, 2f);
    }
}

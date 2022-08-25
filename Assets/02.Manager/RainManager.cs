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
    public static RainManager instance;
    public Transform[] cloudTop;
    public Transform[] cloudRight;
    public Transform[] cloudBottom;
    public Transform[] cloudLeft;
    public List<Transform[]> cloudPositions;
    public int banThis;
    public GameObject cloudPrefab;

    float minRandom = 0.5f;
    float maxRandom = 1.5f;


    private void Start() {
        instance = this;
        cloudPositions = new List<Transform[]>();
        cloudPositions.Add(cloudTop);
        cloudPositions.Add(cloudRight);
        cloudPositions.Add(cloudBottom);
        cloudPositions.Add(cloudLeft);
        StartCoroutine(CloudRoutine());
    }

    IEnumerator CloudRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minRandom, maxRandom));
            MakeCloud();
        }
    }

    void MakeCloud()
    {
        int randonIndex;
        do
        {
            randonIndex = Random.Range(0,cloudPositions.Count);
        }
        while(randonIndex == banThis);
        Transform[] transforms = cloudPositions[Random.Range(0,cloudPositions.Count)];
        int index = Random.Range(0,transforms.Length);
        GameObject cloud = Instantiate(cloudPrefab, transforms[index].position, transforms[index].rotation);
        cloud.GetComponent<CloudAttack>().RainInit((int)RainMode.Spread, 3, 2f);
    }

    public void SetPhase(int phase)
    {
        switch(phase)
        {
            case 1:
            minRandom = 0.5f;
            maxRandom = 1.5f;
            break;
            case 2:
            minRandom = 0.3f;
            maxRandom = 1.2f;
            break;
            case 3:
            minRandom = 0.1f;
            maxRandom = 0.8f;
            break;
        }
    }
}
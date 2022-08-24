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

    public Transform[] cloudTop;
    public Transform[] cloudRight;
    public Transform[] cloudBottom;
    public Transform[] cloudLeft;
    public List<Transform[]> cloudPositions;
    public GameObject cloudPrefab;

    private void Start() {
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
            yield return new WaitForSeconds(Random.Range(0,1.0f));
            MakeCloud();
        }
    }

    void MakeCloud()
    {
        Transform[] transforms = cloudPositions[Random.Range(0,cloudPositions.Count)];
        int index = Random.Range(0,transforms.Length);
        GameObject cloud = Instantiate(cloudPrefab, transforms[index].position, transforms[index].rotation);
        cloud.GetComponent<CloudAttack>().RainInit((int)RainMode.Spread, 3, 2f);
    }


}

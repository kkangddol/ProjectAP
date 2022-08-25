using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAirCleaner : MonoBehaviour, ICaution
{
    public Transform[] pos; // 위 : 0, 오른 : 1, 아래 : 2, 왼 : 3
    public GameObject cleanerPrefab;
    
    public void Activate(int direction)
    {
        RainManager.instance.banThis = direction;
        Instantiate(cleanerPrefab, pos[direction].position, pos[direction].rotation);
    }
}

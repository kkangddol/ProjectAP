using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionManager : MonoBehaviour
{

    public BillBoardController billBoardController;
    ICaution[] cautions;

    bool isActivated = false;

    private void Start() {
        cautions = GetComponents<ICaution>();
        //StartCoroutine(ActivateRandomEvent());
    }

    private void Update() {
        if(isActivated) return;

        if(GameManager.instance.PlayingTime >= 50)
        {
            isActivated = true;
            int index = Random.Range(0, cautions.Length);
            int direction = Random.Range(0, 4);

            billBoardController.SetBillBoard(index, direction);

            StartCoroutine(DelayedActivate(index, direction));

            float randomTime = Random.Range(12.5f, 14.5f);
            StartCoroutine(Reset(randomTime));
        }
    }

    IEnumerator DelayedActivate(int index, int direction)
    {
        yield return new WaitForSeconds(5.0f);
        cautions[index].Activate(direction);
    }

    IEnumerator Reset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isActivated = false;
    }        
}
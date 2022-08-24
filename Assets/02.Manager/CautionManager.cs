using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionManager : MonoBehaviour
{
    ICaution[] cautions;
    Sprite[] cautionSprites;


    GameObject cautionImage;

    private void Start() {
        cautions = GetComponents<ICaution>();
    }

    void AppearCaution(int index)
    {
        cautionImage.GetComponent<SpriteRenderer>().sprite = cautionSprites[index];
        cautionImage.GetComponent<Animator>().SetTrigger("Caution");
    }
}
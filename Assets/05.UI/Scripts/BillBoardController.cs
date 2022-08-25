using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardController : MonoBehaviour
{
    [SerializeField] private Sprite[] cautionNames;
    [SerializeField] private Sprite[] cautionDirections; // 0:위쪽에서, 1:우측에서, 2:아래에서, 3:좌측에서, 4:전방향에서
    [SerializeField] private Sprite[] cautionImages;

    public RepeatText repeatText;

    public SpriteRenderer cautionName;
    public SpriteRenderer cautionDirection;
    public GameObject cautionImageObj;

    public void SetBillBoard(int nameIndex, int direction)
    {
        cautionImageObj.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);

        cautionName.sprite = cautionNames[nameIndex];
        cautionDirection.sprite = cautionDirections[direction];
        repeatText.Activate();

        cautionImageObj.GetComponent<SpriteRenderer>().sprite = cautionImages[nameIndex];
        cautionImageObj.GetComponent<Animator>().SetTrigger("Caution");

        Invoke("SetImageOff", 7f);
    }

    void SetImageOff()
    {
        cautionImageObj.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
    }
}

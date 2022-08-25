using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardController : MonoBehaviour
{
    [SerializeField] private Sprite[] cautionTextSprites; // 0:위쪽에서, 1:우측에서, 2:아래에서, 3:좌측에서, 4:전방향에서
    public RepeatText repeatText;
    public SpriteRenderer cautionTextSprite;
    public GameObject cautionImageObj;
    bool isRunning = false;

    public void SetBillBoard(int direction)
    {
        if(isRunning) return;

        isRunning = true;

        cautionTextSprite.sprite = cautionTextSprites[direction];
        repeatText.Activate();
        cautionImageObj.SetActive(true);

        Invoke("SetImageOff", 8f);
    }

    void SetImageOff()
    {
        cautionImageObj.SetActive(false);
        isRunning = false;
    }
}

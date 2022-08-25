using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("Game Start");
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR //�Ϲ��� ���ø����̼ǹ������ ������ �����Ƿ� �����͸�忡�� ������ �� �ֵ��� ��
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }

    public void OnClickEasterEgg()
    {
        SceneManager.LoadScene("InfiniteScene");
    }


}

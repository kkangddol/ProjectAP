using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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


}

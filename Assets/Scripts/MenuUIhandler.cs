using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIhandler : MonoBehaviour
{
    public TMP_InputField input;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Best Score: " + UserData.Instance.PlayerName + ": " + UserData.Instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        UserData.Instance.CurrentPlayerName = input.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

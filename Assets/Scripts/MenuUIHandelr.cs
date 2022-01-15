using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]

public class MenuUIHandelr : MonoBehaviour
{
    public Text BestScoreText;
    public InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score : {GameData.Instance.BestPlayer} : {GameData.Instance.BestScore}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        GameData.Instance.PlayerName = NameInput.text;
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

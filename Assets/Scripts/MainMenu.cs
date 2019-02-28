using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("StanleScene");
    }
}
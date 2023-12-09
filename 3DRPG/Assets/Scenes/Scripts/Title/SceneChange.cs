using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void New()
    {
        SceneManager.LoadScene("Main");
    }

    public void Load()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Title");
    }
}

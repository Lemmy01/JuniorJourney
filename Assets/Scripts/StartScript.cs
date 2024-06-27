using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void StartOption()
    {
        SceneManager.LoadScene("_StoryLevel",LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

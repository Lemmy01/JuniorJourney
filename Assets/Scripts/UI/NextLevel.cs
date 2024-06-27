using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    [SerializeField] private GameObject nextLevelScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (nextLevelScreen.activeInHierarchy)
        {
            Pause(false);
        }
        else
        {
            if(collision.tag == "Player")
            Pause(true);
        }
    }

    public void Pause(bool status)
    {

        nextLevelScreen.SetActive(status);
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

   
  

   
}

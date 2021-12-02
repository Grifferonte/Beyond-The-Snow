using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {

    }
        public void PauseGame()
    {
        SceneManager.LoadScene("Menu");
    }

}

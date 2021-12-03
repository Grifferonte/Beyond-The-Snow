using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void RetourGame()
    {
        Debug.Log("resume");
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("quitte");
        Application.Quit();
    }
}

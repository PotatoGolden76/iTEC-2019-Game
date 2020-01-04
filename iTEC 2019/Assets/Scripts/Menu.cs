using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
    public GameObject menu;
    public GameObject keys;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        keys.SetActive(false);
    }

    // Update is called once per frame
    public void play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ks()
    {
        menu.SetActive(false);
        keys.SetActive(true);
    }

    public void back()
    {
        menu.SetActive(true);
        keys.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }
}

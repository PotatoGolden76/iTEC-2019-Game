using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int totalBamboo, crBamboo;
    public string nextLevel;

    public Animator fadeAnim;
    // Start is called before the first frame update
    void Start()
    {
        //totalBamboo = 1;
        crBamboo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(crBamboo == totalBamboo)
        {
            Debug.Log("level Finished");
            StartCoroutine(loadScene());
        }
    }

    public void collect()
    {
        crBamboo++;
    }

    IEnumerator loadScene()
    {
        fadeAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextLevel);
    }
}

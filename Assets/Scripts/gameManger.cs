using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManger : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverObject, passedObject;
    



    public int nextSceneLoad;



    void Start()
    {
        gameOverObject.SetActive(false);
        passedObject.SetActive(false);




        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;



    }

    // Update is called once per frame
    void Update()
    {


        if (player.GetComponent<healing>().health <= 0)
        {
            gameOverObject.SetActive(true);
            
        }


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void List()
    {
        SceneManager.LoadScene("list");
    }


    public void Next()
    {
        

        if (SceneManager.GetActiveScene().buildIndex == 11) /* < Change this int value to whatever your
                                                                   last level build index is on your
                                                                   build settings */
        {
            Debug.Log("You Completed ALL Levels");

            //Show Win Screen or Somethin.
        }
        else
        {
            //Move to next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }


    }

}

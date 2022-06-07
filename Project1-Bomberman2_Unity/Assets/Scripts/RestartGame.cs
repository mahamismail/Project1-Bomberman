using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{
    /*** RELOAD SCENE **/

    public KeyCode restartGame = KeyCode.R; // On pressing R, reload the scene

    void Update()
    {
        if (Input.GetKey(restartGame))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}

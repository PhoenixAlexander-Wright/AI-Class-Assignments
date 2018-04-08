using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Equals)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if (Input.GetKeyDown(KeyCode.Minus)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

    public string scene;

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}

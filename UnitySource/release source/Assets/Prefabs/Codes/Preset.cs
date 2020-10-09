using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preset : MonoBehaviour
{

    public LevelLoader levelLoaderPrefab;

    void Start()
    {
        if (LevelLoader.instance == null) {
            LevelLoader.instance = Instantiate(levelLoaderPrefab);
        }

        SceneManager.LoadScene(1);
    }

}

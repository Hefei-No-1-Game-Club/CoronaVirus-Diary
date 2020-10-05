using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Option{

    public string title;
    public string description;
    public string sceneName;

    public Option(string title, string description, string sceneName) {
        Debug.Log("Option Created: " + title + " " + description + " " + sceneName);
        this.title = title;
        this.description = description;
        this.sceneName = sceneName;
    }

    void load() {
        Debug.Log("Load Scene " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

}

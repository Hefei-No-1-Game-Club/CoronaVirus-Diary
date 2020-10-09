using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuElementController : MonoBehaviour
{

    public Animator transitionAnimator;
    public GameObject settings;
    public LevelLoader levelLoaderPrefab;

    void Awake()
    {
        if (LevelLoader.instance == null) {
            LevelLoader.instance = Instantiate(levelLoaderPrefab);
        }
    }
    
    public void startGame() {

        // StartCoroutine(transitionFadeOut(1));
        LevelLoader.instance.Transition(2, "circle", 2f, "");

    }

    IEnumerator transitionFadeOut(int sceneIndex)
    {
        
        transitionAnimator.SetTrigger("Fade Out");

        yield return new WaitForSeconds(1.5f);

        load(sceneIndex);
        
    }

    void load(int sceneIndex) {

        SceneManager.LoadScene(sceneIndex);

    }

    public void openOptions() {
        settings.SetActive(true);
    }

    public void Resume() {
        settings.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (settings.activeSelf) {
                Resume();
            }
        }
    }

    public void quit() {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public static LevelLoader instance;
    public GameObject animationObject;
    
    private string introduction = "";

    private static Dictionary<string, Effect> EFFECTS = new Dictionary<string, Effect>();

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        instance = instance == null ? this : instance;

        EFFECTS.Add("circle", new Effect(animationObject, 1f, 1f));
        EFFECTS.Add("circlewithclick", new Effect(animationObject, true, 1f));
    }

    // Enable certain elements for entering scenes
    private void _EnterScene(string effect) {

        Animator temp = animationObject.GetComponent<Animator>();
        temp.SetTrigger("Fade Out");
        Debug.Log("Fade Out");

    }

    // Enable certain elements when off a scene
    private void _OffScene(string effect) {

        Animator temp = animationObject.GetComponent<Animator>();
        temp.SetTrigger("Fade In");
        Debug.Log("Fade In");

    }

    // Overall transition
    public void Transition(int SceneIndex, string effect, float seconds, string introduction) {

        // replace text on the screen
        if (introduction != "") {}

        StartCoroutine(_scene_transition(SceneIndex, effect, seconds));

    }

    public void Transition(string SceneName, string effect, float seconds, string introduction) {

        // replace text on the screen
        if (introduction != "") {}

        StartCoroutine(_scene_transition(SceneName, effect, seconds));

    }

    public void Transition(int SceneIndex, string effect, string introduction) {

        // replace text on the screen
        if (introduction != "") {}

        StartCoroutine(_scene_transition(SceneIndex, effect));

    }

    public void Transition(string SceneName, string effect, string introduction) {

        // replace text on the screen
        if (introduction != "") {}

        StartCoroutine(_scene_transition(SceneName, effect));

    }

    private IEnumerator _scene_transition(int SceneIndex, string effect, float seconds) {

        _EnterScene(effect);

        yield return new WaitForSeconds(seconds / 2);

        SceneManager.LoadScene(SceneIndex);

        if (EFFECTS[effect].clickable) {
            while (!Input.GetMouseButtonDown(0)) {
                yield return null;
            }
        }

        else {
            yield return new WaitForSeconds(seconds / 2);
        }

        FindObjectOfType<PlotManager>().Play();

        _OffScene(effect);

    }

    private IEnumerator _scene_transition(string SceneName, string effect, float seconds) {

        _EnterScene(effect);

        yield return new WaitForSeconds(seconds / 2);

        SceneManager.LoadScene(SceneName);

        if (EFFECTS[effect].clickable) {
            while (!Input.GetMouseButton(0)) {
                yield return null;
                Debug.Log("Waiting for click...");
            }
        }

        else {
            yield return new WaitForSeconds(seconds / 2);
        }

        FindObjectOfType<PlotManager>().Play();

        _OffScene(effect);

    }

    private IEnumerator _scene_transition(string sceneName, string effect) {

        bool clickable = EFFECTS[effect].clickable;
        float waitTime = EFFECTS[effect].waitTime;
        float loadTime = EFFECTS[effect].loadTime;

        _EnterScene(effect);

        yield return new WaitForSeconds(loadTime);

        Debug.Log("Start loading");

        SceneManager.LoadScene(sceneName);

        if (clickable) {
            while (!Input.GetMouseButton(0)) {
                yield return null;
            }
        }

        else {
            yield return new WaitForSeconds(waitTime);
        }

        if (sceneName != "Main Menu") {
            FindObjectOfType<PlotManager>().Play();
        }

        _OffScene(effect);

    }

    private IEnumerator _scene_transition(int sceneIndex, string effect) {

        bool clickable = EFFECTS[effect].clickable;
        float waitTime = EFFECTS[effect].waitTime;
        float loadTime = EFFECTS[effect].loadTime;

        _EnterScene(effect);

        yield return new WaitForSeconds(loadTime);

        Debug.Log("Start loading");

        SceneManager.LoadScene(sceneIndex);

        if (clickable) {
            while (!Input.GetMouseButton(0)) {
                yield return null;
            }
        }

        else {
            yield return new WaitForSeconds(waitTime);
        }

        if (sceneIndex != 1) {
            FindObjectOfType<PlotManager>().Play();
        }

        _OffScene(effect);

    }

    public void setIntroduction(string introduction) {
        this.introduction = introduction;
    }

}

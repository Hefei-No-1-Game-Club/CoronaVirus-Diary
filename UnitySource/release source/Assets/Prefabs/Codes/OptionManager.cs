using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class OptionManager : MonoBehaviour
{

    public Option[] options;
    public Button optionButtonPrefab;
    public Animator transitionAnimator;

    // Buttons spawn points
    private float spawn_point_x = -300;
    private float spawn_point_y = -300;

    // Display options on the screen with buttons initialized
    public void spawn() {
        Debug.Log(options.Length);

        for (int i = 0; i < options.Length; i++) {
            
            // change spawn points
            spawn_point_x += 600;
            if (i != 0 && i % 2 == 0) { 
                spawn_point_y += 150;
                spawn_point_x = 300;
            }

            Debug.Log("Spawning option " + (i + 1));
            Button optionButton = Instantiate(optionButtonPrefab, new Vector3(spawn_point_x + 360, spawn_point_y + 540, 0f), Quaternion.identity, GameObject.Find("Canvas").transform);

            // set buttons alike
            optionButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = options[i].title;
            //optionButton.GetComponent<Button>().GetComponent<Text>().text = options[i].title
            string sceneName = options[i].sceneName;
            string description = options[i].description;
            string effect = options[i].effect;
            
            optionButton.onClick.AddListener(() => LevelLoader.instance.Transition(sceneName, effect.ToLower(), ""));

        }
    }

    IEnumerator transitionFadeOut(string sceneName, string text, string effect)
    {
        
        // transitionAnimator.gameObject.GetComponentInChildren<Text>().text = text;
        // GlobalStaticVariables.setIntroduction(text);

        transitionAnimator.SetTrigger("Fade Out");

        yield return new WaitForSeconds(1.5f);

        load(sceneName);
        
    }

    void load(string sceneName) {
        Debug.Log("Load Scene " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

}

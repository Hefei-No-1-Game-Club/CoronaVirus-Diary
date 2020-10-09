using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{

    public void save() {
        PlayerPrefs.SetInt("current progress", SceneManager.GetActiveScene().buildIndex);
    }

    public void load() {
        int progress = PlayerPrefs.GetInt("current progress", 1);
        SceneManager.LoadScene(progress);
    }

}

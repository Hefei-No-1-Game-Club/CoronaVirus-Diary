using UnityEngine;
using UnityEngine.Video;

public class VisualManager : MonoBehaviour
{
    
    public GameObject settingMenu;
    public VideoPlayer videoPlayer;
    public static bool GamePaused = false;

    private float pauseSpeed = 0.1f;
    private float normalSpeed = 1f;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("ESC pressed");
            
            if (GamePaused) Resume();
            else Pause();
        }
    }

    void Resume() {
        settingMenu.SetActive(false);
        videoPlayer.playbackSpeed = normalSpeed;
        GamePaused = false;
    }

    void Pause() {
        settingMenu.SetActive(true);
        videoPlayer.playbackSpeed = pauseSpeed;
        GamePaused = true;
    }

}

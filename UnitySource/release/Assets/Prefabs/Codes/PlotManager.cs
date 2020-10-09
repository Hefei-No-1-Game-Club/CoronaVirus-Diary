using UnityEngine;
using UnityEngine.Video;

public class PlotManager : MonoBehaviour
{

    // video player
    public VideoClip plotVideo;
    public GameObject settingMenu;

    public static bool GamePaused = false;

    public float pauseSpeed = 0f;
    public float normalSpeed = 1f;
    private VideoPlayer plotPlayer;

    void Start()
    {
        // spawn video player
            // at position (0, 0, 0), with no rotation
        GameObject camera = GameObject.Find("Main Camera");

        plotPlayer = camera.AddComponent<VideoPlayer>();

        {
            // position setting
            plotPlayer.transform.position = new Vector3(0f, 0f, 0f);
            plotPlayer.transform.rotation = Quaternion.identity;

            // video clip
            plotPlayer.clip = plotVideo;
            plotPlayer.isLooping = false;
            plotPlayer.loopPointReached += EndReached;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (plotPlayer != null && plotPlayer.isPlaying) {
            Debug.Log("Video playing");
        }

        // menu control
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("ESC pressed");
            
            if (GamePaused) Resume();
                else Pause();
        }
    }

    // Function called when the video ends
    void EndReached(VideoPlayer vp) {
        Debug.Log("Video ends.");
        GameObject OptionManager = GameObject.Find("OptionManager");
        OptionManager.GetComponent<OptionManager>().spawn();
    }

    public void Resume() {
        settingMenu.SetActive(false);
        plotPlayer.playbackSpeed = normalSpeed;
        GamePaused = false;
    }

    void Pause() {
        settingMenu.SetActive(true);
        plotPlayer.playbackSpeed = pauseSpeed;
        GamePaused = true;
    }
}

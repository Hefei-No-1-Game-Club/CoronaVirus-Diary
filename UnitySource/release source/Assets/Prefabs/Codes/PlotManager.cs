using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{

    // video player
    public VideoClip plotVideo;
    public GameObject settingMenu;

    public static bool GamePaused = false;

    public float pauseSpeed = 0f;
    public float normalSpeed = 1f;
    private VideoPlayer plotPlayer;
    public Animator transition;

    public LevelLoader levelLoaderPrefab;

    void Start()
    {
        if (LevelLoader.instance == null) {
            LevelLoader.instance = Instantiate(levelLoaderPrefab);
        }

        // spawn video player
            // at position (0, 0, 0), with no rotation
        GameObject camera = GameObject.Find("Main Camera");

        plotPlayer = camera.AddComponent<VideoPlayer>();

        {
            plotPlayer.playOnAwake = false;

            // position setting
            plotPlayer.transform.position = new Vector3(0f, 0f, 0f);
            plotPlayer.transform.rotation = Quaternion.identity;

            // video clip
            plotPlayer.clip = plotVideo;
            plotPlayer.isLooping = false;
            plotPlayer.loopPointReached += EndReached;

            plotPlayer.Prepare();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //start fade in
        // if (Input.GetMouseButtonDown(0) && transition.enabled == false) {
        //     transition.enabled = true;
        //     plotPlayer.Play();
        // }

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
        // Time.timeScale = 1f;
        plotPlayer.playbackSpeed = 1f;
        GamePaused = false;
    }

    void Pause() {
        settingMenu.SetActive(true);
        // Time.timeScale = 0f;
        plotPlayer.playbackSpeed = 0f;
        GamePaused = true;
    }

    public void Play() {
        plotPlayer.Play();
    }
}

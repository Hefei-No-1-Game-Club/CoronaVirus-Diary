using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlotManager : MonoBehaviour
{

    // video player
    public VideoClip plotVideo;

    void Start()
    {
        // spawn video player
            // at position (0, 0, 0), with no rotation
        GameObject camera = GameObject.Find("Main Camera");

        VideoPlayer plotPlayer = camera.AddComponent<VideoPlayer>();

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
        var plotPlayer = GetComponent<VideoPlayer>();

        if (plotPlayer != null && plotPlayer.isPlaying) {
            Debug.Log("Video playing");
        }
    }

    // Function called when the video ends
    void EndReached(VideoPlayer vp) {
        Debug.Log("Video ends.");
        GameObject OptionManager = GameObject.Find("OptionManager");
        OptionManager.GetComponent<OptionManager>().spawn();
    }
}

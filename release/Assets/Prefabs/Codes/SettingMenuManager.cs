using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingMenuManager : MonoBehaviour
{

    public AudioMixer mainAudioMixer;
    public Animator transitionAnimator;
    Dropdown ResolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        ResolutionDropdown = GetComponentInChildren<Dropdown>();
        ResolutionDropdown.ClearOptions();

        List<string> resolutionData = new List<string>();
        int currentResolutionIndex = 0;

        var i = -1;
        foreach (Resolution resolution in Screen.resolutions) {
            i += 1;
            resolutionData.Add(resolution.width + " x " + resolution.height);
            
            if (resolution.Equals(Screen.currentResolution)) {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(resolutionData);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    // Modify resolutions
    public void setResolution(int resolutionIndex) {
        Resolution target = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(target.width, target.height, Screen.fullScreen);
    }

    public void setFullScreen(bool isFullScreen) {
        Debug.Log("fullscreen set to " + isFullScreen);
        Screen.fullScreen = isFullScreen;
    } 

    public void setVolume(float volume) {
        mainAudioMixer.SetFloat("volume", volume);
    }

    public void quitToMenu() {
        StartCoroutine(_quitToMenu());
    }

    IEnumerator _quitToMenu()
    {
        transitionAnimator.SetTrigger("Fade Out");
        
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);
    }

    public void quitToDesktop() {
        Application.Quit();
    }

}

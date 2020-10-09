using UnityEngine;

[System.Serializable]
public class Effect
{

    public GameObject animationObject;
    public bool clickable;
    public float waitTime; // how long the animation shows

    public float loadTime; // how long the animation takes

    // <None> effect specific
    public Effect() {
        this.animationObject = null;
        this.clickable = false;
        this.waitTime = 0f;
        this.loadTime = 0f;
    }

    public Effect(float loadTime) {
        this.animationObject = null;
        this.clickable = false;
        this.waitTime = 0f;
        this.loadTime = loadTime;
    }

    public Effect(GameObject animationObject, float loadTime) {
        this.animationObject = animationObject;
        this.clickable = true;
        this.loadTime = loadTime;
    }

    public Effect(GameObject animationObject, bool clickable, float loadTime) {
        this.animationObject = animationObject;
        this.clickable = clickable;
        this.loadTime = loadTime;
    }

    public Effect(GameObject animationObject, float waitTime, float loadTime) {
        this.animationObject = animationObject;
        this.waitTime = waitTime;
        this.clickable = false;
        this.loadTime = loadTime;
    }

}

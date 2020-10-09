using UnityEngine;

public class FadeIn : MonoBehaviour
{

    public GameObject animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.activeSelf) {
            animator.SetActive(true);
        }
    }

}

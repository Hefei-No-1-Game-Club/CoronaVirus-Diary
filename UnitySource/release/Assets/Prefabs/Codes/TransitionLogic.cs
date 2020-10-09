using UnityEngine;

public class TransitionLogic : MonoBehaviour
{

    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Fade Out");
        }
    }

}

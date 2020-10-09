using UnityEngine;
using UnityEngine.UI;

public class FadeInText : MonoBehaviour
{

    void Start()
    {
        if (GlobalStaticVariables.getIntroduction() != "") {
            this.GetComponentInChildren<Text>().text = GlobalStaticVariables.getIntroduction();
        }
    }

}

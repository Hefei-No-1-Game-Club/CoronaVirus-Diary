using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStaticVariables : MonoBehaviour
{

        // Description of the Scene <static>
    private static string introduction = "";

    public static string getIntroduction() {
        return introduction;
    }

    public static void setIntroduction(string newIntro) {
        introduction = newIntro;
    }

}

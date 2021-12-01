using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultDetermine : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        bool win = GeneralProperties.propertiesInstance.GetResults();

        if (win)
        {
            text.text = "YOU FED THE SHARK!";
        }
        else
        {
            text.text = "THE SHARK GOT SICK.";
        }

    }

}

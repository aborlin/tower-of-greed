using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stamUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float MAX_STAM = 100.0f;
    public static float stam = 100.0f;
    public Text stamText;
    void Start()
    {
        stamText = GetComponent<Text>();
        stamText.text = "Stam: " + (int)stam;
    }

    // Update is called once per frame
    void Update()
    {
        stamText.text = "Stam: " + (int)stam;
        if(ThirdPersonMovement.regenstam == true && stam < MAX_STAM)
        {
            stam = stam + 0.25f;
        }
    }
}

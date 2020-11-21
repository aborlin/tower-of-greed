using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hpUI : MonoBehaviour
{
    private int hp = 100;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponent<Text>();
        hpText.text = "HP: " + 100;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + 100;

        //if(condition){
        // hp--;
        //}
    }
}

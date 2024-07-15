using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FanScript : MonoBehaviour
{
    public bool Broken;

    public Sprite fanSprite;
    public Sprite brokenfanSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Broken)
        {
            GetComponent<Image>().sprite = brokenfanSprite;
        }
        if (!Broken)
        {
            GetComponent<Image>().sprite = fanSprite;
        }
    }

    void Repair()
    {
        Broken = false;
    }
}

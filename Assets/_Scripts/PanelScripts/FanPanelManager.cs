using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class FanPanelManager : MonoBehaviour
{
    public int Number;

    public GameObject moduleManager;

    public GameObject Fan;
    public Sprite fanSprite;
    public Sprite brokenfanSprite;

    Dictionary<string, float> functionsStatus;
    ModuleManager manager;

    private void Start()
    {
        manager = moduleManager.GetComponent<ModuleManager>();
    }

    private void Update()
    {
        functionsStatus = manager.FunctionsStatus();
        CheckFan();
    }

    void CheckFan()
    {
        if (functionsStatus["Radiator " + Number.ToString()] < 0)
        {
            Fan.GetComponent<Image>().sprite = brokenfanSprite;
        }
        if (functionsStatus["Radiator " + Number.ToString()] > 0)
        {
            Fan.GetComponent<Image>().sprite = fanSprite;
        }
    }
}

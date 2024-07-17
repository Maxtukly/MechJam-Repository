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
    public PlayerManager player;
    public Sprite fanSprite;
    public Sprite brokenfanSprite;

    Dictionary<string, float> functionsStatus = new Dictionary<string, float>();
    ModuleManager manager;

    private void Start()
    {
        manager = moduleManager.GetComponent<ModuleManager>();
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        functionsStatus = manager.FunctionsStatus();

        if (functionsStatus["Radiator 1"] <= 0)
        {
            Fan.GetComponent<FanScript>().Broken = true;
        }
        if (functionsStatus["Radiator 1"] > 0)
        {
            Fan.GetComponent<FanScript>().Broken = false;
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(Fan.GetComponent<FanScript>().Broken);
        }
        manager.FunctionsChange(functionsStatus);
    }

    public void RepairFan()
    {
        if(player.CurrentInstrument == "Screwdriver")
        {
            functionsStatus["Radiator 1"] = 1;
            Fan.GetComponent<FanScript>().Broken = false;
        }
    }
}

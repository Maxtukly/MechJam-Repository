using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ModulInteraction : MonoBehaviour
{
    public bool Enabled;
    public bool Steady;
    public Text Modultxt;
    private ParticleSystem par;
    public GameObject Panel;
    public GameObject moduleManager;
    public Component functionScript;
    public GameObject Particals;
    ModuleManager manager;
    public LayerMask player;
    public bool Working;

    void Start()
    {
        moduleManager = GameObject.Find("Module Manager");
        Enabled = false;
        Steady = false;
        par = Particals.GetComponent<ParticleSystem>();
        Working = true;
    }

    void Update()
    {
        if(Physics2D.OverlapCircle(this.transform.position, 2, player))
        {
            Enabled = true;
            Modultxt.text = "Press the \"R\" Button for repair";
            manager = moduleManager.GetComponent<ModuleManager>();
            manager.currentModule = gameObject;
        }
        else
        {
            Enabled = false;
        }

        if (Enabled && Input.GetKeyDown(KeyCode.R))
        {
            Panel.active = !Panel.active;
        }

        if (par != null && Working)
        {
            par.Stop();
        }
        else
        {
            par.Play();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Enabled = true;
            Modultxt.text = "Press the \"E\" Button";
        }
    }

    void EnergyCount()
    {
        Enabled = false;
        Modultxt.text = "";
    }

    public void Interaction()
    {
        functionScript.SendMessage("ModuleStart");
        Invoke("EnergyCount", 3.0f);
    }

    public void GoBoom()
    {
        functionScript.SendMessage("BreakSomething");
    }
}

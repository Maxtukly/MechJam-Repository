using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ModulInteraction : MonoBehaviour
{
    public bool Enabled;
    public Text Modultxt;
    private Renderer ren;
    private ParticleSystem par;
    public GameObject Panel;
    public GameObject moduleManager;
    public GameObject Particals;
    ModuleManager manager;
    public LayerMask player;
    public bool Working;

    void Start()
    {
        Enabled = false;
        ren = GetComponent<Renderer>();
        par = Particals.GetComponent<ParticleSystem>();
        Working = false;
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
        Debug.Log("Module active");
        if (par != null)
        {
            par.Stop();
            Debug.Log("Particals stoped");
        }
        Working = true;
        Invoke("EnergyCount", 3.0f);
    }
}

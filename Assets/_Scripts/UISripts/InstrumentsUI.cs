using Unity.VisualScripting;
using UnityEngine;

public class InstrumentsUI : MonoBehaviour
{
    bool visible;
    public Animator animator;
    public GameObject Player;
    PlayerManager pmanager;


    // Update is called once per frame

    private void Start()
    {
        visible = false;
        pmanager = Player.GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Movement();
        }
    }

    private void Movement()
    {
        visible = !visible;

        Debug.Log("bool changed");

        if (visible)
        {
            animator.SetBool("Visible", true);
        }
        else
        {
            animator.SetBool("Visible", false);
            pmanager.CurrentInstrument = null;
        }
    }

    public void SetInstrument(string instrument)
    {
       pmanager.CurrentInstrument = instrument;
       Debug.Log(pmanager.CurrentInstrument);
    }
}

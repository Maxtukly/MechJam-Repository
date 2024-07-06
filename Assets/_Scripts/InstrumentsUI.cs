using Unity.VisualScripting;
using UnityEngine;

public class InstrumentsUI : MonoBehaviour
{
    bool visible;
    public Animator animator;

    // Update is called once per frame

    private void Start()
    {
        visible = false;
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
        }
    }
}

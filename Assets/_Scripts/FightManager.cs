using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class FightManager : MonoBehaviour
{

    [SerializeField] float fightTime;
    [SerializeField] float casualtiesTime;
    [SerializeField] float mechHealth;
    float casualtiesTimer;
    [SerializeField] TextMeshProUGUI timerText;
    public List<GameObject> modules = new List<GameObject>();
    public Dictionary<string, int> mechModules = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        casualtiesTimer = casualtiesTime;
        mechModules.Add("Motors", 0);
        mechModules.Add("Pumps", 0);
        mechModules.Add("Electronics", 0);

        modules = GameObject.FindGameObjectsWithTag("Module").ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fightTime > 0)
        {

            fightTime -= Time.deltaTime;

            if(casualtiesTimer > 0)
            {
                casualtiesTimer -= Time.deltaTime + Random.Range(-0.5f, 2);
            }
            if(casualtiesTimer < 0)
            {
                casualtiesTimer = casualtiesTime;
                BreakDown();
            }
        }
        if(fightTime < 0)
        {
            fightTime = 0;
        }

        int minutes = Mathf.FloorToInt(fightTime / 60);
        int seconds = Mathf.FloorToInt(fightTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void BreakDown()
    {
        int damage = Random.Range(1, 4);
        for (int i = 0; i < damage; i++)
        {
            int module = Random.Range(0, modules.Count - 1);
            modules[module].GetComponent<ModulInteraction>().GoBoom();
        }
    }
}

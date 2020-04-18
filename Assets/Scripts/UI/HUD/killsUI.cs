using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killsUI : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 

    [SerializeField] private Text text;
    [SerializeField] private static int Kills;

    //=================================== Objects ====================================
    public coinCounter counter;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
    void Start()
    {
        text = GetComponent<Text>();
        Kills = counter.getDeathCount();
    }

    void Update()
    {
        Kills = counter.getDeathCount();
        setKills(Kills);
    }

    //=================================== Setters =====================================
    public void setKills(int Kills)
    {
        text.text = Kills.ToString();
    }
}


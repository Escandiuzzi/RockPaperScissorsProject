using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    bool game;
    [SerializeField]
    bool first_phase;

    [SerializeField]
    Player player;

    [SerializeField]
    GameObject[] buttons;



    void Start()
    {
        first_phase = true;
        player = GameObject.Find("Player").GetComponent<Player>();
    }


    void Update()
    {
        if (first_phase)
            FirstPhase();
    }


    void FirstPhase()
    {
        if (player.GetPlayerCardCount() > 2)
        {
            first_phase = false;
            game = true;

            for(int i = 0; i < 3; i++)
            {
                buttons[i].SetActive(false);
            }

            player.ShowCards();
        }

    }

}

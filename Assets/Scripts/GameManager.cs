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

    [SerializeField]
    GameObject player_selected_card;
    [SerializeField]
    GameObject ia_selected_card;


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

    public GameObject GetSelectedCard(int index)
    {
        if (index == 0)
            return player_selected_card;
        else
            return ia_selected_card;
    }

    public void SetSelectedCard(int index, GameObject card)
    {
        if (index == 0)
            player_selected_card = card;
        else
            ia_selected_card = card;
    }

}

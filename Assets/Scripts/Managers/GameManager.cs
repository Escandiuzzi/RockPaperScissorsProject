using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    bool game;
    [SerializeField]
    bool first_phase;

    [SerializeField]
    IABehaviour ia;

    [SerializeField]
    Player player;

    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    GameObject player_selected_card;
    [SerializeField]
    GameObject ia_selected_card;

    [SerializeField]
    Text player_score_text;
    [SerializeField]
    Text ia_score_text;
    [SerializeField]
    Text final_score_text;

    [SerializeField]
    GameObject finalresultPanel;

    [SerializeField]
    float animationTime;


    int playerScore;
    int iaScore;

    float time;

    bool calculate;
    bool destroy;

    void Start()
    {
        first_phase = true;
        player = GameObject.Find("Player").GetComponent<Player>();
        ia = GameObject.Find("IA").GetComponent<IABehaviour>();
    }

    void Update()
    {
        if (first_phase) 
            FirstPhase();


        if (player_selected_card != null && ia_selected_card != null)
        {
            if (!calculate)
            {
                CalculateDuel();
                time = 0;
                destroy = true;
            }

             UpdateScoreBoard();
        }

    

    }

    private void FixedUpdate()
    {
        if (destroy)
        {
            time += Time.deltaTime;
            if (time > animationTime)
            {
                Destroy(player_selected_card);
                Destroy(ia_selected_card);
                player_selected_card = null;
                ia_selected_card = null;
                calculate = false;
                destroy = false;
            }
        }
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
            ia.Think();
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
        {
            player_selected_card = card;
            player.SelectedCard(card.GetComponent<Card>());
            ia.ChooseCard();
        }
        else
            ia_selected_card = card;
    }
    void CalculateDuel()
    {
        calculate = true;
        var player_card_type = player_selected_card.GetComponent<Card>().GetID();

        switch (player_card_type)
        {
            case 0:
                if (ia_selected_card.GetComponent<Card>().GetID() == 0)
                { }
                else if (ia_selected_card.GetComponent<Card>().GetID() == 1)
                    iaScore++;
                else
                    playerScore++;
                break;

            case 1:
                if (ia_selected_card.GetComponent<Card>().GetID() == 0)
                    playerScore++;
                else if (ia_selected_card.GetComponent<Card>().GetID() == 1)
                { }
                else
                    iaScore++;
                break;

            case 2:
                if (ia_selected_card.GetComponent<Card>().GetID() == 0)
                    iaScore++;
                else if (ia_selected_card.GetComponent<Card>().GetID() == 1)
                    playerScore++;
                else
                { }
                break;
        }
    }


    void UpdateScoreBoard()
    {
        player_score_text.text = "Player: " + playerScore;
        ia_score_text.text = "IA: " + iaScore;

        if (playerScore >= 2)
        {
            finalresultPanel.SetActive(true);
            final_score_text.text = "YOU WIN";
        }

        else if (iaScore >= 2)
        {
            finalresultPanel.SetActive(true);
            final_score_text.text = "YOU LOSE";
        }

        else if (player.GetPlayerCardCount() == 0 && ia.GetIACardCount() == 0)
        {
            if (playerScore > iaScore)
            {
                finalresultPanel.SetActive(true);
                final_score_text.text = "YOU WIN";
            }

            else if (playerScore < iaScore)
            {
                finalresultPanel.SetActive(true);
                final_score_text.text = "YOU LOSE";
            }
            else
            {
                finalresultPanel.SetActive(true);
                final_score_text.text = "DRAW";
            }
        }
    }

}

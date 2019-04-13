using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    List<Card> deck;

    [SerializeField]
    int card_count;

    [SerializeField]
    Vector3[] pos;


    void Start()
    {
        deck = new List<Card>();
    }

    public void SetCard(Card card)
    {
        deck.Add(card);
        card_count++;
    }

    public void ShowCards()
    {
        int index = 0;

        foreach (Card card in deck)
        {
            card.EnableCard(pos[index]);
            index++;
        }
    }

    public int GetPlayerCardCount()
    {
        return card_count;
    }

    public void SelectedCard(Card card)
    {
        deck.Remove(card);
    }


}

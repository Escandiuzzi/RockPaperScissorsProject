using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    Sprite card_sprite;

    [SerializeField]
    int defeat;
    [SerializeField]
    int losses;


    public void InitializeCard(Sprite sprite, int id)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        GetComponent<SpriteRenderer>().enabled = false;

        if (id == 0)
        {
            defeat = 2;
            losses = 1;
        }
        else if (id == 1)
        {
            defeat = 0;
            losses = 2;
        }
        else
        {
            defeat = 1;
            losses = 0;
        }

    }

    public void EnableCard(Vector2 pos)
    {
        transform.position = pos;
        GetComponent<SpriteRenderer>().enabled = true;
    }


}

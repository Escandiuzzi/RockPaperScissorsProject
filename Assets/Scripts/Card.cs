using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    Sprite card_sprite;
    [SerializeField]
    int defeat;
    [SerializeField]
    int losses;


    string name;
    bool started;
    bool move;
    Vector3 startPosition;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }

    public void FixedUpdate()
    {
        if (move)
        {
            if (Vector3.Distance(gameObject.transform.position, new Vector3(0, 0)) > .01f)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0), .05f);
            }
            else
            {
                transform.position = new Vector3(0, 0);
                move = false;
            }
        }
    }

    void OnMouseDown()
    {
        if(started)
            SelectCard();
    }


    public void InitializeCard(Sprite sprite, int id)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        GetComponent<SpriteRenderer>().enabled = false;

        if (id == 0)
        {
            defeat = 2;
            losses = 1;
            name = "Rock";
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
        startPosition = pos;
        GetComponent<SpriteRenderer>().enabled = true;
        started = true;
    }

    public void SelectCard()
    {
        if (gameManager.GetSelectedCard(0) == null)
        {
            gameManager.SetSelectedCard(0, gameObject);

            move = true;
        }

    }



}

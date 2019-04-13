using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    int defeat;
    [SerializeField]
    int losses;
    [SerializeField]
    int id;


    string name;
    bool started;
    bool move;
    Vector3 startPosition;

    Vector3 selected_position;


    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }

    public void FixedUpdate()
    {
        if (move)
        {
            if (Vector3.Distance(gameObject.transform.position, selected_position) > .01f)
            {
                transform.position = Vector3.Lerp(transform.position, selected_position, .05f);
            }
            else
            {
                transform.position = selected_position;
                move = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (started)
            SelectCard(0);
    }


    public void InitializeCard(int _id, Vector3 pos)
    {
        selected_position = pos;

        id = _id;

        GetComponent<SpriteRenderer>().sprite = sprites[_id];
        GetComponent<SpriteRenderer>().enabled = false;


        if (_id == 0)
        {
            defeat = 2;
            losses = 1;
            name = "Rock";
        }
        else if (_id == 1)
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

    public void SelectCard(int index)
    {
        if (gameManager.GetSelectedCard(index) == null)
        {
            gameManager.SetSelectedCard(index, gameObject);

            move = true;
        }

    }

    public int GetID()
    {
        return id;
    }

}

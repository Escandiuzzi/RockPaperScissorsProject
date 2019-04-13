using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABehaviour : MonoBehaviour
{
    IEnumerator IAThinkingTime()
    {
        float randTime = Random.Range(.5f, 2f);
        float counter = 0f;
        while (counter < randTime)
        {
            counter += Time.deltaTime;
            yield return null;
        }

    }

    [SerializeField]
    List<Card> deck;

    [SerializeField]
    int card_count;

    [SerializeField]
    Vector3[] pos;

    [SerializeField]
    Vector3 selected_pos;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameManager gameManager;
    void Start()
    {
        deck = new List<Card>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Think()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand_card = Random.Range(0, 3);

            GameObject new_card = Instantiate(prefab, new Vector2(0, 0), Quaternion.identity);
            SetCard(new_card.GetComponent<Card>());
            new_card.transform.parent = gameObject.transform;
            new_card.GetComponent<Card>().InitializeCard(rand_card, selected_pos);
            new_card.GetComponent<SpriteRenderer>().enabled = true;
            new_card.transform.position = pos[i];
        }

    }
    public void ChooseCard()
    {
        StartCoroutine(IAThinkingTime());

        int rand_card = Random.Range(0, card_count);

        Card selected_card = deck[rand_card];

        selected_card.SelectCard(1);

        deck.Remove(selected_card);
        card_count--;

    }
    public void SetCard(Card card)
    {
        deck.Add(card);
        card_count++;
    }

    public int GetIACardCount()
    {
        return card_count;
    }

}

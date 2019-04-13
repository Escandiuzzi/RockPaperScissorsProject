using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    Vector3 position;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void ButtonPressed(int id)
    {
        GameObject new_card = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
        player.GetComponent<Player>().SetCard(new_card.GetComponent<Card>());
        new_card.transform.parent = player.transform;
        new_card.GetComponent<Card>().InitializeCard(id, position);
    }

}

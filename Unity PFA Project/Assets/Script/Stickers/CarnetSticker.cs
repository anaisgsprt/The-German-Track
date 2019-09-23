﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarnetSticker : MonoBehaviour
{
    public int stickerIndex;
    Vector2 colliderSize;

    // Start is called before the first frame update
    void Start()
    {
        colliderSize = transform.parent.GetComponent<GridLayoutGroup>().cellSize;
        GetComponent<BoxCollider2D>().size = colliderSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GameObject player = transform.parent.parent.parent.GetComponent<CarnetControls>().player;
        if(player.GetComponent<Interactions>().PNJContact != null && player.GetComponent<Interactions>().PNJContact.tag != "Item")
        {
            player.GetComponent<Interactions>().PNJContact.GetComponent<PNJ>().Response(stickerIndex);
            transform.parent.parent.parent.parent.gameObject.SetActive(false);
        }
    }

    void OnMouseOver()
    {
        if(transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
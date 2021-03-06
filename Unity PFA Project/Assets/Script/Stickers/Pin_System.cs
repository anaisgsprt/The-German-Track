﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin_System : MonoBehaviour
{
    bool mouseOn = false;
    Vector3 screenPoint;
    public GameObject pin;
    public bool click;
    public int stickerIndex;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 colliderSize;
        colliderSize = GetComponent<RectTransform>().sizeDelta;
        GetComponent<BoxCollider2D>().size = colliderSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveFromList()
    {
        Destroy(transform.GetChild(2));
    }

    public void PointerEnter()
    {
        mouseOn = true;
    }
    public void PointerExit()
    {
        mouseOn = false;
    }

    public void PointerDown()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            int i = 0;
            foreach(RectTransform child in transform)
            {
                i++;
                if(child.name == "Pin 1(Clone)")
                {
                    break;
                }
                else 
                {
                    Debug.Log("1");
                    if(i == transform.childCount || transform.childCount == 0)
                    {
                        Debug.Log("2");
                        click = true;
                    }
                }
            }
            if(transform.childCount == 0)
            {
                click = true;
            }
        }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            foreach(RectTransform child in transform)
            {
                if(child.name == "Pin 1(Clone)")
                {
                    GameObject.FindObjectOfType<String_Manager>().DeletePin(gameObject);
                    Destroy(child.gameObject);
                }
            }
        }
    }

    public void PointerUp()
    {
        if(click)
        {
            click = !click;
            GameObject newPin = Instantiate(pin, transform);
            newPin.transform.localPosition = new Vector3(0, 25, 0);
            GameObject.FindObjectOfType<String_Manager>().AddPin(gameObject);
        }
    }

    public void Drag()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            click = false;
            screenPoint = Input.mousePosition;
            screenPoint.z = transform.parent.position.z;
            Camera camera = Camera.FindObjectOfType<Camera>();
            transform.position = camera.ScreenToWorldPoint(screenPoint);
            //transform.position = Camera.main.ScreenToWorldPoint(screenPoint);//
            //transform.position = Input.mousePosition;
        }
    }
}

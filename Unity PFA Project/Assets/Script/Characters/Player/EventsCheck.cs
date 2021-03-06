﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsCheck : MonoBehaviour
{
    public List<string> eventsList;
    public bool fauteuil;
    bool lamp;
    public GameObject EtiquetteLaissezPasser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GetComponent<Interactions>().PNJContact && GetComponent<Interactions>().PNJContact.name == "Fauteuil" && Input.GetButtonDown("Interaction"))
        {
            GetComponent<Interactions>().PNJContact = gameObject;
            GetComponent<PNJ>().ChangeDialog(4);
            GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
        }*/
        if(GetComponent<Interactions>().PNJContact && GetComponent<Interactions>().PNJContact.tag == "Interaction" && Input.GetButtonDown("Interaction") && !GetComponent<Interactions>().isInDialog)
        {
            CheckInteraction();
        }

        /*if(lamp && Input.GetButtonDown("Interaction"))// Initial
        {
            //JsonSave save = SaveGameManager.GetCurrentSave();
            if(GetComponent<PlayerMemory>().allStickers.Contains(15))
            {
                if(eventsList.Contains("LettreDécodée"))
                {
                    GetComponent<Interactions>().PNJContact = gameObject;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PNJ>().ChangeDialog(3);
                }
                else
                {
                    eventsList.Add("LettreDécodée");
                    GetComponent<Interactions>().PNJContact = gameObject;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PNJ>().ChangeDialog(2);
                    //GameObject.Find("Lamp").SetActive(false);
                    lamp = false;
                }
            }
            else 
            {
                GetComponent<Interactions>().PNJContact = gameObject;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PNJ>().ChangeDialog(3);
            }
        }*/
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Directional Light").GetComponent<DayNightLight>().DayTime();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "trigger_PoliceReceptionist")
        {
            GetComponent<Interactions>().PNJContact = GameObject.Find("police_receptionist");
            //collision.transform.GetChild(0).gameObject.SetActive(true);
            //GameObject.Find("trigger_PoliceReceptionist").SetActive(false);
            GetComponent<Interactions>().StartDialog();
        }
        
        /*if (col.name == "dialog_williamscott")
        {
            GetComponent<Interactions>().PNJContact = col.gameObject;
            col.transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<Interactions>().StartDialog();
            GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
        }*/
        if(col.name == "KD_InvisibleWall")
        {
            //JsonSave save = SaveGameManager.GetCurrentSave();
            if(GetComponent<PlayerMemory>().allStickers.Contains(1) && GetComponent<PlayerMemory>().allStickers.Contains(2) && GetComponent<PlayerMemory>().allStickers.Contains(8) && GetComponent<PlayerMemory>().allStickers.Contains(4))
            {
                //GameObject.Find("KD_InvisibleWall").SetActive(false);
                col.GetComponent<Clara_Cinematic>().ExecuteCommand();
            }
            else
            {
                GetComponent<Interactions>().PNJContact = gameObject;
                GetComponent<PNJ>().ChangeDialog(0);
                GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
            }
        }

        if(col.name == "E_InvisibleWall")
        {
            GetComponent<Interactions>().PNJContact = gameObject;
            GetComponent<PNJ>().ChangeDialog(1);
            GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
        }

        if(col.name == "doorHopital")
        {
            GetComponent<Interactions>().PNJContact = GameObject.Find("hospital_receptionist");
            GetComponent<Interactions>().StartDialog();
        }

        /*if(col.name == "Lamp")
        {
            col.transform.GetChild(0).gameObject.SetActive(true);
            //lamp = true;
        }*/
    }

    public void CheckInteraction()
    {
        switch(GetComponent<Interactions>().PNJContact.name)
        {
            case "doorKurt":
            GetComponent<Interactions>().PNJContact.GetComponent<Clara_Cinematic>().ExecuteCommand();
            break;

            case "Fauteuil" :
            GetComponent<Interactions>().PNJContact.GetComponent<Clara_Cinematic>().ExecuteCommand();
            break;

            case "Lamp" :
            LampEvent();
            break;
        }
    }

    void LampEvent()
    {
        if(GetComponent<Interactions>().PNJContact.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            GetComponent<Interactions>().PNJContact.transform.GetChild(1).gameObject.SetActive(false);
        }
        else 
        {
            GetComponent<Interactions>().PNJContact.transform.GetChild(1).gameObject.SetActive(true);
        }
        
        if(GetComponent<PlayerMemory>().allStickers.Contains(15))
        {
            if(/*eventsList.Contains("LettreDécodée")*/GetComponent<PlayerMemory>().allStickers.Contains(10) && GetComponent<PlayerMemory>().allStickers.Contains(45))
            {
                //GetComponent<Interactions>().PNJContact = gameObject;
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PNJ>().ChangeDialog(0);
                GetComponent<Interactions>().PNJContact.GetComponent<PNJ>().ChangeDialog(0);
                GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
            }
            else
            {
                GetComponent<Interactions>().PNJContact.GetComponent<PNJ>().ChangeDialog(1);
                GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
                //eventsList.Add("LettreDécodée");
                //GetComponent<Interactions>().PNJContact = gameObject;
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PNJ>().ChangeDialog(1);
                //GameObject.Find("Lamp").SetActive(false);
                //lamp = false;
            }
        }
        else 
        {
            GetComponent<Interactions>().PNJContact.GetComponent<PNJ>().ChangeDialog(0);
            GetComponent<Interactions>().ChangeState(Interactions.State.InDialog);
            //GetComponent<Interactions>().PNJContact = gameObject;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PNJ>().ChangeDialog(0);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Fauteuil")
        {
            col.transform.GetChild(0).gameObject.SetActive(false);
            fauteuil = false;
        }
        if(col.name == "Lamp")
        {
            col.transform.GetChild(0).gameObject.SetActive(false);
            //lamp = false;
        }
    }

    public void CheckEvents(string newEvent)
    {
        switch (newEvent)
        {
            case "laissezPasser":
                EtiquetteLaissezPasser.GetComponent<Animator>().SetTrigger("NewSticker");
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().NewGoal("- Aller voir Lou Ellis à l'hôpital.");
                break;

            case "hopitalOpen":
                GetComponent<Interactions>().PNJContact.GetComponent<Clara_Cinematic>().ExecuteCommand();
                break;

            case "policeOpen":
                GameObject.Find("doorPolice").SetActive(false);
                //GameObject.Find("trigger_PoliceReceptionist").SetActive(false);
                break;

            /*case "endDialogWilliamScott":
                GameObject.Find("dialog_williamscott").SetActive(false);
                //animation du faux scott qui sort
                //tp du vrai scott au bon endroit
                break;*/

            case "pibPhoneUnlocked":
                GameObject pibPhone = GameObject.Find("pib_phone");
                pibPhone.transform.GetChild(0).gameObject.SetActive(false);
                pibPhone.transform.GetChild(1).gameObject.SetActive(true);
                pibPhone.transform.GetChild(2).gameObject.SetActive(true);
                break;

            case "numberMarvinMeyer":
                GetComponent<Interactions>().PNJContact = GameObject.Find("marvin_meyer_phone");
                GetComponent<Interactions>().StartDialog();
                GetComponent<Interactions>().carnet.GetChild(4).GetChild(0).GetComponent<CarnetGoal>().NewGoal("- Contacter Marvin Meyer.");
                break;

            case "numberClaraGrey":
                GetComponent<Interactions>().PNJContact = GameObject.Find("clara_grey_phone");
                GetComponent<Interactions>().StartDialog();
                break;

            case "doorKurtOpen":
                GetComponent<Interactions>().PNJContact.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/Door/KEY_In_Wood_Door_01_mono");
                GetComponent<Interactions>().PNJContact.GetComponent<AudioSource>().Play();
                GameObject.Find("doorKurt").SetActive(false);
                break;

            case "GoToSleep":
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().NewGoal("- Aller Dormir.");
                break;

            case "HasSlep":
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().RemoveGoal("- Aller Dormir.");
                break;

            case "GoToSeeWhite":
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().NewGoal("- Aller voir White au commissariat.");
                break;

            case "HasSeenWhite":
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().RemoveGoal("- Aller voir White au commissariat.");
                break;

            case "HasSeenLou":
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().RemoveGoal("- Aller voir Lou Ellis à l'hôpital.");
                break;

            case "HasContactedMarvin":
                GetComponent<Interactions>().dialAndBookCanvas.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetComponent<CarnetGoal>().RemoveGoal("- Contacter Marvin Meyer.");
                break;

            default:
                break;
        }
    }
}

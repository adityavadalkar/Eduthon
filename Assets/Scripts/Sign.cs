﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public Signal contextOn;
    public Signal contextOff;
    public Button btn;
    void Start(){
        btn.onClick.AddListener(Ui);
    }

    // Update is called once per frame
    void Ui(){
        if (playerInRange){
            if (dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
            }
            else{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D box){
        if(box.CompareTag("Player")){
            //Debug.Log("Player in range...");
            playerInRange = true;
            contextOn.Raise();
        }
    }
    private void OnTriggerExit2D(Collider2D box){
        if(box.CompareTag("Player")){
            //Debug.Log("Player left range...");
            playerInRange = false;
            dialogBox.SetActive(false);
            contextOff.Raise();
        }
    }
}
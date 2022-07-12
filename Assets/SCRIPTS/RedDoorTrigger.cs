using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoorTrigger : MonoBehaviour
{
    public GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)        
    {
        if(other.CompareTag("PlayerRed")){
            GM.redPlayerInDoors= true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)        
    {
        if(other.CompareTag("PlayerRed")){
            GM.redPlayerInDoors= false;
        }  
    }
}

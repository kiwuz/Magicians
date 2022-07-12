using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControllerRight : MonoBehaviour
{
    [SerializeField] private GameObject lift;
    [SerializeField] private bool turnOnLift;

    private void Start() {
        turnOnLift = false;
    }
    void FixedUpdate()
    {
        if (turnOnLift){
            if(lift.transform.position.x < 4) {
                lift.transform.Translate(Vector2.right * Time.deltaTime * 1.5f, Space.World);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)        
    {
        if(other.CompareTag("PlayerRed")){
            turnOnLift = true;
        }   
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("PlayerRed")){
            turnOnLift = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)        
    {
        if(other.CompareTag("PlayerRed")){
            turnOnLift = false;
        }
    }
        

}

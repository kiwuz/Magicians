using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControllerLeft : MonoBehaviour
{
    [SerializeField] private GameObject lift;
    [SerializeField] private bool turnOnLift;

    private void Start() {
        turnOnLift = false;
    }

    void FixedUpdate()
    {
        if (turnOnLift){
            if(lift.transform.position.x > -0.2) {
                lift.transform.Translate(Vector2.left * Time.deltaTime * 1.5f, Space.World);
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

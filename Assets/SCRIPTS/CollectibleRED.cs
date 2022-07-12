using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleRED : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    public GameManager GM;

    void Start()
    {

        GM = FindObjectOfType<GameManager>();
        
    }



    private void OnTriggerEnter2D(Collider2D other)        
    {
        if(other.CompareTag("PlayerRed")){
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
            GM.AddGem();
            gameObject.SetActive(false);  
        }
        
    }
}
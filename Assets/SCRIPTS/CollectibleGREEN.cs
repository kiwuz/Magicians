using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleGREEN : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    public GameManager GM;

    void Start()
    {
       GM = FindObjectOfType<GameManager>();   
    }

    private void OnTriggerEnter2D(Collider2D other)        
    {
        if(other.CompareTag("PlayerGreen")){
            GM.AddGem();
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
            gameObject.SetActive(false);  
        } 
    }
}
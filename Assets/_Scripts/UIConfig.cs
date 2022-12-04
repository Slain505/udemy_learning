using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfig : MonoBehaviour
{
    public static UIConfig ui;
    public Image heart1, heart2, heart3;
    public Sprite fullHeart, emptyHeart;

    private void Awake() 
    {
        ui = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthBar() 
    {
        switch(PlayerHealth.Health.curHealth)
        {
            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart; 

                break;

            case 2:
                heart1.sprite = emptyHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;

                Debug.Log("2 Hearts left");

                break;

            case 1:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = fullHeart;

                Debug.Log("1 Heart left");

                break;

            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                Debug.Log("Dead");

                break;
            
            default:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                Debug.Log("Something weird");

                break;
        } 

    }
}

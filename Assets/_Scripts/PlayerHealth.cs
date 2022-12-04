using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour


{
    [SerializeField] public int maxHealth, curHealth;
    [SerializeField] public static PlayerHealth Health;
    [SerializeField] private Animator anim;
    [SerializeField] private float invincibleCount, invincibleDuration;

    private SpriteRenderer sr;


    private void Awake() 
    {
        Health = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        Debug.Log("Full health");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCount > 0)
        {
            invincibleCount -= Time.deltaTime;

            if(invincibleCount <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }

    public void Damage()
    {
        if(invincibleCount <= 0)
        {

        curHealth--;
        
        if(curHealth <= 0)
        {
            curHealth = 0;
            gameObject.SetActive(false);
        }
        else
        {
            invincibleCount = invincibleDuration;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);
            PlayerController.pc.KnockBack();
        }

        UIConfig.ui.UpdateHealthBar();
        
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text playerDamageText;

    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) 
        {
            playerDamageText.text = "Damage: 123" + GameObject.Find("Player").GetComponent<PlayerController>().getPlayerDamage();
            isStart = true;
        }
    }
}

using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text PlayerDamageText;

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
            PlayerDamageText.text = "Damage: 123" + GameObject.Find("Player").GetComponent<PlayerController>().getPlayerDamage();
            isStart = true;
        }
    }
}

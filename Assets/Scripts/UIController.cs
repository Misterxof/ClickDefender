using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour, IPlayerObserver
{
    [SerializeField]
    public TMP_Text PlayerDamageText;
    [SerializeField]
    public TMP_Text PlayerExpText;
    [SerializeField]
    public TMP_Text PlayerHPText;

    private PlayerPublisher _playerPublisher;
    private bool _isStart = false;

    public void OnHealthDamage(float health)
    {
        PlayerHPText.text = health.ToString() + " HP";
    }

    public void OnXPChange(float expierence, float maxExpierence)
    {
        PlayerExpText.text = expierence.ToString() + " / " + maxExpierence.ToString();
    }

    public void UpdateIt()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
        {
            _playerPublisher = PlayerPublisher.GetInstance();
            _playerPublisher.AttachObserver(this);
            PlayerDamageText.text = "Damage: 123" + GameObject.Find("Player").GetComponent<PlayerController>().getPlayerDamage();
            _isStart = true;
        }
    }
}

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerDamaged;
    [SerializeField] private TMP_Text bossDamaged;
    int playerDamagedCount = 0;
    int bossDamagedCount = 0;

    public void AddPlayerDamage()
    {
        playerDamagedCount++;
        playerDamaged.text = "Player Damaged : " + playerDamagedCount.ToString();
    }
    public void AddBossDamage()
    {
        bossDamagedCount++;
        bossDamaged.text = "Boss Damaged : " + bossDamagedCount.ToString();
    }
}

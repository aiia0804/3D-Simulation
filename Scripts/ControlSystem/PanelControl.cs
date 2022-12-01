using UnityEngine;
using TMPro;

public class PanelControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI noticeTag;
    private WInterface wInterface;
    private HosptialSpawn hosptialSpawn;
    MoneySystem moneySystem;

    private void Awake()
    {
        wInterface = FindObjectOfType<WInterface>();
        hosptialSpawn = FindObjectOfType<HosptialSpawn>();
        moneySystem = FindObjectOfType<MoneySystem>();
        noticeTag.gameObject.SetActive(false);
    }

    public void SpawnToile()
    {
        if (moneySystem.GetBalance() < 300) { NoticeTagTurnOn(); return; }
        wInterface.ActivateToilet();
        SpenMoney(300);
    }
    public void SpawnCubicle()
    {
        if (moneySystem.GetBalance() < 400) { NoticeTagTurnOn(); return; }
        wInterface.ActivateCubicle();
        SpenMoney(400);
    }

    public void SpawnNurse()
    {
        if (moneySystem.GetBalance() < 500) { NoticeTagTurnOn(); return; }
        hosptialSpawn.SpawnNurse();
        SpenMoney(500);
    }

    public void SpawnCleaner()
    {
        if (moneySystem.GetBalance() < 400) { NoticeTagTurnOn(); return; }
        hosptialSpawn.SpawCleaner();
        SpenMoney(400);
    }

    private void NoticeTagTurnOn()
    {
        noticeTag.gameObject.SetActive(true);
        Invoke(nameof(NoticeTagSwtich), 2f);
    }
    private void NoticeTagSwtich()
    {
        noticeTag.gameObject.SetActive(false);
    }

    private void SpenMoney(int money)
    {
        moneySystem.GotMoney(-money);
    }


}
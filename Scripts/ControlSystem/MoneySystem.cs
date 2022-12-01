using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] private int hold_Money;
    [SerializeField] TextMeshProUGUI money_Display;


    private void Start()
    {
        Updatedisplay();
    }

    public void GotMoney(int money)
    {
        hold_Money += money;
        Updatedisplay();
    }
    public int GetBalance()
    {
        return hold_Money;
    }

    private void Updatedisplay()
    {
        money_Display.text = hold_Money.ToString();
    }



}
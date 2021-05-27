using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public long money;
    public long moneyIncreaseAmount;
    public Text textMoney;
    public GameObject prefabMoney;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo();
        MoneyIncrease();
    }

    private void MoneyIncrease()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                money += moneyIncreaseAmount;
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(prefabMoney, mousePosition, Quaternion.identity);
            }
        }
    }

    private void ShowInfo()
    {
        if (money == 0)
        {
            textMoney.text = "0¿ø";
        }
        else
        {
            textMoney.text = money.ToString("###,###") + "¿ø";
        }
    }
}

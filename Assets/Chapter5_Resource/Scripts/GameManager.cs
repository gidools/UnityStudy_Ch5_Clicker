using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public long money;
    public long moneyIncreaseAmount;
    public long moneyIncreaseLevel;
    public long moneyIncreasePrice;
    public int employeeCount;
    public Text textMoney;
    public Text textPrice;
    public Text textRecruit;
    public Button buttonPrice;
    public Button buttonRecruit;
    public GameObject prefabMoney;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo();
        MoneyIncrease();
        UpdatePanelText();
        ButtonActiveCheck();
        UpdateRecruitPanelText();
        ButtonRecruitActiveCheck();
    }

    private void ButtonRecruitActiveCheck()
    {
        buttonRecruit.interactable = (money >= AutoWork.autoIncreasePrice);
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
            textMoney.text = "0원";
        }
        else
        {
            textMoney.text = money.ToString("###,###") + "원";
        }
    }

    private void UpdatePanelText()
    {
        textPrice.text = "Lv." + moneyIncreaseLevel + " 단가 상승\n\n";
        textPrice.text += "외주 당 단가>\n";
        textPrice.text += moneyIncreaseAmount.ToString("###,###") + " 원\n";
        textPrice.text += "업그레이드 가격>\n";
        textPrice.text += moneyIncreasePrice.ToString("###,###") + " 원";
    }

    public void UpgradePrice()
    {
        if (money >= moneyIncreasePrice)
        {
            money -= moneyIncreasePrice;
            moneyIncreaseLevel += 1;
            moneyIncreaseAmount += moneyIncreaseLevel * 100;
            moneyIncreasePrice += moneyIncreaseLevel * 500;
        }
    }

    private void ButtonActiveCheck()
    {
        buttonPrice.interactable = (money >= moneyIncreasePrice);
    }

    private void UpdateRecruitPanelText()
    {
        textRecruit.text = "Lv." + employeeCount + " 직원 고용\n\n";
        textRecruit.text += "직원 1초 당 단가 > \n";
        textRecruit.text += AutoWork.autoMoneyIncreaseAmount.ToString("###,###") + " 원\n";
        textRecruit.text += "업그레이드 가격 > \n";
        textRecruit.text += AutoWork.autoIncreasePrice.ToString("###,###") + " 원\n";
    }
}

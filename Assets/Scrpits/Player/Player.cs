using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private float currentMoney;
    private Dictionary<string, int> stocksOwnedPerCompany = new();
    private Dictionary<string, float> spentPerCompany = new();

    public Player()
    {
        currentMoney = 10000000f;
    }

    public bool BuyStock(string company, float stockPrice, int quantity)
    {
        float totalCost = stockPrice * quantity;
        if (currentMoney >= totalCost)
        {
            currentMoney -= totalCost;

            if (!stocksOwnedPerCompany.ContainsKey(company))
                stocksOwnedPerCompany[company] = 0;
            if (!spentPerCompany.ContainsKey(company))
                spentPerCompany[company] = 0f;

            stocksOwnedPerCompany[company] += quantity;
            spentPerCompany[company] += totalCost;

            return true;
        }
        return false;
    }

    public void SellStock(string company, float stockPrice, int quantity)
    {
        if (!stocksOwnedPerCompany.ContainsKey(company)) return;

        currentMoney += stockPrice * quantity;
        stocksOwnedPerCompany[company] -= quantity;

        float refund = stockPrice * quantity;
        spentPerCompany[company] -= refund;
        if (spentPerCompany[company] < 0f)
            spentPerCompany[company] = 0f;
    }

    public float GetMoney()
    {
        return currentMoney;
    }

    public string GetMoneyInfo()
    {
        return $"Current Money: ${currentMoney:F2}";
    }

    public int GetStockOwned(string company)
    {
        return stocksOwnedPerCompany.ContainsKey(company) ? stocksOwnedPerCompany[company] : 0;
    }

    public float GetSpent(string company)
    {
        return spentPerCompany.ContainsKey(company) ? spentPerCompany[company] : 0f;
    }

    public Dictionary<string, int> GetAllStocksOwned()
    {
        return stocksOwnedPerCompany;
    }

    public Dictionary<string, float> GetAllSpent()
    {
        return spentPerCompany;
    }
}




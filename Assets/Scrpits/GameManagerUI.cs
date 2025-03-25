using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManagerUI : MonoBehaviour
{
    public GameObject goldPanel, stocksPanel, cryptoPanel, realEstatePanel, bankPanel, businessPanel, forexPanel;
    public GameObject companyButtonsGroup;

    public Button goldButton, stocksButton, cryptoButton, realEstateButton, bankButton, businessButton, forexButton;
    public List<Button> backButtons;

    public TMP_Text timerText, currentRoundText, roundStatusText;
    public TMP_Text playerMoneyText, purchaseStatusText;
    public TMP_InputField quantityInputField;
    public Button nextRoundButton;

    public Dictionary<string, TMP_Text> companyStockTexts = new();
    public Dictionary<string, TMP_Text> companyTitleTexts = new();
    public Dictionary<string, TMP_Text> companyPriceTexts = new();

    private Dictionary<string, ICompany> companies;
    private Player player;
    private int currentRound = 0;
    public float roundDuration = 120f;
    private float timeRemaining;
    private bool isGameOver = false;

    private Dictionary<string, GameObject> panelMap;

    [Header("Company Owned Texts")]
    [SerializeField] private TMP_Text goldOwnedText, stocksOwnedText, cryptoOwnedText, realEstateOwnedText, bankOwnedText, businessOwnedText, forexOwnedText;
    [Header("Company Title Texts")]
    [SerializeField] private TMP_Text goldTitleText, stocksTitleText, cryptoTitleText, realEstateTitleText, bankTitleText, businessTitleText, forexTitleText;
    [Header("Company Price Texts")]
    [SerializeField] private TMP_Text goldPriceText, stocksPriceText, cryptoPriceText, realEstatePriceText, bankPriceText, businessPriceText, forexPriceText;

    [Header("Round Summary")]
    [SerializeField] private GameObject roundSummaryPanel;
    [SerializeField] private TMP_Text roundSummaryText;
    [SerializeField] private Button nextRoundConfirmButton;

    void Start()
    {
        SetupCompanyStockTexts();
        SetupCompanyDisplayTexts();
        player = new Player();

        currentRound = 0;
        currentRoundText.text = "Round: 1";
        roundStatusText.text = "Ready to Start!";

        SetupCompanies();
        SetupPanelMap();
        SetupButtons();

        CloseAllPanels();
        companyButtonsGroup.SetActive(true);

        nextRoundButton.gameObject.SetActive(true);
        nextRoundButton.onClick.AddListener(() => StartNextRound());

        nextRoundConfirmButton.onClick.AddListener(() => {
            roundSummaryPanel.SetActive(false);
            StartNextRound();
        });

        UpdatePlayerUI();
    }

    void SetupCompanies()
    {
        companies = new Dictionary<string, ICompany>
        {
            { "Gold", new GoldCompany() },
            { "Stocks", new StocksCompany() },
            { "Crypto", new CryptoCompany() },
            { "Real Estate", new RealEstateCompany() },
            { "Bank", new BankCompany() },
            { "Business", new BusinessCompany() },
            { "Forex", new ForexCompany() }
        };
    }

    void SetupPanelMap()
    {
        panelMap = new Dictionary<string, GameObject>
        {
            { "Gold", goldPanel },
            { "Stocks", stocksPanel },
            { "Crypto", cryptoPanel },
            { "Real Estate", realEstatePanel },
            { "Bank", bankPanel },
            { "Business", businessPanel },
            { "Forex", forexPanel }
        };
    }

    void SetupCompanyStockTexts()
    {
        companyStockTexts["Gold"] = goldOwnedText;
        companyStockTexts["Stocks"] = stocksOwnedText;
        companyStockTexts["Crypto"] = cryptoOwnedText;
        companyStockTexts["Real Estate"] = realEstateOwnedText;
        companyStockTexts["Bank"] = bankOwnedText;
        companyStockTexts["Business"] = businessOwnedText;
        companyStockTexts["Forex"] = forexOwnedText;
    }

    void SetupCompanyDisplayTexts()
    {
        companyTitleTexts["Gold"] = goldTitleText;
        companyTitleTexts["Stocks"] = stocksTitleText;
        companyTitleTexts["Crypto"] = cryptoTitleText;
        companyTitleTexts["Real Estate"] = realEstateTitleText;
        companyTitleTexts["Bank"] = bankTitleText;
        companyTitleTexts["Business"] = businessTitleText;
        companyTitleTexts["Forex"] = forexTitleText;

        companyPriceTexts["Gold"] = goldPriceText;
        companyPriceTexts["Stocks"] = stocksPriceText;
        companyPriceTexts["Crypto"] = cryptoPriceText;
        companyPriceTexts["Real Estate"] = realEstatePriceText;
        companyPriceTexts["Bank"] = bankPriceText;
        companyPriceTexts["Business"] = businessPriceText;
        companyPriceTexts["Forex"] = forexPriceText;
    }

    void SetupButtons()
    {
        goldButton.onClick.AddListener(() => OpenPanel("Gold"));
        stocksButton.onClick.AddListener(() => OpenPanel("Stocks"));
        cryptoButton.onClick.AddListener(() => OpenPanel("Crypto"));
        realEstateButton.onClick.AddListener(() => OpenPanel("Real Estate"));
        bankButton.onClick.AddListener(() => OpenPanel("Bank"));
        businessButton.onClick.AddListener(() => OpenPanel("Business"));
        forexButton.onClick.AddListener(() => OpenPanel("Forex"));

        foreach (var backBtn in backButtons)
            backBtn.onClick.AddListener(CloseAllPanels);
    }

    public void OpenPanel(string companyName)
    {
        CloseAllPanels();
        if (panelMap.ContainsKey(companyName))
        {
            panelMap[companyName].SetActive(true);
            companyButtonsGroup.SetActive(false);

            if (companyTitleTexts.ContainsKey(companyName))
                companyTitleTexts[companyName].text = companies[companyName].CompanyName;

            if (companyPriceTexts.ContainsKey(companyName))
                companyPriceTexts[companyName].text = companies[companyName].GetPriceInfo();
        }
    }

    public void CloseAllPanels()
    {
        foreach (var panel in panelMap.Values)
            panel.SetActive(false);

        companyButtonsGroup.SetActive(true);
        UpdatePlayerUI();
    }

    public void BuyStock(string company)
    {
        if (!companies.ContainsKey(company)) return;
        if (!int.TryParse(quantityInputField.text, out int quantity) || quantity <= 0)
        {
            purchaseStatusText.text = "Invalid quantity!";
            return;
        }

        float price = companies[company].GetPrice();
        float total = price * quantity;

        if (player.BuyStock(company, price, quantity))
        {
            purchaseStatusText.text = $"Bought {quantity} {company} at ${price:F2} each. Total: ${total:F2}";
        }
        else
        {
            purchaseStatusText.text = $"Not enough money! Needed: ${total:F2}";
        }
        UpdatePlayerUI();
    }

    public void SellStock(string company)
    {
        if (!companies.ContainsKey(company)) return;
        if (!int.TryParse(quantityInputField.text, out int quantity) || quantity <= 0)
        {
            purchaseStatusText.text = "Invalid quantity!";
            return;
        }

        int owned = player.GetStockOwned(company);
        float price = companies[company].GetPrice();
        float total = price * quantity;

        if (owned < quantity)
        {
            purchaseStatusText.text = $"Not enough stocks! You own: {owned}";
            return;
        }

        player.SellStock(company, price, quantity);
        purchaseStatusText.text = $"Sold {quantity} {company} at ${price:F2} each. Total: ${total:F2}";
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        playerMoneyText.text = player.GetMoneyInfo();

        foreach (var entry in companies.Keys)
        {
            if (companyStockTexts.ContainsKey(entry))
            {
                int qty = player.GetStockOwned(entry);
                companyStockTexts[entry].text = $"Owned: {qty}";
            }

            if (companyPriceTexts.ContainsKey(entry))
            {
                companyPriceTexts[entry].text = companies[entry].GetPriceInfo();
            }

            if (companyTitleTexts.ContainsKey(entry))
            {
                companyTitleTexts[entry].text = companies[entry].CompanyName;
            }
        }
    }

    void StartNextRound()
    {
        if (isGameOver) return;
        CloseAllPanels();

        nextRoundButton.gameObject.SetActive(false);

        if (currentRound >= 10)
        {
            EndGame();
            return;
        }

        roundStatusText.text = $"Round {currentRound + 1} Starting!";
        timeRemaining = roundDuration;
        StartCoroutine(RoundTimer());
    }

    private IEnumerator RoundTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = $"Time Remaining: {Mathf.Ceil(timeRemaining)}s";
            yield return null;
        }

        foreach (var company in companies.Values)
            company.UpdatePrice();

        currentRound++;

        if (currentRound > 1)
        {
            ShowRoundSummary();
            roundSummaryPanel.SetActive(true);
        }
        else
        {
            nextRoundButton.gameObject.SetActive(true);
        }

        roundStatusText.text = $"Round {currentRound} Summary!";
        currentRoundText.text = $"Round: {currentRound}";
    }

    void ShowRoundSummary()
    {
        string summary = $"Round {currentRound} Summary:\n";
        float totalProfitLoss = 0f;

        foreach (var companyName in companies.Keys)
        {
            float price = companies[companyName].GetPrice();
            int qty = player.GetStockOwned(companyName);
            float value = price * qty;
            float spent = player.GetSpent(companyName);
            float profit = value - spent;
            totalProfitLoss += profit;

            summary += $"{companyName}: Spent ${spent:F2}, Value ${value:F2}, P/L ${profit:F2}\n";
        }

        summary += $"Total P/L: ${totalProfitLoss:F2}";

        roundSummaryText.text = summary;
    }

    void EndGame()
    {
        isGameOver = true;
        nextRoundButton.gameObject.SetActive(false);
        roundStatusText.text = "Game Over!";
        UpdatePlayerUI();
    }
}

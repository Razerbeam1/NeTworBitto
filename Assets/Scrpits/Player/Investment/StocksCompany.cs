using UnityEngine;

public class StocksCompany : ICompany
{
    private float stockPrice = 150f;  // ราคาหุ้นเริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลงในแต่ละรอบ
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Stocks";

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของราคาหุ้น (ระหว่าง -2% ถึง +3%)
        changePercentage = Random.Range(-2f, 3f);  // เปลี่ยนแปลงระหว่าง -2% ถึง +3%

        // คำนวณราคาหุ้นจากการเปลี่ยนแปลง
        stockPrice *= 1 + (changePercentage + investmentChangePercent) / 100;  // ใช้การเปลี่ยนแปลงสะสม

        // สะสมเปอร์เซ็นต์การเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมการเปลี่ยนแปลง
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Price: ${stockPrice:F2}\nChange: {changePercentage + investmentChangePercent:F2}%";
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;  // คืนค่าเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    }

    // ฟังก์ชันสำหรับดึงราคาหุ้น
    public float GetPrice()
    {
        return stockPrice;  // คืนค่าราคาหุ้นปัจจุบัน
    }
}


using UnityEngine;

public class CryptoCompany : ICompany
{
    private float cryptoPrice = 50000f;  // ราคาคริปโตเริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลงของราคาคริปโต
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Crypto";

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของราคาคริปโต (ระหว่าง -10% ถึง +10%)
        changePercentage = Random.Range(-10f, 10f);

        // คำนวณราคาคริปโตจากราคาของรอบก่อนหน้า
        cryptoPrice *= 1 + changePercentage / 100;  // การเปลี่ยนแปลงจากราคาปัจจุบัน

        // สะสมเปอร์เซ็นต์การเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมการเปลี่ยนแปลง
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Price: ${cryptoPrice:F2}\nChange: {changePercentage:F2}%\nCumulative Change: {investmentChangePercent:F2}%";
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;
    }

    // ฟังก์ชันสำหรับดึงราคาของคริปโต
    public float GetPrice()
    {
        return cryptoPrice;  // คืนราคาของคริปโต
    }
}




using UnityEngine;

public class GoldCompany : ICompany
{
    private float goldPrice = 1800f;  // ราคาทองคำเริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลงในแต่ละรอบ
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Gold";  // ใช้ auto-property getter

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของราคาทองคำ (ระหว่าง -0.1% ถึง +0.5%)
        changePercentage = Random.Range(-0.1f, 0.5f);

        // การคำนวณราคาทองคำจากการเปลี่ยนแปลงสะสม
        goldPrice *= 1 + (changePercentage + investmentChangePercent) / 100;  // ใช้การเปลี่ยนแปลงสะสมในการคำนวณ

        // สะสมการเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมการเปลี่ยนแปลง
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Price: ${goldPrice:F2}\nChange: {changePercentage + investmentChangePercent:F2}%";  // แสดงข้อมูลราคาปัจจุบัน
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;  // คืนค่าเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    }

    // ฟังก์ชันสำหรับดึงราคาทองคำ
    public float GetPrice()
    {
        return goldPrice;  // คืนค่าราคาทองคำปัจจุบัน
    }
}


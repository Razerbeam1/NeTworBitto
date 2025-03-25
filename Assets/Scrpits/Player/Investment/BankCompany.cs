using UnityEngine;

public class BankCompany : ICompany
{
    private float bankValue = 1000f;  // มูลค่าธนาคารเริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลง
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Bank";

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของมูลค่าธนาคาร (ระหว่าง 0.5% ถึง +1%)
        changePercentage = Random.Range(0.5f, 1f);

        // คำนวณราคามูลค่าธนาคารจากราคาในรอบก่อนหน้า
        bankValue *= 1 + changePercentage / 100;  // การเปลี่ยนแปลงจากราคาปัจจุบัน

        // สะสมเปอร์เซ็นต์การเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมการเปลี่ยนแปลง
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Value: ${bankValue:F2}\nChange: {changePercentage + investmentChangePercent:F2}%";  // แสดงข้อมูลราคาปัจจุบัน
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;  // คืนค่าเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    }

    // ฟังก์ชันสำหรับดึงราคามูลค่าธนาคาร
    public float GetPrice()
    {
        return bankValue;  // คืนค่าราคามูลค่าธนาคาร
    }
}


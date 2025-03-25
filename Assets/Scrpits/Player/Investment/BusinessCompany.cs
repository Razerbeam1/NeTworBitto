using UnityEngine;

public class BusinessCompany : ICompany
{
    private float businessValue = 10000f;  // มูลค่าธุรกิจเริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลงในแต่ละรอบ
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Business";

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของมูลค่าธุรกิจ (ระหว่าง -3% ถึง +5%)
        changePercentage = Random.Range(-3f, 5f);

        // การคำนวณราคามูลค่าธุรกิจจากราคาในรอบก่อนหน้า
        businessValue *= 1 + (changePercentage + investmentChangePercent) / 100;  // ใช้การเปลี่ยนแปลงสะสม

        // สะสมการเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมเปอร์เซ็นต์การเปลี่ยนแปลง
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Value: ${businessValue:F2}\nChange: {changePercentage + investmentChangePercent:F2}%";  // แสดงข้อมูลราคาปัจจุบัน
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;  // คืนค่าเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    }

    // ฟังก์ชันสำหรับดึงราคามูลค่าธุรกิจ
    public float GetPrice()
    {
        return businessValue;  // คืนค่าราคาปัจจุบันของมูลค่าธุรกิจ
    }
}


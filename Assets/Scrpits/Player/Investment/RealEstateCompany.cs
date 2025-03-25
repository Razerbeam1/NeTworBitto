using UnityEngine;

public class RealEstateCompany : ICompany
{
    private float realEstatePrice = 50000f;  // ราคอสังหาฯ เริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลงในแต่ละรอบ
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Real Estate";

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของราคาอสังหาฯ
        changePercentage = Random.Range(-1f, 2f);  // เปลี่ยนแปลงในช่วง -1% ถึง +2%

        // การคำนวณราคอสังหาฯ จากราคาก่อนหน้า
        realEstatePrice *= 1 + (changePercentage + investmentChangePercent) / 100;  // อัปเดตราคาอสังหาฯ

        // สะสมการเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมการเปลี่ยนแปลงจากรอบก่อนหน้า
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Price: ${realEstatePrice:F2}\nChange: {changePercentage + investmentChangePercent:F2}%";  // แสดงข้อมูลราคาปัจจุบัน
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;  // คืนค่าเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    }

    // ฟังก์ชันสำหรับดึงราคอสังหาฯ
    public float GetPrice()
    {
        return realEstatePrice;  // คืนค่าราคาของอสังหาฯ
    }
}


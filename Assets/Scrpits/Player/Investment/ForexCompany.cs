using UnityEngine;

public class ForexCompany : ICompany
{
    private float forexValue = 2000f;  // มูลค่า Forex เริ่มต้น
    private float changePercentage;  // เปอร์เซ็นต์การเปลี่ยนแปลงในแต่ละรอบ
    private float investmentChangePercent = 0f;  // การเปลี่ยนแปลงสะสม

    public string CompanyName => "Forex";

    public void UpdatePrice()
    {
        // การสุ่มการเปลี่ยนแปลงของมูลค่า Forex (ระหว่าง -2% ถึง +2%)
        changePercentage = Random.Range(-2f, 2f);

        // การคำนวณมูลค่า Forex จากการเปลี่ยนแปลง
        forexValue *= 1 + changePercentage / 100;  // การเปลี่ยนแปลงจากราคาปัจจุบัน

        // สะสมการเปลี่ยนแปลง
        investmentChangePercent += changePercentage;  // สะสมการเปลี่ยนแปลง
    }

    public string GetPriceInfo()
    {
        return $"{CompanyName} Value: ${forexValue:F2}\nChange: {changePercentage + investmentChangePercent:F2}%";  // แสดงข้อมูลมูลค่าปัจจุบัน
    }

    // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    public float GetChangePercentage()
    {
        return investmentChangePercent;  // คืนค่าเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
    }

    // ฟังก์ชันสำหรับดึงราคาของ Forex
    public float GetPrice()
    {
        return forexValue;  // คืนค่าราคาของ Forex
    }
}

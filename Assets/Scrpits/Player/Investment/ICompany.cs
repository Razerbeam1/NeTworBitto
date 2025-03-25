using UnityEngine;

public interface ICompany
{
    string CompanyName { get; }
    void UpdatePrice();
    string GetPriceInfo();
    float GetChangePercentage();  // ฟังก์ชันสำหรับดึงเปอร์เซ็นต์การเปลี่ยนแปลง

    float GetPrice();  // เพิ่มฟังก์ชันนี้เพื่อดึงราคา
}



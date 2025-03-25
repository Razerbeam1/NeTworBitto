using UnityEngine;
using UnityEngine.UI;

public class CompanyUI : MonoBehaviour
{
    public GameObject companyUIPanel;  // UI Panel ที่จะแสดงข้อมูลบริษัท
    public Text companyNameText;       // ชื่อบริษัท
    public Text investmentAmountText;  // จำนวนเงินลงทุน
    public Text changePercentageText;  // เปอร์เซ็นต์การเปลี่ยนแปลง
    public Button closeButton;         // ปุ่มสำหรับปิด UI

    // แสดงข้อมูลบริษัท
    public void ShowCompanyInfo(string companyName, float investmentValue, float changePercentage)
    {
        companyUIPanel.SetActive(true);  // แสดง UI ของบริษัท
        companyNameText.text = companyName;  // แสดงชื่อบริษัท
        investmentAmountText.text = $"Investment: {investmentValue:C}";  // แสดงจำนวนเงินลงทุน
        changePercentageText.text = $"Change: {changePercentage:+0.0;-0.0}%";  // แสดงการเปลี่ยนแปลง
    }

    // ปิด UI ของบริษัท
    public void CloseCompanyUI()
    {
        companyUIPanel.SetActive(false);  // ซ่อน UI ของบริษัท
    }

    void Start()
    {
        closeButton.onClick.AddListener(CloseCompanyUI);  // เพิ่มการทำงานให้ปุ่มปิด
    }
}


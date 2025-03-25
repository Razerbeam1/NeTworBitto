public class Investment
{
    public string name;
    public float initialValue;
    public float currentValue;
    public float changePercentage;
    public float investmentChangePercent;  // เพิ่มตัวแปรสำหรับเก็บเปอร์เซ็นต์การเปลี่ยนแปลงสะสม

    public Investment(string name, float initialValue)
    {
        this.name = name;
        this.initialValue = initialValue;
        this.currentValue = initialValue;
        this.changePercentage = 0;
        this.investmentChangePercent = 0;  // เริ่มต้นการเปลี่ยนแปลงเป็น 0
    }

    // อัปเดตการลงทุนเมื่อมีการเปลี่ยนแปลง
    public void UpdateInvestment(float percentageChange)
    {
        changePercentage = percentageChange;
        investmentChangePercent += percentageChange;  // เก็บเปอร์เซ็นต์การเปลี่ยนแปลงสะสม
        currentValue *= (1 + investmentChangePercent / 100);  // ใช้เปอร์เซ็นต์สะสมในการคำนวณ
    }

    // ฟังก์ชันนี้จะใช้สำหรับเรียกข้อมูล
    public string GetInvestmentInfo()
    {
        return $"{name} Initial Value: ${initialValue:F2}, Current Value: ${currentValue:F2}, Change: {investmentChangePercent:F2}%";
    }



}


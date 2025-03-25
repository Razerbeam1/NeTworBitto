using UnityEngine;

public interface ICompany
{
    string CompanyName { get; }
    void UpdatePrice();
    string GetPriceInfo();
    float GetChangePercentage();  // �ѧ��ѹ����Ѻ�֧�����繵�������¹�ŧ

    float GetPrice();  // �����ѧ��ѹ������ʹ֧�Ҥ�
}



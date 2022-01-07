using UnityEngine;
using Game.Pool;

public interface IErasing
{
    /// <summary>
    /// ���� ����� ���������� ������ ����� ����� ��������� ����� �������.
    /// ���������� �������� true ���� ������ ����� �������
    /// </summary>
    /// <param name="worldPosition"></param>
    public bool Erase(Vector2 worldPosition, float brushRadius);
    public void Delete();
}
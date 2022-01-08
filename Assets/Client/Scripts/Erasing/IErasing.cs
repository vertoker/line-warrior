using UnityEngine;
using Game.Pool;

public interface IErasing
{
    /// <summary>
    /// Этот метод вызывается только когда кисть коснулась части объекта.
    /// Необходимо отсылать true если объект нужно удалить
    /// </summary>
    /// <param name="worldPosition"></param>
    public bool Erase(Vector2 worldPosition, float brushRadius);
    public void Delete();
}
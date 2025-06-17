using UnityEngine;
public interface IDropItem
{
    /// <summary> 아이템 줍기 </summary>
    void Grab(Transform param_grab_pos);

    /// <summary> 아이템 버리기 </summary>
    void Drop();

    /// <summary> 아이템 사용 </summary>
    void Use();
}
using Array2DEditor;
using UnityEngine;

[System.Serializable]
public class Array2DGameObject : Array2D<GameObject>
{
    [SerializeField]
    CellRowGameObject[] cells = new CellRowGameObject[Consts.defaultGridSize];

    protected override CellRow<GameObject> GetCellRow(int idx)
    {
        return cells[idx];
    }
}

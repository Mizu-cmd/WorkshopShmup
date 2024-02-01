using Array2DEditor;
using UnityEngine;

[System.Serializable]
public class Array2DEnemyEnum : Array2D<EnemyEnum>
{
    [SerializeField]
    CellRowEnemyEnum[] cells = new CellRowEnemyEnum[Consts.defaultGridSize];

    protected override CellRow<EnemyEnum> GetCellRow(int idx)
    {
        return cells[idx];
    }
}
    
[System.Serializable]
public class CellRowEnemyEnum : CellRow<EnemyEnum> { }

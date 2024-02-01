using Array2DEditor;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Array2DGameObject))]
public class Array2DGameObjectDrawer :  Array2DObjectDrawer<GameObject>
{
    protected override Vector2Int GetDefaultCellSizeValue() => new Vector2Int(96, 16);
}

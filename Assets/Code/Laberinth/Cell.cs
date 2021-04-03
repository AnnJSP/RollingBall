using UnityEngine;


namespace Code
{
    public struct Cell
    {
        public Vector3 Position;
        public bool IsBusy;
        public int RowX;
        public int ColumnZ;

        public Cell(int _rowX, int _columnZ, Vector3 _position = default, bool _isBusy = false)
        {
            RowX = _rowX;
            ColumnZ = _columnZ;
            Position = _position;
            IsBusy = _isBusy;
        }
    }
}
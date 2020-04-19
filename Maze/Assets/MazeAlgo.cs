using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeAlgo {
    protected int xRow, zColoumn;
    protected HexCell[,] cell;

    protected MazeAlgo(HexCell[,] cell) : base()
    {
        this.cell = cell;
        xRow = cell.GetLength(0);
        zColoumn = cell.GetLength(1);
    }

    public abstract void GenerateMaze();


}

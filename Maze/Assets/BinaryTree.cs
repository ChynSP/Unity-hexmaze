using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MazeAlgo
{
    private int currentRow = 0;
    private int currentCol = 0;

    private int direction;
    private int choice;

    public BinaryTree(HexCell[,] cell) : base(cell) {
    }

    public override void GenerateMaze()
    {
        //exit       
        DestroyWall(cell[0, 0].W_Wall);

        for (currentCol = 0; currentCol < zColoumn; currentCol++)
        {
            for (currentRow = 0; currentRow < xRow; currentRow++)
            {
                direction = Random.Range(1, 3);


                //E path if not end coloumn, if even end coloumn chance NE path
                if (direction == 1)
                {
                    if (currentCol != zColoumn - 1)
                    {
                        Debug.Log("East" + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].E_Wall);
                    }
                    else if (currentCol == zColoumn - 1 && currentRow % 2 == 0)
                    {
                        Debug.Log("NW " + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].NW_Wall);
                    }
                    else if (currentCol == zColoumn - 1 && currentRow % 2 != 0)
                    {
                        Debug.Log("NE " + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].NE_Wall);
                    }

                }

                //NE path if not end row and not odd end coloumn
                if (direction == 2)
                {
                    if (currentRow == xRow - 1)
                    {
                        Debug.Log("East " + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].E_Wall);

                    }
                    else if (currentCol != zColoumn - 1)
                    {
                        Debug.Log("NE " + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].NE_Wall);
                    }
                    else if (currentCol == zColoumn - 1 && currentRow % 2 == 0)
                    {
                        Debug.Log("NW " + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].NW_Wall);
                    }
                    else if (currentCol == zColoumn - 1 && currentRow % 2 != 0)
                    {
                        Debug.Log("NE " + currentRow.ToString() + currentCol.ToString());
                        DestroyWall(cell[currentRow, currentCol].NE_Wall);

                    }
                }
            }          
        }

        void DestroyWall(GameObject wall)
        {
            if (wall != null)
            {
                GameObject.Destroy(wall);
            }
        }     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject HexTilePrefab;
    public GameObject HexWallPrefab;

    private HexCell[,] cell;

    [SerializeField] int xRow = 8;
    [SerializeField] int zColoumn = 8;

    float xOddOffset = 1.55f;
    float zOddOffset = 1.78f;

    void Start()
    {
        CreateHexGrid();

        MazeAlgo bta = new BinaryTree(cell);
        bta.GenerateMaze();
        
    }

    void CreateHexGrid()
    {
        cell = new HexCell[xRow, zColoumn];

        for (int z = 0; z < zColoumn; z++)
        {
            for (int x = 0; x < xRow; x++)
            {
                cell[x, z] = new HexCell();
                cell[x, z].tiles = Instantiate(HexTilePrefab);
                cell[x, z].E_Wall = Instantiate(HexWallPrefab);
                cell[x, z].NW_Wall = Instantiate(HexWallPrefab);
                cell[x, z].NE_Wall = Instantiate(HexWallPrefab);
               


                //EVEN ROWS
                if (x % 2 != 0)
                {

                    cell[x, z].tiles.transform.position = new Vector3(z * zOddOffset, 0, x * xOddOffset);

                    cell[x, z].E_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset / 2, 0.8f, x * xOddOffset);

                    cell[x, z].NW_Wall.transform.Rotate(0, 0, 60f);
                    cell[x, z].NW_Wall.transform.position = new Vector3(z * zOddOffset - zOddOffset / 4, 0.8f, x * xOddOffset + xOddOffset / 2);
                    cell[x, z].NE_Wall.transform.Rotate(0, 0, -60f);
                    cell[x, z].NE_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset * 0.25f, 0.8f, x * xOddOffset + xOddOffset / 2);
                    

                    if (z == 0)
                    {
                        cell[x, z].BorderTile = true;
                        cell[x, z].W_Wall = Instantiate(HexWallPrefab);
                        cell[x, z].W_Wall.transform.position = new Vector3(z * zOddOffset - zOddOffset / 2, 0.8f, x * xOddOffset);

                        cell[x, z].SW_Wall = Instantiate(HexWallPrefab);
                        cell[x, z].SW_Wall.transform.Rotate(0, 0, -60f);
                        cell[x, z].SW_Wall.transform.position = new Vector3(z * zOddOffset - zOddOffset / 3.5f, 0.8f, x * xOddOffset - xOddOffset / 2);

                        cell[x, z].SW_Wall.transform.parent = transform;
                        cell[x, z].SW_Wall.name = "Wall SW " + x.ToString() + ", " + z.ToString();
                    }

                }
                //ODD ROWS
                else
                {
                    cell[x, z].tiles.transform.position = new Vector3(z * zOddOffset + zOddOffset / 2, 0, x * xOddOffset);

                    cell[x, z].E_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset, 0.8f, x * xOddOffset);

                    cell[x, z].NW_Wall.transform.Rotate(0, 0, 60f);
                    cell[x, z].NW_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset / 4, 0.8f, x * xOddOffset + xOddOffset / 2);

                    cell[x, z].NE_Wall.transform.Rotate(0, 0, -60f);
                    cell[x, z].NE_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset * 0.75f, 0.8f, x * xOddOffset + xOddOffset / 2);
                    

                    if (z == 0)
                    {                        
                        cell[x, z].BorderTile = true;
                        cell[x, z].W_Wall = Instantiate(HexWallPrefab);
                        cell[x, z].W_Wall.transform.position = new Vector3(z * zOddOffset, 0.8f, x * xOddOffset);
       
                    }


                    
                }

                if (x == 0)
                {                    
                    cell[x, z].SW_Wall = Instantiate(HexWallPrefab);
                    cell[x, z].SE_Wall = Instantiate(HexWallPrefab);

                    cell[x, z].SW_Wall.transform.Rotate(0, 0, -60f);
                    cell[x, z].SW_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset / 4, 0.8f, x * xOddOffset - xOddOffset / 2);

                    cell[x, z].SE_Wall.transform.Rotate(0, 0, 60f);
                    cell[x, z].SE_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset * 0.75f, 0.8f, x * xOddOffset - xOddOffset / 2);
                }

                if (z == zColoumn - 1 && x % 2 == 0)
                {
                    cell[x, z].BorderTile = true;
                    cell[x, z].SE_Wall = Instantiate(HexWallPrefab);
                    cell[x, z].SE_Wall.transform.Rotate(0, 0, 60f);
                    cell[x, z].SE_Wall.transform.position = new Vector3(z * zOddOffset + zOddOffset * 0.75f, 0.8f, x * xOddOffset - xOddOffset / 2);
                }

                Index(x, z);
            }

            
        }
    }

    void Index(int x, int z)
    {
        
        cell[x, z].E_Wall.transform.parent = transform;
        cell[x, z].E_Wall.name = "Wall E " + x.ToString() + ", " + z.ToString();

        cell[x, z].NW_Wall.transform.parent = transform;
        cell[x, z].NW_Wall.name = "Wall NW " + x.ToString() + ", " + z.ToString();

        cell[x, z].NE_Wall.transform.parent = transform;
        cell[x, z].NE_Wall.name = "Wall NE " + x.ToString() + ", " + z.ToString();

        cell[x, 0].W_Wall.transform.parent = transform;
        cell[x, 0].W_Wall.name = "Wall W " + x.ToString() + ", 0";

        cell[0, z].SW_Wall.transform.parent = transform;
        cell[0, z].SW_Wall.name = "Wall SW 0, " + z.ToString();

        cell[0, z].SE_Wall.transform.parent = transform;
        cell[0, z].SE_Wall.name = "Wall SE 0, " + z.ToString();

        cell[x, z].tiles.transform.parent = transform;
        cell[x, z].tiles.name = x.ToString() + ", " + z.ToString();

    }
}

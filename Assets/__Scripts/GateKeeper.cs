using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeeper : MonoBehaviour
{
    const int lockedR = 95;
    const int lockeUR = 81;
    const int lockedUL = 80;
    const int lockedL = 100;
    const int lockedDl = 101;
    const int lockedDR = 102;

    const int openR = 48;
    const int openUR = 93;
    const int openUL = 92;
    const int openL = 51;
    const int openDL = 26;
    const int openDR = 27;

    private IKeyMaster keys;

    private void Awake()
    {
        keys = GetComponent<IKeyMaster>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (keys.keyCount < 1)
        {
            return;
        }

        Tile tl = collision.gameObject.GetComponent<Tile>();
        if (tl == null)
        {
            return;
        }

        int facing = keys.GetFacing();
        Tile tl2;

        switch(tl.tileNum)
        {
            case lockedR:
                if (facing !=0)
                {
                    return;
                }
                tl.SetTile(tl.x, tl.y, openR);
                break;
            case lockeUR:
                if (facing != 1)
                {
                    return;
                }
                tl.SetTile(tl.x,tl.y, openUR);
                tl2 = TileCamera.TILES[tl.x - 1, tl.y];
                tl2.SetTile(tl2.x, tl2.y, openUL);
                break;
            case lockedUL:
                if (facing != 1)
                {
                    return;
                }
                tl.SetTile(tl.x, tl.y, openUL);
                tl2 = TileCamera.TILES[tl.x + 1, tl.y];
                tl2.SetTile(tl2.x, tl2.y, openUR);
                break;
            case lockedL:
                if (facing != 2)
                {
                    return;
                }
                tl.SetTile(tl.x, tl.y, openL);
                break;
            case lockedDl:
                if (facing != 3)
                {
                    return;
                }

                tl.SetTile(tl.x, tl.y, openDL);
                tl2 = TileCamera.TILES[tl.x + 1, tl.y];
                tl2.SetTile(tl2.x, tl2.y, openDR);
                break;

            case lockedDR:
                if (facing != 3)
                {
                    return;
                }
                tl.SetTile(tl.x, tl.y, openDR);
                tl2 = TileCamera.TILES[tl.x - 1, tl.y];
                tl2.SetTile(tl2.x, tl2.y, openDL);
                break;
            default:
                return;
                
        }
        keys.keyCount--;
    }
}

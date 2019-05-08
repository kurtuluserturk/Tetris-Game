﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    // The Grid itself
    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w, h];
    //The roundVec2 helper Function
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), 
                           Mathf.Round(v.y));
    }
    //The insideBorder helper Function
    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && 
                (int)pos.x < w && 
                (int)pos.y >= 0);
    } // it doesn't check if pos.y < h because groups don't really move upwards, except for some rotations.
    //The deleteRow helper Function
    public static void deleteRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }
    //The decreaseRow helper function
    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                //Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }
    //The decreaseRowsAbove function
    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
            decreaseRow(i);
    }
    //The isRowFull function
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }
    //The deleteFullRows function
    public static void deleteFullRows()
    {
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;   // --y decreases y by one whenever a row was deleted. It's to make sure that the next step of the for loop continues at the correct index (which must be decreased by one, because we just deleted a row).
            }
        }
    }    
}
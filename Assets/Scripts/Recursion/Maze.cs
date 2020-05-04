using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    //class Block
    //{
    //    public Vector2 pos;
    //    public BlockType type;

    //    public Block(Vector2 pos, BlockType type)
    //    {
    //        this.pos = pos;
    //        this.type = type;
    //    }
    //}

    //enum BlockType
    //{
    //    CannotPass = 0,
    //    CanPass = 1,
    //    AreadyPass = 2
    //}

    const int X = 9;
    const int Y = 9;
    int[,] _maze;
    MyStack<Vector2Int> _stpes;
    // Start is called before the first frame update
    void Start()
    {
        _maze = InitMaze();
        LogMaze(_maze);

        Run();
    }

    //void InitMazeV2(List<Block> blocks)
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    int[,] InitMaze()
    {
        _stpes = new MyStack<Vector2Int>();
        //int x = 9;
        //int y = 9;

        //起点（1,1）  出口（7,7)
        int[,] maze =
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 1, 1, 1, 0, 0 },
            { 0, 0, 1, 0, 1, 1, 1, 0, 0 },
            { 0, 1, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 1, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };

        //int[][] arr = new int[2][];

        //int[] row1 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row2 = new int[9] { 0, 1, 1, 0, 1, 1, 1, 0, 1 };
        //int[] row3 = new int[9] { 0, 1, 1, 0, 1, 1, 1, 0, 1 };
        //int[] row4 = new int[9] { 0, 1, 1, 1, 1, 0, 0, 0, 0 };
        //int[] row5 = new int[9] { 0, 1, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row6 = new int[9] { 0, 1, 1, 1, 0, 0, 0, 0, 0 };
        //int[] row7 = new int[9] { 0, 0, 0, 1, 1, 1, 1, 0, 0 };
        //int[] row8 = new int[9] { 0, 0, 0, 1, 1, 0, 1, 1, 0 };
        //int[] row9 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //for (int i = 0; i < x; i++)
        //{
        //    maze[0, i] = row1[i];
        //}

        return maze;
    }

    void LogMaze(int[,] maze)
    {
        string log = "";
        int row = 0;
        int lie = 0;
        for (int i = 0; i < maze.Length; i++)
        {
            row = i / X;
            lie = i % X;

            log += maze[row, lie] + " ";
            if(lie == X - 1)
            {
                log += "\n";
            }
        }

        Debug.Log(log);
    }

    void Run()
    {
        Vector2Int start = new Vector2Int(1, 1);
        Vector2Int end = new Vector2Int(7, 7);

        Vector2Int foot = start;
        FootPrint(foot);//第一步记录
        int moveStep = 0;
        bool isFailed = false;
        while(foot != end)
        {
            if(moveStep++ > 1000)
            {
                Debug.LogError("ERROR");
                break;
            }
            foot = MoveNext(foot.x, foot.y);

            if(foot == start)
            {
                Debug.LogError("回到起点 失败");
                isFailed = true;
                break;
            }
        }

        if (!isFailed)
        {
            //成功 打印路径\
            Debug.Log("SUCCESS!!!" + moveStep);
            _stpes.LogStack();
        }
    }


    bool IsNotOutOfBounds(int x, int y)
    {
        return x >= 0 && x < X && y >= 0 && y < Y;
    }

    bool CanPass(int x, int y)
    {
        return _maze[x, y] == 1;
    }

    void FootPrint(Vector2Int pos)
    {
        _maze[pos.x, pos.y] = 2;
        _stpes.Push(pos);
    }

    Vector2Int Back()
    {
        if(_stpes.Count > 1)
        {
            _stpes.Pop();
            return _stpes.Peak();
        }
        else
        {
            return _stpes.Pop();
        }
    }

    Vector2Int MoveNext(int x, int y)
    {
        if (IsNotOutOfBounds(x, y + 1) && CanPass(x, y + 1))
        {
            Vector2Int next = new Vector2Int(x, y + 1);
            FootPrint(next);
            return next;
        }
        //bottom
        else if (IsNotOutOfBounds(x + 1, y) && CanPass(x + 1, y))
        {
            Vector2Int next = new Vector2Int(x + 1, y);
            FootPrint(next);
            return next;
        }
        //left
        else if (IsNotOutOfBounds(x, y - 1) && CanPass(x, y - 1))
        {
            Vector2Int next = new Vector2Int(x, y - 1);
            FootPrint(next);
            return next;
        }
        //top
        else if (IsNotOutOfBounds(x - 1, y) && CanPass(x - 1, y))
        {
            Vector2Int next = new Vector2Int(x - 1, y);
            FootPrint(next);
            return next;
        }
        else
        {
            return Back();
        }
    }
}

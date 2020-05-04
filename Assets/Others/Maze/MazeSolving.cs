using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 迷宫求解
/// </summary>
public class MazeSolving : MonoBehaviour
{
    public class BlockData
    {
        public int x;
        public int y;
        public BlockType type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                changeTypeAction();
            }
        }

        public Action changeTypeAction;

        BlockType _type;

        public BlockData(int x, int y, BlockType type)
        {
            this.x = x;
            this.y = y;
            _type = type;
        }
    }

    public enum BlockType
    {
        CannotPass = 0,
        CanPass = 1,
        AreadyPass = 2,
        Error = 3,
        Current = 4
    }

    const int MAZE_SIZE = 9;

    //BlockData[,] _maze;
    List<BlockData> _blocks = new List<BlockData>();
    static BlockType _paintbrush = BlockType.CannotPass;
    List<MazeBlockCtrl> _blockElements = new List<MazeBlockCtrl>();

    public static BlockType paintbrush => _paintbrush;
    public static bool IsPaint { get; set; }

    Vector2Int _start = Vector2Int.zero;
    Vector2Int _end;

    public void OnClickInitMaze()
    {
        _end = Vector2Int.one * (MAZE_SIZE - 1);
        DestroyBlocks();
        for (int i = 0; i < MAZE_SIZE * MAZE_SIZE; i++)
        {
            int posX = i / MAZE_SIZE;
            int posY = i % MAZE_SIZE;
            BlockData data = new BlockData(posX, posY, BlockType.CanPass);
            _blocks.Add(data);
            _blockElements.Add(MazeBlockCtrl.Show(transform, Vector2.one * 50, new Vector3(posY * 52, -posX * 52, 0), data));
        }
    }

    void DestroyBlocks()
    {
        for (int i = 0; i < _blockElements.Count; i++)
        {
            Destroy(_blockElements[i].gameObject);
        }

        _blockElements.Clear();
        _blocks.Clear();
    }

    MyStack<BlockData> _steps = new MyStack<BlockData>();

    public void Run()
    {
        ResetBlocks();
        StartCoroutine(RunStepByStep());
    }

    private void ResetBlocks()
    {
        for (int i = 0; i < _blocks.Count; i++)
        {
            if(_blocks[i].type == BlockType.CannotPass || _blocks[i].type == BlockType.CanPass)
            {
                continue;
            }

            _blocks[i].type = BlockType.CanPass;
        }
    }

    IEnumerator RunStepByStep()
    {
        BlockData foot = _blocks[0];

        FootPrint(foot);//第一步记录
        int moveStep = 0;
        bool isFailed = false;
        bool isFirstBackToStar = true;//第一次回到起点还不能算结束，需要再次校验
        while (foot.x != _end.x || foot.y != _end.y)
        {
            yield return new WaitForSeconds(0.2f);

            if (moveStep++ > 1000)
            {
                Debug.LogError("ERROR");
                break;
            }
            foot.type = BlockType.AreadyPass;

            foot = MoveNext(foot.x, foot.y);

            //如果当前回到start且上一步也在start，则失败
            if (foot.x == _start.x && foot.y == _start.y)
            {
                if (isFirstBackToStar)
                {
                    isFirstBackToStar = false;
                }
                else
                {
                    Debug.LogError("回到起点 失败");
                    isFailed = true;
                    break;
                }
            }
        }

        if (!isFailed)
        {
            //成功 打印路径\
            Debug.Log("SUCCESS!!!" + moveStep);

            BlockData[] blocks = _steps.ToArr();
            string s = "";
            for (int i = 0; i < blocks.Length; i++)
            {
                s += "[" + blocks[i].x + "," + blocks[i].y + "] ";
            }

            Debug.LogError(s);
        }
    }

    #region 迷宫寻路
    bool IsNotOutOfBounds(int x, int y)
    {
        return x >= 0 && x < MAZE_SIZE && y >= 0 && y < MAZE_SIZE;
    }

    bool CanPass(int x, int y)
    {
        //return _maze[x, y].type == BlockType.CanPass;
        return _blocks[x * MAZE_SIZE + y].type == BlockType.CanPass;
    }

    void FootPrint(BlockData data)
    {
        //_maze[data.x, data.y].type =  BlockType.AreadyPass;
        _blocks[data.x * MAZE_SIZE + data.y].type = BlockType.Current;
        _steps.Push(data);

        //_blockElements[data.x * MAZE_SIZE + data.y].ChangeBlockView();
    }

    BlockData Back()
    {
        if (_steps.Count > 1)
        {
            BlockData error = _steps.Pop();
            error.type = BlockType.Error;
            //_blockElements[error.x * MAZE_SIZE + error.y].ChangeBlockView();
            BlockData cur = _steps.Peak();
            cur.type = BlockType.Current;
            return cur;
        }
        else
        {
            BlockData error = _steps.Pop();
            error.type = BlockType.Error;
            //_blockElements[error.x * MAZE_SIZE + error.y].ChangeBlockView();
            return error;
        }
    }

    BlockData GetBlockDataByXY(int x, int y)
    {
        return _blocks[x * MAZE_SIZE + y];
    }

    BlockData MoveNext(int x, int y)
    {
        if (IsNotOutOfBounds(x, y + 1) && CanPass(x, y + 1))
        {
            BlockData next = GetBlockDataByXY(x, y + 1);
            FootPrint(next);
            return next;
        }
        //bottom
        else if (IsNotOutOfBounds(x + 1, y) && CanPass(x + 1, y))
        {
            BlockData next = GetBlockDataByXY(x + 1, y);
            FootPrint(next);
            return next;
        }
        //left
        else if (IsNotOutOfBounds(x, y - 1) && CanPass(x, y - 1))
        {
            BlockData next = GetBlockDataByXY(x, y - 1);
            FootPrint(next);
            return next;
        }
        //top
        else if (IsNotOutOfBounds(x - 1, y) && CanPass(x - 1, y))
        {
            BlockData next = GetBlockDataByXY(x - 1, y);
            FootPrint(next);
            return next;
        }
        else
        {
            return Back();
        }
    }

    #endregion

    public void OnPaintBrushBlack()
    {
        _paintbrush = BlockType.CannotPass;
    }

    public void OnPaintBrushWhite()
    {
        _paintbrush = BlockType.CanPass;
    }
}

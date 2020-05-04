using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MazeBlockCtrl : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    RawImage block;
    MazeSolving.BlockData _data;

    public MazeSolving.BlockData data => _data;

    int _index = 0;
   

    public static MazeBlockCtrl Show(Transform parent, Vector2 size, Vector3 position, MazeSolving.BlockData data)
    {
        GameObject blockGO = Instantiate(Resources.Load<GameObject>("MazeBlock"));
        blockGO.name = "[" + data.x + "," + data.y + "]";
        blockGO.transform.parent = parent;
        blockGO.GetComponent<RectTransform>().sizeDelta = size;
        blockGO.GetComponent<RectTransform>().localPosition = position;
        MazeBlockCtrl ctrl = blockGO.GetComponent<MazeBlockCtrl>();
        ctrl.Init(data);

        return ctrl;
    }

    public void Init(MazeSolving.BlockData data)
    {
        block = GetComponentInChildren<RawImage>();
        _data = data;
        _data.changeTypeAction = ChangeBlockView;
    }

    public void ChangeBlockView()
    {
        switch (_data.type)
        {
            case MazeSolving.BlockType.CannotPass:
                block.color = Color.black;
                break;
            case MazeSolving.BlockType.CanPass:
                block.color = Color.white;
                break;
            case MazeSolving.BlockType.AreadyPass:
                block.color = Color.blue;
                break;
            case MazeSolving.BlockType.Error:
                block.color = Color.red;
                break;
            case MazeSolving.BlockType.Current:
                block.color = Color.green;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _data.type = (MazeSolving.BlockType)(_index++ % 3);
        //ChangeBlockView();
        //Debug.LogError("click " + _data.x + " " + _data.y);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MazeSolving.IsPaint)
        {
            //Debug.LogError("Enter " + _data.x + " " + _data.y);
            _data.type = MazeSolving.paintbrush;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MazeSolving.IsPaint = true;
        //Debug.LogError("Down " + _data.x + " " + _data.y);

        _data.type = MazeSolving.paintbrush;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MazeSolving.IsPaint = false;
        //Debug.LogError("Up " + _data.x + " " + _data.y);
    }



    //public void OnDrag(PointerEventData eventData)
    //{
    //    Debug.LogError(_data.x+" "+_data.y);
    //}


}

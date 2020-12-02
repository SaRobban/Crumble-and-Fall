﻿//Robban
using UnityEngine;

public class BlockType : MonoBehaviour
{
    public int playerteam = 1;
    public string category = "Red";
    public enum types {Fluffy, Speedy, Heavy}
    public types type;

    public enum states { Idle, Flying}
    public states state = states.Idle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //        BlockManager.updateLinks = true;
        OnHitEnter(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnInsideTrigger(collision);
    }

    protected virtual void OnInsideTrigger(Collider2D collider)
    {
        //Is insideTrigger
    }

    protected virtual void OnHitEnter(Collision2D collision)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //setColorByCategory();
        //BlockManager.AddBlockToList(gameObject);
    }

    public static bool IsFluffy(GameObject checkObject)
    {
        if (checkObject.GetComponent<BlockType>())
        {
            if (checkObject.GetComponent<BlockType>().type == types.Fluffy)
            {
                return true;
            }
        }
        return false;
    }
    public void setCatagoryByNumber(int n)
    {
        if(n == 1)
        {
            category = "Green";
        }else if(n == 2)
        {
            category = "Blue";
        }
        else
        {
            category = "Red";
        }

        setColorByCategory();
    }

    //TODO : REmove Func
    public void setColorByCategory()
    {
        if (category == "Green")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (category == "Blue")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (category == "Yellow")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            category = "Red";
        }
    }

    private void OnDestroy()
    {
        //BlockManager.RemoveBlockFromList(gameObject);
    }
}

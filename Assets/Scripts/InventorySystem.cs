using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private Transform invetory;
    [SerializeField] private GameObject itemButton;

    public List<GameObject> items = new List<GameObject>();

    public void removeItem(int id)
    {
        for(int i = 0; i  < items.Count; i++) 
        {
            if (items[i].GetComponent<item>().itemID == id)
            {
                Debug.Log(items[i].GetComponent<item>().itemID);
                Destroy(items[i]);
                items.RemoveAt(i);
            }
        }
    }

    public void addItem(int id)
    {
        if(items.Count != 6)
        {
           switch (id)
            {
                case 1:
                    GameObject button1 = Instantiate(itemButton);
                    button1.transform.SetParent(invetory);
                    button1.GetComponent<item>().itemID = id;
                    items.Add(button1);
                    break;
                case 2:
                    GameObject button2 = Instantiate(itemButton);
                    button2.transform.SetParent(invetory);
                    button2.GetComponent<item>().itemID = id;
                    items.Add(button2);
                    break;
                case 3:
                    GameObject button3 = Instantiate(itemButton);
                    button3.transform.SetParent(invetory);
                    button3.GetComponent<item>().itemID = id;
                    items.Add(button3);
                    break;
                case 4:
                    GameObject button4 = Instantiate(itemButton);
                    button4.transform.SetParent(invetory);
                    button4.GetComponent<item>().itemID = id;
                    items.Add(button4);
                    break;
                case 5:
                    GameObject button5 = Instantiate(itemButton);
                    button5.transform.SetParent(invetory);
                    button5.GetComponent<item>().itemID = id;
                    items.Add(button5);
                    break;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public List<int> IDlist = new List<int>();

    private void Start()
    {
        IDlist.Clear();
    }
}

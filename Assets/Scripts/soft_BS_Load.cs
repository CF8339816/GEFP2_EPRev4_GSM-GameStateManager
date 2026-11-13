using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;


public class soft_BS_Load
{


    private static soft_BS_Load _Instance = null;

    public static soft_BS_Load Instance
    {
        get
        {
            if (_Instance == null)//create isntance if not present
            {
                _Instance = new soft_BS_Load();

            }

            return _Instance;
        }
    }
    private soft_BS_Load()//performs loading of data
    {
        Debug.Log("created SoftBootstrap Load ");
        //Debug.Log("created SoftBootstrap Load " + gameObject.name);
        //Debug.Log("created SoftBootstrap Load " + gameObject.name);
        //Debug.Log("created SoftBootstrap Load " + gameObject.name);
        //Debug.Log("created SoftBootstrap Load " + gameObject.name);

    }


    public void soft_BS_LoadTest()//performs loading of data
    {
        Debug.Log("created SoftBootstrap Load  Is Working!!!!!!!!!!!");

    }
}


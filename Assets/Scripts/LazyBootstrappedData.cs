using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyBootstrappedData
{
    private static LazyBootstrappedData _Instance = null;

    public static LazyBootstrappedData Instance
    {
        get
        {
            // create the instance if not present
            if (_Instance == null)
                _Instance = new LazyBootstrappedData();

            return _Instance;
        }
    }

    private LazyBootstrappedData()
    {
        Debug.Log("Created LazyBootstrappedData");
        // perform loading of data here
    }

    public void Test()
    {
        Debug.Log("LazyBootstrapper is working!");
    }
}

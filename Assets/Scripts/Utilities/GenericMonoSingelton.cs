using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingelton<T> : MonoBehaviour where T : GenericMonoSingelton<T>
{
    private static T instance; 
    public static T Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else {
            Destroy(this.gameObject);
            Debug.LogError("Trying to create secound instance of " + (T)this);
        }
    }

}

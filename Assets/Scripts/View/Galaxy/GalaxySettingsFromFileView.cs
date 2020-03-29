using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxySettingsFromFileView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {


    }
    public void Exit()
    {
        Destroy(gameObject);
    }
}

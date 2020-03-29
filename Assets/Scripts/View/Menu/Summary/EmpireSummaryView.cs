using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmpireSummaryView : MonoBehaviour
{
    public Image empireImage;
    public Text empireName;
    public Text empireDescription;
    public void OnEnable()
    {
        //empireName.text = StartController.userSettings.selectedEmpire.name;
        //empireDescription.text = StartController.userSettings.selectedEmpire.description;
    }
}

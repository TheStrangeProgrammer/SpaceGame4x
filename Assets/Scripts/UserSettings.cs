using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

[Serializable,XmlRoot("UserSettings")]
public class UserSettings {

    [XmlElement("selectedEmpire")]
    public int selectedEmpire;
    public UserSettings()
    {
        selectedEmpire = 0;
    }
    public static UserSettings LoadUserSettings()
    {
        return XMLUtility.LoadUserXML<UserSettings>(XMLUtility.userSettingsXMLPath);

    }
    public static void saveUserSettings(UserSettings userSettings)
    {
         XMLUtility.SaveUserXML<UserSettings>(XMLUtility.userSettingsXMLPath, userSettings);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
[Serializable]
[XmlRoot("KeyValuePair")]
public class Pair<K,V>
{
    [XmlElement]
    public K key;
    [XmlElement]
    public V value;
    public Pair() { }
    public Pair(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}

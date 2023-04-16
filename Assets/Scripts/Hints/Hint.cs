using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hint")]
public class Hint : ScriptableObject
{
    public string hintName;
    [TextArea]
    public string hintDescription;


}

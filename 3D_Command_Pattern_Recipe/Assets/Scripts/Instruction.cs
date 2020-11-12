using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//System.Serializable allows these to be created from the unity inspector
[System.Serializable]

public class Instruction {
    //have we completed this step?
    public bool stepIsComplete = false;
    //What number step is this?
    public int stepNumber;
    //what is the basic instruction?
    public string instructiontext;
    public TextMeshProUGUI stepDisplay;
}

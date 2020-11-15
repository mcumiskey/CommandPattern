using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCommand : ICommand // TODO: Replace ICommand with Instruction
{

	//I'm replacing this with instructions in the manager 
	private string[] _instructionList = {
		"1) Grab bread", 
		"2) Unscrew Jar", 
		"3) Scoop Peanut Butter", 
		"4) Spread Peanut Butter"};

	private int _instructionCounter = 0;

    public RecipeCommand () {
        Debug.Log("RecipeCommand()");
        
    }

    public void Execute() {
    	Debug.Log("Executing!");
    	if (_instructionCounter != _instructionList.Length) {
    		_instructionCounter = _instructionCounter + 1;
    	}
    	Debug.Log(_instructionList[_instructionCounter]);
    }
    public void Undo()  {
    	Debug.Log("Undoing!");
    	if (_instructionCounter != 0) {
    		_instructionCounter = _instructionCounter - 1;
    	}
    	Debug.Log(_instructionList[_instructionCounter]);
    }
}

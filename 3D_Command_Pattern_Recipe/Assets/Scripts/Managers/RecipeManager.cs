using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class RecipeManager : MonoBehaviour {


    private static RecipeManager _instance;

    public static RecipeManager Instance { get { return _instance; } }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    [Header("Add new Instruction Steps here")]
    [Tooltip("An 'Instruction' notes if the step has been completed, has the step number, and the text to be displayed")]
    public Instruction [] InstructionSteps;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start () {
        for(int i = 0; i < InstructionSteps.Length; i++){
            //assigns the string to the TMP gui 
            InstructionSteps[i].stepDisplay.text = InstructionSteps[i].instructiontext;
        }

    }

    //adds commands to the Command Buffer
    public void AddCommand (ICommand command) {
        _commandBuffer.Add(command);
    }

    // GO FORWARD - move forward one step in the recipe
    public void GoForward() {
    	Debug.Log("Going forward - start");
        StartCoroutine(GoForwardRoutine());
        Debug.Log("Going forward - end");

    }

    // GO FORWARD ROUTINE - executes the command
    IEnumerator GoForwardRoutine() {
        Debug.Log("Running GoForwardRoutine.... ");
        foreach(var command in _commandBuffer){
        	Debug.Log("Executing " + command);
            command.Execute();
            yield return new WaitForSeconds(1.0f);
        }
        Debug.Log("Finished GoForwardRoutine");
    }

    // GO BACKWARD - moves bakcward one step in the recipe
    public void GoBackward () {
    	Debug.Log("Going backward - start");
        StartCoroutine(GoBackwardRoutine());
        Debug.Log("Going backward - end");
    }
    
    // GO BACKWARD ROUTINE - executes the command
    IEnumerator GoBackwardRoutine() {
    	Debug.Log("Running GoBackwardRoutine.... ");
        foreach(var command in Enumerable.Reverse(_commandBuffer)){
        	Debug.Log("Undoing " + command);
            command.Undo();
            yield return new WaitForSeconds(1.0f);
        }     
        Debug.Log("Finished GoBackwardRoutine");   
    }
    
    /*
    public void Done() {
        var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes){
           cube.GetComponent<MeshRenderer>().material.color = Color.white;
           Debug.Log("Done");
        }
    }
    */

    
    public void Reset(){
        _commandBuffer.Clear();
    }
}


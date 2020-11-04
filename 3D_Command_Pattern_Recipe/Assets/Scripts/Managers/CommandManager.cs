using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandManager : MonoBehaviour {
    private static CommandManager _instance;

    public static CommandManager Instance { get { return _instance; } }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    //adds commands to the Command Buffer
    public void AddCommand (ICommand command) {
        _commandBuffer.Add(command);
    }
    //plays back all the commands with a 1-second delay
    public void Play(){
        StartCoroutine(PlayRoutine());

    }

    IEnumerator PlayRoutine() {
        Debug.Log("Running PlayRoutine.... ");

        foreach(var command in _commandBuffer){
            command.Execute();
            yield return new WaitForSeconds(1.0f);
        }

        Debug.Log("Finished PlayRoutine");

    }
    //rewinds the comands back to the initial state 
    public void Rewind () {
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine() {
        foreach(var command in Enumerable.Reverse(_commandBuffer)){
            command.Undo();
            yield return new WaitForSeconds(1.0f);
        }        
    }
    public void Done() {
        var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes){
           cube.GetComponent<MeshRenderer>().material.color = Color.white;
           Debug.Log("Done");
        }
    }

    public void Reset(){
        _commandBuffer.Clear();
    }
}

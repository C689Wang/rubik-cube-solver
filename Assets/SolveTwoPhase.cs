using UnityEngine;
using Kociemba;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class SolveTwoPhase : MonoBehaviour
{
    CubeState cubeState;
    ReadCube readCube;
    private bool doOnce = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        readCube = FindFirstObjectByType<ReadCube>();
        cubeState = FindFirstObjectByType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeState.started && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {
        List<string> solutionList = GetSolvingSteps();

        // Automate the list
        Automate.moveList = solutionList;
    }

    public List<string> GetSolvingSteps()
    {
        readCube.ReadState();

        // get the state of cube as strings
        string moveString = cubeState.GetStateString();

        // solve the cube
        string info = "";
        // first time build the tables
        // string solution = SearchRunTime.solution(moveString, out info, buildTables: true);

        // Every other time
        string solution = Search.solution(moveString, out info);

        // convert the solved moves from a string to a list
        List<string> solutionList = StringToList(solution);

        return solutionList;
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}

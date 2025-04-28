using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StepManager : MonoBehaviour
{
    public Button solveButton;
    public Button nextButton;
    public Button previousButton;
    public TMP_Text stepText;

    private List<string> solvingSteps = new List<string>();
    private int currentStep = 0;

    private SolveTwoPhase solveTwoPhase;
    private Automate automate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        solveButton.onClick.AddListener(OnSolveClicked);
        nextButton.onClick.AddListener(OnNextClicked);
        previousButton.onClick.AddListener(OnPreviousClicked);

        nextButton.interactable = false;
        previousButton.interactable = false;
        solveTwoPhase = FindFirstObjectByType<SolveTwoPhase>();
        automate = FindFirstObjectByType<Automate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CubeState.solving)
        {
            if (nextButton.interactable)
            {
                nextButton.interactable = false;
            }
            if (previousButton.interactable)
            {
                previousButton.interactable = false;
            }
            if (stepText.text.Length > 0)
            {
                stepText.text = "";
            }

        }
    }

    void OnSolveClicked()
    {
        if (!CubeState.solving && !CubeState.autoRotating)
        {
            solvingSteps = solveTwoPhase.GetSolvingSteps();
            if (solvingSteps.Count == 0) return;
            CubeState.solving = true;
            // start at step 0
            currentStep = 0;
            nextButton.interactable = true;
            previousButton.interactable = true;
            UpdateUI();
        }
        
    }

    void OnNextClicked()
    {
        if (currentStep < solvingSteps.Count && !CubeState.autoRotating)
        {
            automate.DoMove(solvingSteps[currentStep]);
            currentStep++;
            UpdateUI();
        }
    }

    void OnPreviousClicked()
    {
        if (currentStep > 0 && !CubeState.autoRotating)
        {
            currentStep--;
            UpdateUI();

            string invertedMove = InvertMove(solvingSteps[currentStep]);
            automate.DoMove(invertedMove);
        }
    }

    void UpdateUI()
    {
        stepText.text = $"Step {currentStep} / {solvingSteps.Count}";
        if (currentStep == 0) 
        {
            previousButton.interactable = false;
        } else if (currentStep == solvingSteps.Count)
        {
            nextButton.interactable = false;
        } else {
            if (!nextButton.interactable) {
                nextButton.interactable = true;
            }
            if (!previousButton.interactable)
            {
                previousButton.interactable = true;
            }
        }
    }

    private string InvertMove(string move)
{
    if (move.EndsWith("2"))
    {
        return move;
    }
    if (move.EndsWith("'"))
    {
        return move.Substring(0, move.Length - 1);
    }
    else
    {
        return move + "'";
    }
}

}

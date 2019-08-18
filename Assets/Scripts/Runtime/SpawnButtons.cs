using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtons : MonoBehaviour
{
    [SerializeField,Range(1,60)] private int buttonAmount = 1;
    [SerializeField, Range(0, 1)] private float throwExceptionChance = 0.2f;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    private bool hasPlacedException = false;

    protected void Awake()
    {
        for (int i = 0; i < buttonAmount; i++)
        {
            float chance = Random.Range(0f, 1f);

            GameObject go = Instantiate(buttonPrefab, gridLayoutGroup.transform);

            Button button = go.GetComponent<Button>();
            Toggle toggle = go.GetComponent<Toggle>();

            if(button != null)
            {
                SetupButton(i, button, chance);
            }
            else if(toggle != null)
            {
                SetupToggle(i, toggle, chance);
            }
        }
    }

    private void SetupButton(int index, Button button, float chance)
    {
        button.gameObject.name = $"Button ({index})";


        if (chance <= throwExceptionChance && !hasPlacedException || buttonAmount - 1 == index && !hasPlacedException)
        {
            button.onClick.AddListener(OnThrowException);
            hasPlacedException = true;

            Debug.Log($"Button {button.gameObject.name} = Exception");
        }
        else
        {
            button.onClick.AddListener(OnButtonClicked);
        }
    }

    private void SetupToggle(int index, Toggle toggle, float chance)
    {
        toggle.gameObject.name = $"Toggle ({index})";

        if (chance <= throwExceptionChance && !hasPlacedException || buttonAmount - 1 == index && !hasPlacedException)
        {
            toggle.onValueChanged.AddListener((x) => { OnThrowException(); });
            hasPlacedException = true;

            Debug.Log($"Toggle {toggle.gameObject.name} = Exception");
        }
        else
        {
            toggle.onValueChanged.AddListener(OnToggleClicked);
        }
    }

    public void OnSingleException(float single)
    {
        OnThrowException();
    }

    public void OnIntException(int i)
    {
        OnThrowException();
    }

    public void OnVector2Exception(Vector2 vector2)
    {
        OnThrowException();
    }

    protected void OnThrowException()
    {
        throw new System.Exception();
    }

    protected void OnButtonClicked()
    {
        Debug.Log("Button Clicked :)");
    }

    protected void OnToggleClicked(bool value)
    {
        Debug.Log("Toggle Clicked: " + value);
    }
}

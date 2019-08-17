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

    protected void Awake()
    {
        bool hasPlacedException = false;

        for (int i = 0; i < buttonAmount; i++)
        {
            float chance = Random.Range(0f, 1f);

            GameObject go = Instantiate(buttonPrefab, gridLayoutGroup.transform);
            Button button = go.GetComponent<Button>();
            go.name = $"Button ({i})";

            if (chance <= throwExceptionChance && !hasPlacedException || buttonAmount - 1 == i && !hasPlacedException)
            {
                button.onClick.AddListener(OnThrowException);
                hasPlacedException = true;

                Debug.Log($"Button {go.name} = Exception");
            }
            else
            {
                button.onClick.AddListener(OnButtonClicked);
            }
        }
    }

    protected void OnThrowException()
    {
        throw new System.Exception();
    }

    protected void OnButtonClicked()
    {
        Debug.Log("Button Clicked :)");
    }
}

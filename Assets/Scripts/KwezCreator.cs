using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KwezCreator : MonoBehaviour
{
    public int ID;

    private const string Key = "NumberArrayCreate";
    private const char Separator = ';';

    public static int[] LoadArray()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string serializedArray = PlayerPrefs.GetString(Key);
            string[] arrayElements = serializedArray.Split(Separator);
            int[] loadedArray = new int[arrayElements.Length];

            for (int i = 0; i < arrayElements.Length; i++)
            {
                if (!string.IsNullOrEmpty(arrayElements[i]))
                {
                    int parsedValue;
                    if (int.TryParse(arrayElements[i], out parsedValue))
                    {
                        loadedArray[i] = parsedValue;
                    }
                    else
                    {
                        Debug.LogWarning("Failed to parse element at index " + i + ": " + arrayElements[i]);
                    }
                }
            }

            return loadedArray;
        }
        else
        {
            return new int[0];
        }
    }

    public void SaveArray(int[] arrayToAdd)
    {
        int[] existingArray = LoadArray();
        int[] newArray = new int[existingArray.Length + arrayToAdd.Length];
        existingArray.CopyTo(newArray, 0);
        arrayToAdd.CopyTo(newArray, existingArray.Length);

        string serializedArray = string.Join(Separator.ToString(), newArray);
        PlayerPrefs.SetString(Key, serializedArray);
    }

    public void AddToCreate()
    {
        SaveArray(new int[] { ID });
    }
    public void AddToCreate(int id)
    {
        SaveArray(new int[] { id });
    }
}

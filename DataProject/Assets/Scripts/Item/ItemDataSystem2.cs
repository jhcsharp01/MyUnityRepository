using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem2 : MonoBehaviour
{


    //ItemData item_Data;

    [Header("=== ��ǲ �ʵ� ===")]
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputField;

    [Header("=== ��ư ===")]
    public Button LoaddataButton;
    public Button SavedataButton;
    public Button DeleteButton;

    [Header("=== ������ ���� ===")]
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public string temp_name;
    public string temp_description;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        nameInputField.onEndEdit.AddListener(NameChanged);
        descriptionInputField.onEndEdit.AddListener(DescriptionChanged);
        LoaddataButton.onClick.AddListener(LoadData);
        SavedataButton.onClick.AddListener(SaveData);
        DeleteButton.onClick.AddListener(DeleteData);
    }

    private void Update()
    {
        LoadCheck();
    }

    void NameChanged(string text) => temp_name = text;

    void DescriptionChanged(string text) => temp_description = text;

    void DeleteData() => PlayerPrefs.DeleteAll();
    void SaveData()
    {
        if (temp_name != "" && temp_description != "")
        {
            PlayerPrefs.SetString("ItemName", temp_name);
            PlayerPrefs.SetString("ItemDescription", temp_description);
        }

        else
        {
            Debug.Log("������ �Է����ּ���");

        }
    }
        void LoadData()
    {
            itemNameText.text = $"������ �̸� : {PlayerPrefs.GetString("ItemName")}";
            itemDescriptionText.text = $"������ ���� : {PlayerPrefs.GetString("ItemDescription")}";
        
   
    }
    void LoadCheck()
    {
        if (PlayerPrefs.HasKey("ItemName") && PlayerPrefs.HasKey("ItemDescription"))
        {
            LoaddataButton.interactable = true;
        }
        else
        {
            LoaddataButton.interactable = false;
        }
    }

}

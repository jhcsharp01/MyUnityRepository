using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem2 : MonoBehaviour
{


    //ItemData item_Data;

    [Header("=== 인풋 필드 ===")]
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputField;

    [Header("=== 버튼 ===")]
    public Button LoaddataButton;
    public Button SavedataButton;
    public Button DeleteButton;

    [Header("=== 아이템 정보 ===")]
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
            Debug.Log("내용을 입력해주세요");

        }
    }
        void LoadData()
    {
            itemNameText.text = $"아이템 이름 : {PlayerPrefs.GetString("ItemName")}";
            itemDescriptionText.text = $"아이템 설명 : {PlayerPrefs.GetString("ItemDescription")}";
        
   
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

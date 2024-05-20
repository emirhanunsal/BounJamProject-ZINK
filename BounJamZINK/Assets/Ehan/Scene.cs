using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public int sceneIndex;

    void Start()
    {
        // Eğer bir Button kullanıyorsanız, Button'a tıklama olayını ekleyin
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }

        // Eğer bir Text kullanıyorsanız, Text'e bir tıklama algılayıcı ekleyin
        // Text'e tıklamayı algılamak için Text'e bir BoxCollider2D eklemeniz gerekebilir
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
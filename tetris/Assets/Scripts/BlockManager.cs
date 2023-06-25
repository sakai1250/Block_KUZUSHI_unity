using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance { get; private set; }

    private int blockCount;

    [SerializeField]
    public TextMeshProUGUI blockCountText; // 残りボール個数を表示
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length; // ブロックの初期個数を取得する
        UpdateBlockCountText();
    }

    public void DecreaseBlockCount()
    {
        blockCount--;
        UpdateBlockCountText();

        if (blockCount <= 0)
            ResetLevel();
    }

    private void UpdateBlockCountText()
    {
        blockCountText.text = "Blocks: " + blockCount.ToString();
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンを再読み込みする
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResultSceneDate : MonoBehaviour
{
    /// <summary>
    /// メンバー変数
    /// </summary>

        [Header("セレクトシーン名"), SerializeField]
        private string selectScene_Name = "none";

        [Header("1つ１つの文字(Clear!)が出現する時間間隔"), SerializeField]
        private float clearFont_AppearTime = 0.2f;

        [Header("文字(PleaseAnyKey)の点滅時間"), SerializeField]
        private float pleaseanykeyFont_FreshTime = 0.4f;
        
        [Header("文字(Clear!)をすべて表示した後にキー操作を有効する時間"), SerializeField]
        private float keyValidTime = 0.8f;

        [Header("文字(Clear!)すべて表示されたと判断する時に必要になる[Clear!]の[!]の透明度"), SerializeField]
        private float claerFont_FinalAlpha = 0.8f;

        // 文字(Clear!)をすべて表示したか    
        private bool IsclearFont_Appear = false;
        
        // キー操作を有効するか
        private bool Iskey = false;
        
    /// <summary>
    /// 取得・設定関数
    /// </summary>

        // セレクトシーン名
        public string SelectScene_Name { get { return selectScene_Name; } private set { selectScene_Name = value; } }
        // 1つ１つの文字(Clear)が出現する時間間隔
        public float ClearFont_AppearTime { get { return clearFont_AppearTime; } private set { clearFont_AppearTime = value; } }
        // 文字([PleaseAnyKey)の点滅時間
        public float PleaseanykeyFont_FreshTime { get { return pleaseanykeyFont_FreshTime; } private set { pleaseanykeyFont_FreshTime = value; } }

        // 文字(Clear!)すべて表示されたと判断する時に必要になる[Clear!]の[!]の透明度"
        public float ClaerFont_FinalAlpha { get { return claerFont_FinalAlpha; } set { claerFont_FinalAlpha = value; } }
        // 文字(Clear!)をすべて表示したか    
        public bool IsClearFont_Appear { get { return IsclearFont_Appear; } set { IsclearFont_Appear = value; } }
        // 文字(Clear!)をすべて表示した後にキー操作を有効する時間
        public float KeyValidTime { get { return keyValidTime; } set { keyValidTime = value; } }
        // キー操作を有効するか
        public bool IsKey { get { return Iskey; } set { Iskey = value; } }
}
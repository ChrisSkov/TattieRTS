using UnityEngine;
using Mirror;
using TMPro;
public class MyNetworkPlayer : NetworkBehaviour
{
    int[] res = new int[5];
    [SerializeField] TMP_Text displayNameText = null;
    [SerializeField] Renderer displayerColorRenderer = null;

    [SyncVar(hook = nameof(HandleDisplayNameUpdated))]
    [SerializeField]
    private string displayName = "Missing Name";

    [SyncVar(hook = nameof(HandleDisplayColorUpdated))]
    [SerializeField]
    private Color myColor = Color.black;

    #region Server

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;


    }

    [Server]
    public void SetDisplayColor(Color newDisplayColor)
    {
        myColor = newDisplayColor;
    }

    [Command]
    private void CmdSetDisplayname(string newDisplayName)
    {

        if (newDisplayName.Length < 2 || newDisplayName.Length > 20) return;
        RpcLogNewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }

    #endregion

    #region Client
    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        displayNameText.text = newName;
    }
    private void HandleDisplayColorUpdated(Color oldColor, Color newColor)
    {
        displayerColorRenderer.material.SetColor("_BaseColor", newColor);
    }

    [ContextMenu("Set My Name")]
    void SetMyName()
    {
        CmdSetDisplayname("m");
    }

    [ClientRpc]
    private void RpcLogNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }
    #endregion


}

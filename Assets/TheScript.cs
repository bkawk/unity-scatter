using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScatterSharp;

public class TheScript : MonoBehaviour {

    public Button m_loginButton;

    // Use this for initialization
    void Start () {
        Button btn1 = m_loginButton.GetComponent<Button>();
        btn1.onClick.AddListener(LoginClicked);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoginClicked() {
        Debug.Log("Login clicked");
        InitScatter();
    }

    public async void InitScatter()
    {
        var network = new ScatterSharp.Api.Network()
        {
            Blockchain = Scatter.Blockchains.EOSIO,
            Host = "api.eossweden.se",
            Port = 443,
            Protocol = "https",
            ChainId = "aca376f206b8fc25a6ed44dbdc66547c36c6c33e3a119ffbeaef943642f0e906"
        };

        var scatter = new Scatter("UnityTestApp", network);

        await scatter.Connect();

        var identity = await scatter.GetIdentity(new ScatterSharp.Api.IdentityRequiredFields()
        {
            Accounts = new List<ScatterSharp.Api.Network>()
            {
              network
            },
            Location = new List<ScatterSharp.Api.LocationFields>(),
            Personal = new List<ScatterSharp.Api.PersonalFields>()
        });

        Debug.Log(identity);

        var eos = scatter.Eos();
    }

}

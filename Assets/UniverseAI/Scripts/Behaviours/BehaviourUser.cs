using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BehaviourUser : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    [SerializeField] public String userToken;
    
    // Start is called before the first frame update
    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUserToken(String token)
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        user.TokenAsync(true).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("TokenAsync was canceled.");
                return;
            }

            if (task.IsFaulted) {
                Debug.LogError("TokenAsync encountered an error: " + task.Exception);
                return;
            }

            string idToken = task.Result;

            // Send token to your backend via HTTPS
            // ...
        });
        userToken = token;
        Debug.Log("User TOoken Updated");
    }
}

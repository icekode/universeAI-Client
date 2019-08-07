using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using Firebase.Auth;

namespace UniverseAI.Scripts.Behaviours
{

    public class BehaviourAuthentication : MonoBehaviour
    {
        Firebase.Auth.FirebaseAuth auth;

        public UIInput inputEmail;
        public UIInput inputPassword;
        public GameObject gameController;
        private bool isAccountCreated = false;
        
        // Start is called before the first frame update
        void Start()
        {
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        }
        

        // Update is called once per frame
        void Update()
        {
            if (isAccountCreated)
            {
                Debug.Log( "Switch Screens");
                AuthSuccessful();
                isAccountCreated = false; //Stop loop
            }
        }


        public void CreateNewUserViaEmail()
        {
            Debug.Log("Creating Account for " + inputEmail.value);
            HandelNewUserViaEmail(inputEmail.value, inputPassword.value);
        }


        private void AuthSuccessful()
        {
            Debug.Log("Auth Successful1");
            gameController.GetComponent<MainGameController>().ButtonGameControlPanel();
          
            
        }

        private void HandelNewUserViaEmail(string email, string password)
        {
            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }

                if (task.IsFaulted)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }
               
                // Firebase user has been created.
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                isAccountCreated = true;

            });

        }
    }
}
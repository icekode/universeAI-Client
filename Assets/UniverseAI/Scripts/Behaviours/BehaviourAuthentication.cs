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
            Debug.Log("BehaviourAuthentication Module Start");
        }
        

        // Update is called once per frame
        void Update()
        {
            if (isAccountCreated)
            {
                Debug.Log("BehaviourAuthentication: Confirmed Account Created");
                AuthSuccessful();
                isAccountCreated = false; //Stop loop
            }
        }


        public void LoginUserViaEmail()
        {
            Debug.Log("BehaviourAuthentication: Starting LogINUserViaEmail");
            HandleUserLogInViaEmail(inputEmail.value, inputPassword.value);
        }

        public void CreateNewUserViaEmail()
        {
            Debug.Log("BehaviourAuthentication: Starting CreateNewUserViaEmail- Creating Account for " + inputEmail.value);
            Debug.Log("Creating Account for " + inputEmail.value);
            HandelNewUserViaEmail(inputEmail.value, inputPassword.value);
        }


        private void AuthSuccessful()
        {
            Debug.Log("Auth Successful1");
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
                Debug.Log("User Token is :" + idToken);

                // Send token to your backend via HTTPS
                // ...
            });
            Debug.Log("User TOoken Updated");
            gameController.GetComponent<MainGameController>().ButtonGameControlPanel();
          
            
        }

    
        private void HandleUserLogInViaEmail(string email, string password)
        {
            auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled");
                    return;
                }

                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }
                
                FirebaseUser currentUser = task.Result;
                Debug.LogFormat("Firebase user logged in: {0} ({1})",
                    currentUser.DisplayName, currentUser.UserId);
                isAccountCreated = true;

            });
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

using UniverseAI.Scripts.General;
using System;
using UnityEngine;
using Firebase.Auth;

//TODO Combined login/create account screens. Now need to create some type of screen to get details for new useer.

namespace UniverseAI.Scripts.Controllers
{
    
    /**
     * Handle Authenication
     */
    public class ControllerAuthentication : MonoBehaviour
    {
        private FirebaseAuth auth;
        private FirebaseUser user;

        [SerializeField] public String userDisplayName;
        [SerializeField] public String userEmail;
        [SerializeField] public String userUid;
        [SerializeField] public String userToken;
        [SerializeField] public ConstantsUAI.AuthState authState;

        public GameObject uidLabel;
        
        private void Start()
        {
            InitializeFirebase();
            CheckUserState();
        }

        public void RefreshToken()
        {
           GetUserToken();
        }

        /**
         * Sign Out of Account
         */
        public void SignOut()
        {
            auth.SignOut();
            CleanUserProfile();
            Debug.Log("Signed out");
        }

        /*
         * Initialize Firebase Authenication
         */
        private void InitializeFirebase() {
            Debug.Log("Setting up Firebase Auth");
            authState = ConstantsUAI.AuthState.Init;
            auth = FirebaseAuth.DefaultInstance;
            auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        }

        private  void CheckUserState()
        {
            Debug.Log("Checking state");
            if (user == null) {
                HandleStateSignedOut();
            } else {
               HandleStateSignedIn();
            }
        }

        private void UpdateUidLabel()
        {
            uidLabel.GetComponent<UILabel>().text = userUid;
        }
        
        // Track state changes of the auth object.
        private void AuthStateChanged(object sender, EventArgs eventArgs) {
           CheckStatus();
        }

        private void OnDestroy() {
            auth.StateChanged -= AuthStateChanged;
            auth = null;
        }

        private void CheckStatus()
        {
            Debug.Log("Checking Status");
            if (auth.CurrentUser != user) {
                bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
                if (!signedIn && user != null) {
                    HandleStateSignedOut();
                }

                if (!signedIn)
                {
                    HandleStateSignedOut();
                }
                user = auth.CurrentUser;
                if (signedIn) {
                    HandleStateSignedIn();
                }
               
            }
        }

        private void HandleStateSignedOut()
        {
            Debug.Log("Signed out ");
            authState = ConstantsUAI.AuthState.LoginState;
            CleanUserProfile();
            UpdateUidLabel();
            
        }

        private void HandleStateSignedIn()
        {
            Debug.Log("Signed in " + user.UserId);
            authState = ConstantsUAI.AuthState.Authorized;
            UpdateUserProfile();
            GetUserToken();
            UpdateUidLabel();
        }

        private void GetUserToken()
        {
            user.TokenAsync(true).ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.LogError("TokenAsync was canceled.");
                    return;
                }

                if (task.IsFaulted) {
                    Debug.LogError("TokenAsync encountered an error: " + task.Exception);
                    return;
                }

                userToken = task.Result;

                // Send token to your backend via HTTPS
                // ...
            });
        }
        
        private void UpdateUserProfile()
        {
            userDisplayName = user.DisplayName;
            userEmail = user.Email;
            userUid = user.UserId;
        }
        private void CleanUserProfile()
        {
            userDisplayName = "";
            userEmail = "";
            userUid = "";
            userToken = "";
        }
    }
}
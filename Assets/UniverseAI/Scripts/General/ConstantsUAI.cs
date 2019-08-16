using System;
using UnityEngine;

namespace UniverseAI.Scripts.General
{
    public static class ConstantsUAI
    {
        public const string FIRESTORE_API_PATH = "https://us-central1-projectuai.cloudfunctions.net/";

        public enum AuthState
        {
            Init,
            Authorized,
            LoginState,
            CreateAccountState,
            NotAuthorized
            
        }
    }
}
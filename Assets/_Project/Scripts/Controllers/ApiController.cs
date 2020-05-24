using UnityEngine;
using Proyecto26;
using System;
using IsmaelNascimentoAssets.Utils;
using System.Collections.Generic;

namespace IsmaelNascimentoAssets.Controllers
{
    public class ApiController : MonoBehaviour
    {
        #region VARIABLES

        public static ApiController Instance;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// 
        /// param 'limit' your MAX is 50
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="response"></param>
        public void Call_NewReleases(string country = "BR", int limit = 4, int offset = 0, Action<string, string> response = null)
        {
            RequestHelper requestHelper = new RequestHelper
            {
                Uri = Constants.ENDPOINT__LIST_NEW_RELEASES,
                Method = "GET",
                Params = new Dictionary<string, string>
                {
                    { "country", country },
                    { "limit", $"{limit}"},
                    { "offset", $"{offset}" }
                },
                Headers = new Dictionary<string, string>
                {
                    {"Authorization", $"Bearer {Constants.OATUH_TOKEN}" }
                },
                EnableDebug = true
            };

            RestClient.Request(requestHelper)
                .Then(res =>
                {
                    response?.Invoke(res.Text, null);
                })
                .Catch(err =>
                {
                    response?.Invoke(null, err.Message);
                });
        }

        #endregion
    }
}
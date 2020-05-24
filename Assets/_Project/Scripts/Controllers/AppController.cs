using IsmaelNascimentoAssets.Models;
using IsmaelNascimentoAssets.UI;
using Newtonsoft.Json;
using UnityEngine;

namespace IsmaelNascimentoAssets.Controllers
{
    public class AppController : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private Transform newReleasesContent;
        [SerializeField] private NewReleaseUI newReleaseUIPrefab;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Start()
        {
            CallNewReleases();
        }

        #endregion

        #region PRIVATE_METHODS

        [ContextMenu("CallNewReleases_Test")]
        private void CallNewReleases()
        {
            ApiController.Instance.Call_NewReleases(country: "BR", limit: 50, response: (jsonResponse, err) =>
            {
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    NewReleasesModel newReleasesModel = JsonConvert.DeserializeObject<NewReleasesModel>(jsonResponse);
                    SetDataScrollView(newReleasesModel);
                }
                else
                {
                    Debug.LogError(err);
                }
            });
        }

        private void SetDataScrollView(NewReleasesModel newReleasesModel)
        {
            newReleasesModel.Albums.Items.ForEach(release =>
            {
                NewReleaseUI newReleaseUI = Instantiate(newReleaseUIPrefab, newReleasesContent);
                newReleaseUI.SetData(release);
            });
        }

        #endregion
    }
}
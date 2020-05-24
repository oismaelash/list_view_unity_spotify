using UnityEngine;
using TMPro;
using IsmaelNascimentoAssets.Models;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;

namespace IsmaelNascimentoAssets.UI
{
    public class NewReleaseUI : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private RawImage albumRawImage;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI artistsText;

        private Item newReleasesModel;

        #endregion

        #region PUBLIC__METHODS

        public void SetData(Item newReleasesModel)
        {
            this.newReleasesModel = newReleasesModel;

            titleText.text = newReleasesModel.Name;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Artist artist in newReleasesModel.Artists)
                stringBuilder.Append($"{artist.Name}, ");

            artistsText.text = stringBuilder.Remove(stringBuilder.Length-2, 1).ToString();

            StartCoroutine(GetAlbumImage_Coroutine());
        }

        #endregion

        #region COROUTINES

        private IEnumerator GetAlbumImage_Coroutine()
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(newReleasesModel.Images[0].Url))
            {
                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log(uwr.error);
                }
                else
                {
                    Debug.Log($"Get done of Image = {newReleasesModel.Name}");
                    var texture = DownloadHandlerTexture.GetContent(uwr);
                    albumRawImage.texture = texture;
                }
            }
        }

        #endregion
    }
}
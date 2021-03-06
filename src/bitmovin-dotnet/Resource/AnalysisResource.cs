using System.Collections.Generic;
using System.Threading.Tasks;
using com.bitmovin.Api.Input;
using com.bitmovin.Api.Rest;
using Task = com.bitmovin.Api.Rest.Task;

namespace com.bitmovin.Api.Resource
{
    public class AnalysisResource
    {
        protected RestClient _restClient;

        protected string _url;

        public AnalysisResource(RestClient client, string url)
        {
            this._restClient = client;
            this._url = url;
        }

#if !NET_40

        public async Task<string> CreateAsync(string inputId, AnalysisInput item)
        {
            var createUrl = string.Format("{0}/{1}/analysis", _url, inputId);
            var ai = await _restClient.PostAsync<AnalysisInput>(createUrl, item);
            return ai.Id;
        }

        public async Task<AnalysisDetail> RetrieveDetailsAsync(string inputId, string analysisId)
        {
            var retrieveURL = string.Format("{0}/{1}/analysis/{2}", _url, inputId, analysisId);
            return await _restClient.GetAsync<AnalysisDetail>(retrieveURL);
        }

        public async Task<Task> RetrieveStatusAsync(string inputId, string analysisId)
        {
            var retrieveURL = string.Format("{0}/{1}/analysis/{2}/status", _url, inputId, analysisId);
            return (await _restClient.GetAsync<AnalysisStatus>(retrieveURL)).Analysis;
        }

        public async Task<List<Message>> RetrieveStreamDetailsAsync(string inputId, string analysisId, string streamId)
        {
            var retrieveURL = string.Format("{0}/{1}/analysis/{2}/{3}", _url, inputId, analysisId, streamId);
            return (await _restClient.GetAsync<StreamDetail>(retrieveURL)).Messages;
        }


        public async Task<List<AnalysisDetail>> RetrieveListAsync(string inputId, int offset, int limit)
        {
            var retrieveUrl = string.Format("{0}/{1}/analysis?offset={1}&limit={2}", _url, inputId, offset, limit);
            return await _restClient.GetListAsync<AnalysisDetail>(retrieveUrl);
        }


        public async Task<List<AnalysisDetail>> RetrieveAllIterativeAsync(string inputId, int offset, int limit)
        {
            var retrieveUrl = string.Format("{0}/{1}/analysis?offset={1}&limit={2}", inputId, _url, offset, limit);
            return await _restClient.GetAllIterativeAsync<AnalysisDetail>(retrieveUrl);
        }

        public async Task<Dictionary<string, object>> RetrieveCustomDataAsync(string inputId, string analysisId)
        {
            var retrieveUrl = string.Format("{0}/{1}/analysis/{2}/customData", _url, inputId, analysisId);
            return await _restClient.GetCustomDataAsync(retrieveUrl);
        }

#endif

        public string Create(string inputId, AnalysisInput item)
        {
            var createUrl = string.Format("{0}/{1}/analysis", _url, inputId);
            var ai = _restClient.Post<AnalysisInput>(createUrl, item);
            return ai.Id;
        }

        public AnalysisDetail RetrieveDetails(string inputId, string analysisId)
        {
            var retrieveURL = string.Format("{0}/{1}/analysis/{2}", _url, inputId, analysisId);
            return _restClient.Get<AnalysisDetail>(retrieveURL);
        }

        public Task RetrieveStatus(string inputId, string analysisId)
        {
            var retrieveURL = string.Format("{0}/{1}/analysis/{2}/status", _url, inputId, analysisId);
            return _restClient.Get<AnalysisStatus>(retrieveURL).Analysis;
        }

        public List<Message> RetrieveStreamDetails(string inputId, string analysisId, string streamId)
        {
            var retrieveURL = string.Format("{0}/{1}/analysis/{2}/{3}", _url, inputId, analysisId, streamId);
            return _restClient.Get<StreamDetail>(retrieveURL).Messages;
        }


        public List<AnalysisDetail> RetrieveList(string inputId, int offset, int limit)
        {
            var retrieveUrl = string.Format("{0}/{1}/analysis?offset={1}&limit={2}", _url, inputId, offset, limit);
            return _restClient.GetList<AnalysisDetail>(retrieveUrl);
        }


        public List<AnalysisDetail> RetrieveAllIterative(string inputId, int offset, int limit)
        {
            var retrieveUrl = string.Format("{0}/{1}/analysis?offset={1}&limit={2}", inputId, _url, offset, limit);
            return _restClient.GetAllIterative<AnalysisDetail>(retrieveUrl);
        }

        public Dictionary<string, object> RetrieveCustomData(string inputId, string analysisId)
        {
            var retrieveUrl = string.Format("{0}/{1}/analysis/{2}/customData", _url, inputId, analysisId);
            return _restClient.GetCustomData(retrieveUrl);
        }
    }
}
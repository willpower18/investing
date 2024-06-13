using Investing.Services.Models;
using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;
using Investing.Shared.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;


namespace Investing.Services.AssetServices
{
    public class BrApiAssetService : IFinancialAssetQueryService
    {
        private const string BaseUrl = "https://brapi.dev/api/quote/";
        private string _apiToken = string.Empty;
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        public BrApiAssetService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = ConstructHttpClient();
        }

        public async Task<AssetDetail> GetAssetDetailsBySymbol(string symbol, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"{symbol}?token=${_apiToken}");
            if(response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    var responseItems = JsonSerializer.Deserialize<List<AssetDetail>>(jsonResponse);
                    if (responseItems != null && responseItems.Any())
                        return responseItems.FirstOrDefault();
                    else
                        return null;
                }
                catch(Exception ex)
                {
                    throw new Exception($"Não foi possível deserializar o retorno do serviço. Erro original: {ex.Message}");
                }
            }
            else
            {
                throw new Exception($"Não foi possível consultar o serviço, Status Code retornado: {response.StatusCode}");
            }
        }

        public async Task<IEnumerable<AssetDetail>> GetAssetsByType(EAssetType assetType, CancellationToken cancellationToken = default)
        {
            string type = GetAssetTypeString(assetType);
            var response = await _httpClient.GetAsync($"list?type={type}&token=${_apiToken}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    var responseItems = JsonSerializer.Deserialize<List<BrStockAssetList>>(jsonResponse);
                    if (responseItems != null && responseItems.Any())
                    {
                        var assets = new List<AssetDetail>();
                        foreach(var item in responseItems)
                        {
                            assets.Add(new AssetDetail()
                            {
                                Symbol = item.Stock,
                                LogoUrl = item.Logo,
                                LongName = item.Name,
                                ShortName = item.Name,
                                RegularMarketPrice = item.Close,
                                RegularMarketTime = DateTime.Now
                            });
                        }

                        return assets;
                    }                        
                    else
                        return new List<AssetDetail>();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Não foi possível deserializar o retorno do serviço. Erro original: {ex.Message}");
                }
            }
            else
            {
                throw new Exception($"Não foi possível consultar o serviço, Status Code retornado: {response.StatusCode}");
            }
        }

        public async Task<IEnumerable<AssetDetail>> GetAssetsDetailsBySymbols(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
        {
            StringBuilder symbol = new StringBuilder();
            int counter = 0;
            foreach(var symbolItem in symbols)
            {
                if(counter == 0)
                    symbol.Append(symbolItem);
                else
                    symbol.Append($",{symbolItem}");

                counter++;
            }

            var response = await _httpClient.GetAsync($"{symbol.ToString()}?token=${_apiToken}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    var responseItems = JsonSerializer.Deserialize<List<AssetDetail>>(jsonResponse);
                    if (responseItems != null && responseItems.Any())
                        return responseItems.ToList();
                    else
                        return new List<AssetDetail>();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Não foi possível deserializar o retorno do serviço. Erro original: {ex.Message}");
                }
            }
            else
            {
                throw new Exception($"Não foi possível consultar o serviço, Status Code retornado: {response.StatusCode}");
            }
        }

        private HttpClient ConstructHttpClient()
        {
            _apiToken = _configuration["AssetQueryServiceToken"];

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)                
            };

            return httpClient;
        }

        private string GetAssetTypeString(EAssetType assetType)
        {
            switch(assetType)
            {
                case EAssetType.Stocks:
                    return "stock";
                case EAssetType.Funds:
                    return "fund";
                case EAssetType.BDRs:
                    return "bdr";
                default:
                    return string.Empty;
            }
        }
    }
}

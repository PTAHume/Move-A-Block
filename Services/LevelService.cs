namespace Move_A_Block.Service;

using Microsoft.Extensions.Configuration;
using Move_A_Block_Shared;
using System.Diagnostics;
using System.Text.Json;

public class LevelService
{
    protected HttpClient _client = null;
    protected JsonSerializerOptions _serializerOptions = null;
    //[Inject]
    protected IConfiguration _configuration = null;
    protected List<Cell> _boardPeaces = null;
    protected Settings _settings = null;
    public LevelService(IConfiguration configuration)
    {
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        _client = new HttpClient();
        _configuration = configuration;
        _settings = _configuration.GetRequiredSection("Settings").Get<Settings>();
    }

    public async Task<List<Cell>> GetBoardAsync(int Level)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync($"{_settings.API_URL}{Level}");
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                _boardPeaces = await JsonSerializer.DeserializeAsync<List<Cell>>(stream, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex);
        }
        //IList<Cell> boardPeaces = await _client.GetFromJsonAsync<Cell[]>($"{settings.API_URL}{Level}");
        return _boardPeaces;
    }
}
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestAPI_Demo_P3.MVVM.Models;
using TestAPI_Demo_P3.Services;

namespace TestAPI_Demo_P3.MVVM.ViewModels;

public partial class SWViewModel: ObservableObject
{
    private readonly APIService _apiService;
    private readonly DataBaseService _databaseService;
    private SWCharacters _selectedCharacter;
    private int _characterId;
    
    public SWCharacters SelectedCharacter
    {
        get => _selectedCharacter;
        set => SetProperty(ref _selectedCharacter, value);
    }

    public int CharacterId
    {
        get => _characterId;
        set
        {
            SetProperty(ref _characterId, value);
            LoadCharacterCommand.NotifyCanExecuteChanged();
        }
    }
    
    public ObservableCollection<SWCharacters> Characters { get; }

    public IAsyncRelayCommand LoadCharacterCommand { get; }
    public IAsyncRelayCommand SaveCharacterCommand { get; }
    public IAsyncRelayCommand DeleteCharacterCommand { get; }
    
    public SWViewModel(APIService apiService, DataBaseService databaseService)
    {
        _apiService = apiService;
        _databaseService = databaseService;
        Characters = new ObservableCollection<SWCharacters>();

        LoadCharacterCommand = new AsyncRelayCommand(LoadCharacterAsync, CanLoadCharacter);
        SaveCharacterCommand = new AsyncRelayCommand(SaveCharacterAsync);
        DeleteCharacterCommand = new AsyncRelayCommand<SWCharacters>(DeleteCharacterAsync);
    }
    
    private async Task LoadCharacterAsync()
    {
        var character = await _apiService.GetSWCharactersAsync(CharacterId);
        if (character != null)
        {
            character.ApiId = CharacterId;
            await _databaseService.SaveSWCharactersAsync(character);
            Characters.Add(character);
        }
    }

    private bool CanLoadCharacter()
    {
        return CharacterId > 0;
    }

    private async Task SaveCharacterAsync()
    {
        if (SelectedCharacter != null)
        {
            await _databaseService.SaveSWCharactersAsync(SelectedCharacter);
        }
    }

    private async Task DeleteCharacterAsync(SWCharacters character)
    {
        await _databaseService.DeleteSWCharactersAsync(character);
        Characters.Remove(character);
    }
}
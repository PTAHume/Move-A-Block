namespace Move_A_Block.Pages;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Move_A_Block.Service;
using Move_A_Block_Shared;
using System.Diagnostics;

public class IndexBase : ComponentBase
{
    protected List<Cell> board = null;
    protected ElementReference OuterDiv;
    [Inject]
    public LevelService _LevelService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {

            IList<Cell> boardPeaces = await _LevelService.GetBoardAsync(0);

            board = Enumerable.Range(0, 98).Select((cell, index) =>
            {
                return new Cell
                {
                    index = index,
                    content = "./assets/images/blank.png"
                };
            }).ToList();

            boardPeaces.ToList().ForEach((result) => board[result.index] = new Cell()
            {
                content = $"./assets/images/{result.content}.png",
                index = result.index,
            });
        }
        catch (Exception ex)
        {
            Debug.Write(ex);
        }
    }

    protected void KeyDown(KeyboardEventArgs e)
    {
        Console.Write(e);
    }
    protected void OnClick()
    {
        Console.Write("");
    }
}
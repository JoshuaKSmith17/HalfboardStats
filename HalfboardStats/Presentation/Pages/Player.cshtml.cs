using HalfboardStats.Application;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace HalfboardStats.Presentation.Pages
{
    public class PlayerModel : PageModel
    {
        public IPlayerFacade Facade { get; set; }
        public IPlayer Player { get; set; }
        public PlayerModel(IPlayerFacade facade)
        {
            Facade = facade;
        }

        public void OnGet([FromRoute] int Id)
        {
            Player = Facade.GetPlayer(Id);
            //RouteData.Values["Id"].ToString();
        }
    }
}
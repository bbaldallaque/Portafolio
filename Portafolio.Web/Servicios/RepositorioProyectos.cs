using Portafolio.Web.Models;

namespace Portafolio.Web.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRepositorioProyectos
	{
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
            new Proyecto

               {
                Titulo = "Amazon",
                Descripcion = " E-commerce realizado en ASP.NET Core",
                Link = "https://amazon.com",
                ImagenUrl = "/image/amazon.png"
              },
            new Proyecto

               {
                Titulo = "New York Times",
                Descripcion = " Pagina de noticias en React",
                Link = "https://nytimes.com",
                ImagenUrl = "/image/nyt.png"
              },
            new Proyecto

               {
                Titulo = "Reddit",
                Descripcion = " Red social para compartir en comunidades",
                Link = "https://reddit.com",
                ImagenUrl = "/image/reddit.png"
              },
            new Proyecto

               {
                Titulo = "Steam",
                Descripcion = " Tienda en linea para comprar videos juegos",
                Link = "https://store.steampowerd.com",
                ImagenUrl = "/image/steam.png"
              },
            };
        }
    }
}

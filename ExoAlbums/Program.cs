using DataSources;

var allAlbums = ListAlbumsData.ListAlbums;

var albumsForDisplay =
    from album in allAlbums
    let affichageAlbum = $"Album n°{album.AlbumId} : {album.Title}"
    orderby album.AlbumId
    select affichageAlbum;

int cpt = 0;
int nbElementsPerPage = 20;

while (cpt < albumsForDisplay.Count())
{
    var currentPageAlbum = albumsForDisplay.Skip(cpt).Take(nbElementsPerPage);
    foreach (var albumDisplayName in currentPageAlbum)
    {
        Console.WriteLine(albumDisplayName);
    }
    cpt = cpt + nbElementsPerPage;
    Console.WriteLine("'Entrée' pour continuer");
    Console.ReadLine();
}
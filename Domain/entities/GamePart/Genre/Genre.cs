<<<<<<< HEAD
﻿using System.Collections.ObjectModel;
namespace Domain.entities.GamePart.Genre;
=======
﻿using Domain.entities.Store.GemGenreDto;
using System.Collections.ObjectModel;
namespace Domain.entities.GamePart.GemGenreDto;
>>>>>>> origin/master

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }

    #region Rels
<<<<<<< HEAD

    public Collection<GemeSelectedGenre> gemeSelectedGenres { get; set; }
=======
  
    public Collection<GameSelectedGenre> gameSelectedGenre { get; set; }
>>>>>>> origin/master

    #endregion


<<<<<<< HEAD


=======
>>>>>>> origin/master
}

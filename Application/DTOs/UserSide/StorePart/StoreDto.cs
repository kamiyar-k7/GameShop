<<<<<<< HEAD
﻿
using Domain.entities.GamePart.Game;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/master

namespace Application.DTOs.UserSide.StorePart;

public class StoreDto
{
<<<<<<< HEAD
    #region Game
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public string Trailer { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<string> Screenshots { get; set; }
    public GameStatus GameStatus { get; set; }  
    #endregion
    public string search {  get; set; }
=======
    public class StoreDto
    {
        #region Game
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public string Trailer { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<string> Screenshots { get; set; }
        #endregion

        #region Rels
        public ICollection<GenreDto> genreDto { get; set; }
        public ICollection<SelectedPlatform> SelectedPlatforms { get; set; }
        #endregion
    }

    public class GenreDto
    {

        public int Id { get; set; }
        public string GenreName { get; set; }
        public string GenreUniqueName { get; set; }

     

    }
    public class SelectedPlatform
    {
        public string PS4 { get; set; }
        public string PS5 { get; set; }
        public string XBOX { get; set; }
        public string PC { get; set; }
    }
>>>>>>> origin/master
}

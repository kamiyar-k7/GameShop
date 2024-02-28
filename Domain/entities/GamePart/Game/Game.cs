﻿using Domain.entities.GamePart.Paltform;
using Domain.entities.Store.Game;
using Domain.entities.Store.GemGenreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.Store.Game
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public int Quantitiy { get; set; }
        public float Rating { get; set; }
        public string Trailer { get; set; }
        
        public string SystemRequirements { get; set; }
        public bool IsDelete { get; set; } = false;
       



        #region Rels
        public ICollection<Screenshot> Screenshots { get; set; }
        public ICollection<GemGenreDto.GameSelectedGenre> gameSelectedGenres { get; set; }
        public ICollection<GameSelectedPlatform> gameSelectedPlatforms { get; set; }
        #endregion


    }
  
}

public class Screenshot
{
    public int Id { get; set; }
    public string AvararUrl { get; set; }
   

    public int GameId { get; set; }
    public Game Game { get; set; } 
}


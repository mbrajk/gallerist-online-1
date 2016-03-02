﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int CurrentNumberOfPlayers { get; set; }
        public int MaxTurnLength { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_PokemonAPI
{
    public class PokemonInfo
    {

        public string name { get; set; }

        public int height { get; set; }

        public double weight { get; set; }

        public Sprite sprites { get; set; }

    }

    public class Sprite
    {
        public string front_default { get; set; }
        public string back_default { get; set; }
    }
}

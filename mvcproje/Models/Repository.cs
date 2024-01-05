using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproje.Models
{
    public class Repository
    {
        public static List<Kadro> Kadros {get;set;} = new List<Kadro>(){
            new Kadro(){
                Id = 1,
                name = "Fernando Muslera",
                position = "kaleci",
                nationality = "Uruguay",
                Image = "https://hlkiurt3.rocketcdn.com/profiles/b13b9abd2c5e41a1a6d69d21e2bb2cce.jpeg"
            },
            new Kadro(){
                Id = 2,
                name = "Davinson Sanchez",
                position = "defans",
                nationality = "Kolombiya",
                Image = "https://hlkiurt3.rocketcdn.com/profiles/8f0e1ac29bcb4a17a2c4c17a652c8fc2.jpeg"
            },
            new Kadro(){
                Id = 3,
                name = "Abdülkerim Bardakci",
                position = "defans",
                nationality = "Türkiye",
                Image = "https://hlkiurt3.rocketcdn.com/profiles/9bc566724a734fee8d3acef1b3cd09b5.jpeg"
            }
        };
        public static Kadro GetKadroById(int id)
        {
            return Kadros.FirstOrDefault(u => u.Id == id);
        }
    }
}
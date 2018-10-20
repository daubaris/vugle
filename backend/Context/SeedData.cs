using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VugleBE.Context.Models;

namespace VugleBE.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VugleContext())
            {
                if (context.Users.Any())
                {
                    return;  
                }

                context.Users.AddRange(
                     new User
                     {
                         Username = "vugle",
                         Password = "tieto"
                     }
                );
               
                context.Suggestions.AddRange(
                    new Suggestion
                    {
                        Id = 1,
                        Title = "Praneðk",
                        
                    },
                    new Suggestion
                    {
                        Id = 2,
                        Title = "Pramogauk",

                    },
                    new Suggestion
                    {
                        Id = 3,
                        Title = "Paþink",

                    },
                    new Suggestion
                    {
                        Id = 4,
                        Title = "Suþinok",

                    },
                    new Suggestion
                    {
                        Id = 5,
                        Title = "Skundas",
                        ParentId = 1,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors Skundas", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 6,
                        Title = "Nuomonë",
                        ParentId = 1,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors Nuomones", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 7,
                        Title = "Peticija",
                        ParentId = 1,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors peticijos", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 8,
                        Title = "Maistas",
                        ParentId = 2,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors maisto", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 9,
                        Title = "Renginiai",
                        ParentId = 2,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors renginiai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 10,
                        Title = "Laisvalaikis",
                        ParentId = 2,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors laisvalikis", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 11,
                        Title = "Istorija",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors istorijos", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 12,
                        Title = "Kultûra",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors kultura", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 13,
                        Title = "Servisai",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors servisai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 14,
                        Title = "Finansai",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors finansai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 15,
                        Title = "Transnportas",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors transportas", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 16,
                        Title = "Parduotuvës",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors parduotuves", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 17,
                        Title = "Restoranai",
                        ParentId = 8,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors restorania", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 18,
                        Title = "Kavinës",
                        ParentId = 8,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors kavines", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 19,
                        Title = "Gërimai",
                        ParentId = 8,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors gerimai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 20,
                        Title = "Sportas",
                        ParentId = 10,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors sportas", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 21,
                        Title = "Ivairûs uþsiëmimai",
                        ParentId = 10,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors uþsiëmimai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 22,
                        Title = "Muziejai",
                        ParentId = 11,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors muziejai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 23,
                        Title = "Architektûra",
                        ParentId = 11,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors architek", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 24,
                        Title = "Senamiestis",
                        ParentId = 11,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors oldtown", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 25,
                        Title = "Renginiai",
                        ParentId = 12,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors Renginiai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 26,
                        Title = "Teatras",
                        ParentId = 12,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors teatras", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 27,
                        Title = "Savivaldybë",
                        ParentId = 13,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors savivaldybe", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 28,
                        Title = "Atviri duomenys",
                        ParentId = 13,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors api", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 29,
                        Title = "Bankai",
                        ParentId = 14,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors bankai", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 30,
                        Title = "Miesto biudþetas",
                        ParentId = 14,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors biudzetas", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 31,
                        Title = "Vieðasis transportas",
                        ParentId = 15,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors viesasis", randomInt = 0.5f } }),
                    },
                    new Suggestion
                    {
                        Id = 32,
                        Title = "Eismas",
                        ParentId = 15,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { text = "kas nors eismas", randomInt = 0.5f } }),
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
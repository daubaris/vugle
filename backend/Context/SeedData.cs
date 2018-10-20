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
        context.SuggestionKeywords.AddRange(
            new SuggestionKeyword
            {
              Id = 1,
              Keyword = "pranesk"
            },
            new SuggestionKeyword
            {
              Id = 2,
              Keyword = "pranesimai"
            },
            new SuggestionKeyword
            {
              Id = 3,
              Keyword = "skundas"
            },
            new SuggestionKeyword
            {
              Id = 4,
              Keyword = "skusti"
            },
            new SuggestionKeyword
            {
              Id = 5,
              Keyword = "pramogauti"
            },
            new SuggestionKeyword
            {
              Id = 6,
              Keyword = "žinios"
            },
            new SuggestionKeyword
            {
              Id = 7,
              Keyword = "sužinoti"
            },
            new SuggestionKeyword
            {
              Id = 8,
              Keyword = "peticija"
            },
            new SuggestionKeyword
            {
              Id = 9,
              Keyword = "pasiulyti"
            },
            new SuggestionKeyword
            {
              Id = 10,
              Keyword = "pasiula"
            },
            new SuggestionKeyword
            {
              Id = 11,
              Keyword = "valgyti"
            },
            new SuggestionKeyword
            {
              Id = 12,
              Keyword = "valgis"
            },
            new SuggestionKeyword
            {
              Id = 13,
              Keyword = "skanu"
            },
            new SuggestionKeyword
            {
              Id = 14,
              Keyword = "veikti"
            },
            new SuggestionKeyword
            {
              Id = 15,
              Keyword = "renginiai"
            },
            new SuggestionKeyword
            {
              Id = 16,
              Keyword = "laisvalaikis"
            },
            new SuggestionKeyword
            {
              Id = 17,
              Keyword = "uzsiemimai"
            },
            new SuggestionKeyword
            {
              Id = 18,
              Keyword = "istorija"
            },
            new SuggestionKeyword
            {
              Id = 19,
              Keyword = "praeitis"
            },
            new SuggestionKeyword
            {
              Id = 20,
              Keyword = "kultura"
            },
            new SuggestionKeyword
            {
              Id = 21,
              Keyword = "servisai"
            },
            new SuggestionKeyword
            {
              Id = 22,
              Keyword = "pinigai"
            },
            new SuggestionKeyword
            {
              Id = 23,
              Keyword = "finansai"
            }
        );
        context.Suggestions.AddRange(
            new Suggestion
            {
              Id = 1,
              Title = "Pranešk",
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 1,
                               SuggestionId = 1
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 2,
                               SuggestionId = 1
                           },
                },
              Responses = JsonConvert.SerializeObject(new List<object>
                {
                            new { title = "Kokios pramogos domina?" },
                            new { title = new List<string>{"Pranešti?", "Kas nutiko?"}, random = 0.5 },
                            new {  title = "title", date = "2018-04-13", description = "text", photo = "123", url = "www.vilnius.lt"}
                })
            },
            new Suggestion
            {
              Id = 2,
              Title = "Pramogauk",
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                            new KeywordSuggestions
                           {
                               KeywordId = 5,
                               SuggestionId = 2
                           },
                },
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Kokios pramogos domina?" } })
            },
            new Suggestion
            {
              Id = 3,
              Title = "Pažink",
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Ką nori pažinti?" } })

              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }

            },
            new Suggestion
            {
              Id = 4,
              Title = "Sužinok",
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 6,
                               SuggestionId = 4
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 7,
                               SuggestionId = 4
                           },
                },
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Ką nori sužinoti?" } })
            },
            new Suggestion
            {
              Id = 5,
              Title = "Skundas",
              ParentId = 1,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors Skundas", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                            new KeywordSuggestions
                            {
                                KeywordId = 4,
                                SuggestionId = 5
                            },
                                new KeywordSuggestions
                            {
                                KeywordId = 3,
                                SuggestionId = 5
                            },
                }
            },
            new Suggestion
            {
              Id = 6,
              Title = "Nuomonė",
              ParentId = 1,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors Nuomones", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 6,
              //        SuggestionId = 6
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 7,
              //        SuggestionId = 6
              //    },
              // }
            },
            new Suggestion
            {
              Id = 7,
              Title = "Peticija",
              ParentId = 1,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors peticijos", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                            new KeywordSuggestions
                            {
                                KeywordId = 8,
                                SuggestionId = 7
                            },
                            new KeywordSuggestions
                            {
                                KeywordId = 9,
                                SuggestionId = 7
                            },
                                new KeywordSuggestions
                            {
                                KeywordId = 10,
                                SuggestionId = 7
                            },
                }
            },
            new Suggestion
            {
              Id = 8,
              Title = "Maistas",
              ParentId = 2,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors maisto", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                            new KeywordSuggestions
                           {
                               KeywordId = 11,
                               SuggestionId = 8
                           },
                           new KeywordSuggestions
                           {
                               KeywordId = 12,
                               SuggestionId = 8
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 13,
                               SuggestionId = 8
                           },
                }
            },
            new Suggestion
            {
              Id = 9,
              Title = "Renginiai",
              ParentId = 2,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors renginiai", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 14,
                               SuggestionId = 9
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 15,
                               SuggestionId = 9
                           },
                }
            },
            new Suggestion
            {
              Id = 10,
              Title = "Laisvalaikis",
              ParentId = 2,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors laisvalikis", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 16,
                               SuggestionId = 10
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 17,
                               SuggestionId = 10
                           },
                }
            },
            new Suggestion
            {
              Id = 11,
              Title = "Istorija",
              ParentId = 3,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors istorijos", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 18,
                               SuggestionId = 11
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 19,
                               SuggestionId = 11
                           },
                }
            },
            new Suggestion
            {
              Id = 12,
              Title = "Kultūra",
              ParentId = 3,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors kultura", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 20,
                               SuggestionId = 12
                           }
                           //     new KeywordSuggestions
                           //    {
                           //        KeywordId = 2,
                           //        SuggestionId = 2
                           //    },
              }
            },
            new Suggestion
            {
              Id = 13,
              Title = "Servisai",
              ParentId = 4,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors servisai", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 21,
                               SuggestionId = 13
                           }
                           //     new KeywordSuggestions
                           //    {
                           //        KeywordId = 2,
                           //        SuggestionId = 2
                           //    },
              }
            },
            new Suggestion
            {
              Id = 14,
              Title = "Finansai",
              ParentId = 4,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors finansai", randomInt = 0.5f } }),
              KeywordSuggestions = new List<KeywordSuggestions>
                {
                           new KeywordSuggestions
                           {
                               KeywordId = 22,
                               SuggestionId = 14
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 23,
                               SuggestionId = 14
                           },
                }
            },
            new Suggestion
            {
              Id = 15,
              Title = "Transportas",
              ParentId = 4,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors transportas", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 16,
              Title = "Parduotuvės",
              ParentId = 4,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors parduotuves", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 17,
              Title = "Restoranai",
              ParentId = 8,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors restorania", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 18,
              Title = "Kavinės",
              ParentId = 8,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors kavines", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 19,
              Title = "Gėrimai",
              ParentId = 8,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors gerimai", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 20,
              Title = "Sportas",
              ParentId = 10,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors sportas", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 21,
              Title = "Ivairūs užsiemimai",
              ParentId = 10,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors užsiėmimai", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 22,
              Title = "Muziejai",
              ParentId = 11,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors muziejai", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 23,
              Title = "Architektūra",
              ParentId = 11,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors architek", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 24,
              Title = "Senamiestis",
              ParentId = 11,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors oldtown", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 25,
              Title = "Renginiai",
              ParentId = 12,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors Renginiai", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 26,
              Title = "Teatras",
              ParentId = 12,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors teatras", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 27,
              Title = "Savivaldybė",
              ParentId = 13,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors savivaldybe", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 28,
              Title = "Atviri duomenys",
              ParentId = 13,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors api", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 29,
              Title = "Bankai",
              ParentId = 14,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors bankai", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 22,
              //        SuggestionId = 29
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 23,
              //        SuggestionId = 29
              //    },
              // }
            },
            new Suggestion
            {
              Id = 30,
              Title = "Miesto biudžetas",
              ParentId = 14,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors biudzetas", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 22,
              //        SuggestionId = 30
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 23,
              //        SuggestionId = 30
              //    },
              // }
            },
            new Suggestion
            {
              Id = 31,
              Title = "Viešasis transportas",
              ParentId = 15,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors viesasis", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            },
            new Suggestion
            {
              Id = 32,
              Title = "Eismas",
              ParentId = 15,
              Responses = JsonConvert.SerializeObject(new List<object> { new { title = "kas nors eismas", randomInt = 0.5f } }),
              // KeywordSuggestions = new List<KeywordSuggestions>
              // {
              //    new KeywordSuggestions
              //    {
              //        KeywordId = 1,
              //        SuggestionId = 2
              //    },
              //     new KeywordSuggestions
              //    {
              //        KeywordId = 2,
              //        SuggestionId = 2
              //    },
              // }
            }

        );
        context.Polls.AddRange(
            new Poll
            {
              Date = DateTime.Now,
              Description = "Tikriname vartotojų numonę šildymo klausimu",
              Title = "Ar įjungti šildymą?",
              Options = new List<Option>{
                new Option
                {
                  Title = "Taip"
                },
                new Option
                {
                  Title = "Ne"
                }
              }
            },
            new Poll
            {
              Date = DateTime.Now,
              Description = "Kiek Jums metų?",
              Title = "Tikriname sistemos naudotojų amžių",
              Options = new List<Option>{
                new Option
                {
                  Title = "0-30"
                },
                new Option
                {
                  Title = "30-50"
                },
                new Option
                {
                  Title = "50-80"
                },
                new Option
                {
                  Title = "80-100"
                }
              }
            }
            );
        context.SaveChanges();
      }
    }
  }
}
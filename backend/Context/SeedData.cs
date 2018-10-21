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
                        Title = "Įdomūs faktai ℹ️",
                        Responses = JsonConvert.SerializeObject(new List<object>
                        {
                            new {   title = "Ar žinai kada buvo pastatytas Gedimino bokštas?", 
                                    description = "Garsusis Gedimimo bokštas pastatytas Lietuvos didžiojo kunigaikščio Vytauto laikais (XV amžiuje)", 
                                    photo = "http://priekavos.lt/wp-content/uploads/2017/01/Vilnius.jpg", 
                                    url = "http://priekavos.lt/15-idomiu-faktu-apie-vilniu/"},
                            new {   title = "Vienas didžiausių Vilniaus potvynių", 
                                    description = "1931 m. Vilnių užliejo potvynis, kuris pridarė daugiausia žalos lyginant su ankstesniais potvyniais. Gyventojai buvo priversti palikti namus, vieni glaudėsi kareivinėse, kiti apsistojo pas giminaičius.", 
                                    photo = "http://www.stasys.igs.lt/wp-content/uploads/2010/03/1267436357_15-660x330.jpg", 
                                    url = "http://www.stasys.igs.lt/potvynis-vilniuje-1931-m/"},
                            new {   title = "Ar žinote kaip atrodė Vilnius seniau?", 
                                    photo = "http://www.autc.lt/Handlers/ImageHandler.ashx?b=true&i=755&fn=9a0a7c53-663f-4777-9133-14ad8c7acab3", 
                                    url = "https://www.facebook.com/VilniusVisualArchive/"}
                        })
                    },
                    new Suggestion
                    {
                        Id = 2,
                        Title = "Ką man veikti? 🎉",
                        Responses = JsonConvert.SerializeObject(new List<object>
                        {
                            new {   title = "Ekskursija \"Po Užupio Respubliką\"", 
                                    photo = "https://www.savaitgalis.lt/wp-content/uploads/cache/images/2018/10/Uzupis_Undinele_700/Uzupis_Undinele_700-3287700341.jpg", 
                                    url = "https://www.savaitgalis.lt/renginys/ekskursija-po-uzupio-respublika/"},
                            new {   title = "Romantinė komedija \"Žaidimas nebaigtas\"", 
                                    photo = "https://renginiai.kasvyksta.lt/uploads/events/59669/big/83c015e4.jpg", 
                                    url = "https://renginiai.kasvyksta.lt/59669/romantine-komedija-zaidimas-nebaigtas/"},
                            new {   title = "Daugiau renginių gali rasti čia", url = "https://www.mzirafos.lt/renginiai-vilniuje-kas-vyksta/"}
                        })
                    },
                    new Suggestion
                    {
                        Id = 3,
                        Title = "Sužinok 📚",
                        KeywordSuggestions = new List<KeywordSuggestions>
                        {
                           new KeywordSuggestions
                           {
                               KeywordId = 6,
                               SuggestionId = 3
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 7,
                               SuggestionId = 3
                           },
                        },
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Ką nori sužinoti?" } })
                    },
                    new Suggestion
                    {
                        Id = 4,
                        Title = "Pramogauk 🤙",
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniuje tikrai rasi ką veikti" } })
                    },
                    new Suggestion
                    {
                        Id = 5,
                        Title = "Pranešk 🙋‍",
                        KeywordSuggestions = new List<KeywordSuggestions>
                        {
                           new KeywordSuggestions
                           {
                               KeywordId = 1,
                               SuggestionId = 5
                           },
                            new KeywordSuggestions
                           {
                               KeywordId = 2,
                               SuggestionId = 5
                           },
                        },
                        Responses = JsonConvert.SerializeObject(new List<object>
                        {
                            new { title = "Kokios pramogos domina?" },
                            new { title = new List<string>{"Ką norite pranešti?", "Kas nutiko?"}, random = 0.5 }
                        })
                    },
                    new Suggestion {
                        Id = 6,
                        Title = "Nežinau ko noriu 🎲",
                        Responses = JsonConvert.SerializeObject(new List<object>
                        {
                            new {   title = new List<string>{"Aš irgi nežinau", "Pabandom paspėlioti?", "Leisk man pagalvoti"}},
                            new {   title = "Kątik atsidarė modernaus meno muziejus!", url = "https://mo.lt/en/", photo = "https://g2.dcdn.lt/images/pix/mo-muziejus-79314947.jpg", random = 0.3f },
                            new {   title = "Ar žinai apie Naujają Vilnią?", url = "http://www.naujojivilnia.lt/", photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Naujoji_Vilnia_panorama.jpg/1200px-Naujoji_Vilnia_panorama.jpg" , random = 0.3f},
                            new {   title = "Gal prasimankštinti ir išbandyti savo jėgas", url = "http://begimokalendorius.lt/", photo = "https://wearefromlatvia.com/wp-content/uploads/2014/10/Danske-Bank-Vilnius-marathon-Kaspars.jpg", random = 0.3f },
                        })
                    },
                    new Suggestion
                    {
                        Id = 7,
                        Title = "Kas yra vugle? 🤖",
                        Responses = JsonConvert.SerializeObject(new List<object>
                        {
                            new {   title = "Tai aš!", photo = "https://static.boredpanda.com/blog/wp-content/uploads/2018/08/snake-hands-1-5b7fef345f80c__700.jpg"},
                            new {   title = "Elektroninis Vilniaus mero padėjėjas" },
                            new {   title = "Mano tikslas yra padėti jums rasti aktualią informaciją apie Vilnių greitai!"}
                        })
                    },
                    new Suggestion
                    {
                        Id = 1000,
                        Title = "Skundas ⁉️",
                        ParentId = 5,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Praneškite nusiskundimą, pateikdami ji čia.", url = "https://tvarkaumiesta.lt/" } }),
                        KeywordSuggestions = new List<KeywordSuggestions>
                        {
                            new KeywordSuggestions
                            {
                                KeywordId = 4,
                                SuggestionId = 1000
                            },
                                new KeywordSuggestions
                            {
                                KeywordId = 3,
                                SuggestionId = 1000
                            },
                        }
                    },
                    new Suggestion
                    {
                        Id = 1001,
                        Title = "Nuomonė ✋",
                        ParentId = 5,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Praneškite savo nuomonę", url = "https://tvarkaumiesta.lt/" } }),
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
                        Id = 1002,
                        Title = "Peticija 📋",
                        ParentId = 5,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Peticijas galite pateikti", url = "https://paslaugos.vilnius.lt/petitions" } }),
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
                        Title = "Maistas 🍽️",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Skanus maistas Vilniuje", url = "https://www.tripadvisor.com/Restaurants-g274951-Vilnius_Vilnius_County.html" } }),
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
                        Title = "Renginiai 🎟️",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Kas vyksta Vilniuje galite sužinoti", url = "https://renginiai.kasvyksta.lt/vilnius" } }),

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
                        Title = "Laisvalaikis 🚴",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilnius pilnas laisvalaikio veiklų" } }),
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
                        Title = "Istorija 🏛️",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Kokia istorija tave domina?" } }),
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
                        Title = "Kultūra 🎭",
                        ParentId = 4,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilnius gausus kultūra" } }),
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
                        Title = "Servisai 🔧",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus paslaugos" } }),
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
                        Title = "Finansai 💸",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Visa informacija susijusi su finansais", url = "https://atviras.vilnius.lt/kategorijos/finansai-ir-turtas" } }),
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
                        Title = "Transportas 🚗",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus transporto informacija vienoje vietoje", url = "https://www.trafi.com/lt/vilnius" } }),
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
                        Title = "Parduotuvės 🛍️",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Puikus metas apsipirkti", url = "http://www.vilnius-tourism.lt/ka-veikti/apsipirkimas/prekybos-ir-pramogu-centrai/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Lietuviški restoranai", url = "http://www.vilnius-tourism.lt/ka-veikti/lietuviska-virtuve/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniuje yra kur pasėdėti su puodeliu kavos", url = "http://www.ivilnius.lt/kur-pavalgyti/kavines/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniuje tikrai yra kur atsigerti ;)", url = "http://www.vilnius-tourism.lt/ka-veikti/klubai-ir-barai/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Sporto vietos Vilniuje", url = "http://www.ivilnius.lt/apie-vilniu/vilnius/sportas/" } }),
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
                        Title = "Ivairūs užsėmimai",
                        ParentId = 10,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Veikla vilniuje", url = "http://www.vilnius-tourism.lt/ka-pamatyti/vilnius-jums/jaunimui/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus muziejų sąrašas", url = "http://www.madeinvilnius.com/lt/kultura/vilniaus-muziejai-sarasas/i/    " } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus architektūrinių statinių sąrašas", 
                                                                                         url = "http://www.ivilnius.lt/apie-vilniu/architektura/"
                                                                                        } 
                                                                                }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus senamiestis", url = "http://www.lithuania.travel/lt/objektai/vilniaus-senamiestis/452" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Renginių sąrašas Vilniuje" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniuje dominanti tetrą visada surasi" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Informacija apie savivaldybę", url = "https://vilnius.lt/lt/savivaldybe/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { 
                            new { title = "Atviri duomenys yra pasiekiami čia", url = "https://github.com/vilnius" },
                            new { title = "Prisidėti prie Vilniaus tobulinimo", url = "http://codeforvilnius.lt/" } 
 
                            }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Bankų sąrašas Vilniuje", url = "https://www.bankai.lt/adresai" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Informacija apie Vilniaus biudžetą", url = "https://vilnius.lt/lt/biudzeto-suvestine/" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Viešasis transportas Vilniuje" } }),
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
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Eismo informacija Vilniuje", url = "https://www.waze.com/livemap" } }),
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
                        Id = 33,
                        Title = "Vaikų darželiai 👪",
                        ParentId = 3,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Informacija apie vaikų darželius Vilniuje" } }),
                    },
                    new Suggestion
                    {
                        Id = 34,
                        Title = "Vaikų darželių žemėlapis",
                        ParentId = 33,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus vaikų darželių žemėlapis", url = "https://maps.vilnius.lt/darzeliai" } }),
                    },
                    new Suggestion
                    {
                        Id = 35,
                        Title = "Laisvos vietos",
                        ParentId = 33,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Laisvos vietos vaikų darželiuose", url = "https://vilnius.lt/lt/savivaldybe/svietimas-kultura-ir-sportas/svietimas/registracija-i-vilniaus-miesto-savivaldybes-darzelius-ir-priesmokyklinio-ugdymo-grupes/laisvos-vietos-darzeliuose/" } }),
                    },
                    new Suggestion
                    {
                        Id = 36,
                        Title = "Darželių informacinė sistema",
                        ParentId = 33,
                        Responses = JsonConvert.SerializeObject(new List<object> { new { title = "Vilniaus vaikų darželių informacinė sistema", url = "https://svietimas.vilnius.lt/" } }),
                    },
                    new Suggestion
                    {
                        Id = 37,
                        Title = "Vugle kūrėjų komanda ⌨️",
                        ParentId = 7,
                        Responses = JsonConvert.SerializeObject(new List<object>
                        {
                            new {title = "Paulius Daubaris"},
                            new {title = "Augustinas Grikis"},
                            new {title = "Domantas Lekvaičius"},
                            new {title = "Deividas Maciejauskas"},
                            new {title = "Benas Zabita"},
                            new {title = "Mantas Žilaitis" },
                            new {title = "Vytautas Žilinas"}
                        })
                    }
                );
                context.Polls.AddRange(
                    new Poll
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        Description = "Tikriname vartotojų nuomonę šildymo klausimu",
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
                        Id = 2,
                        Date = DateTime.Now,
                        Description = "Tikriname sistemos naudotojų amžių",
                        Title = "Kiek Jums metų?",
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
                context.PollResponses.AddRange(
                    new PollResponse
                    {
                        PollId = 1,
                        Response = "Taip"
                    },
                    new PollResponse
                    {
                        PollId = 1,
                        Response = "Taip"
                    },
                    new PollResponse
                    {
                        PollId = 1,
                        Response = "Ne"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
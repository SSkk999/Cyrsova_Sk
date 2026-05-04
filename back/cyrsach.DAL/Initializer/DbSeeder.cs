using cyrsach.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace cyrsach.DAL.Initializer
{
    public static class DbSeeder
    {
        public static void Seed(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (db.Tests.Any()) return;

            var game = new TestEntity
            {
                Title = "Ігри",
                Description = "Знання ігрової індустрії",
                Time = "5 хв",
                AuthorId = "a8b8467c-d7e4-4394-8ac0-a45ab0fc5ed9",
                Questions = new List<QuestionEntity>
            {
                new QuestionEntity
                {
                    Text = "Яка гра про Дикий Захід?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "GTA V", IsCorrect = false },
                        new AnswerEntity { Text = "Red Dead Redemption 2", IsCorrect = true },
                        new AnswerEntity { Text = "Cyberpunk 2077", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "У якій грі є режим Battle Royale?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "Minecraft", IsCorrect = false },
                        new AnswerEntity { Text = "Fortnite", IsCorrect = true },
                        new AnswerEntity { Text = "The Sims", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Яка гра про блоки та виживання?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "Terraria", IsCorrect = false },
                        new AnswerEntity { Text = "Minecraft", IsCorrect = true },
                        new AnswerEntity { Text = "Rust", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "У якій грі головний герой — Кратос?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "God of War", IsCorrect = true },
                        new AnswerEntity { Text = "Assassin’s Creed", IsCorrect = false },
                        new AnswerEntity { Text = "Dark Souls", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Яка гра про зомбі?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "The Last of Us", IsCorrect = true },
                        new AnswerEntity { Text = "FIFA", IsCorrect = false },
                        new AnswerEntity { Text = "Need for Speed", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Де є Маріо?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "Sonic", IsCorrect = false },
                        new AnswerEntity { Text = "Mario Kart", IsCorrect = true },
                        new AnswerEntity { Text = "Crash Bandicoot", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Гра про пограбування банків?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "Payday 2", IsCorrect = true },
                        new AnswerEntity { Text = "CS:GO", IsCorrect = false },
                        new AnswerEntity { Text = "Valorant", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Де є режим Zombie?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "Call of Duty", IsCorrect = true },
                        new AnswerEntity { Text = "Dota 2", IsCorrect = false },
                        new AnswerEntity { Text = "League of Legends", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Футбольний симулятор?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "NBA 2K", IsCorrect = false },
                        new AnswerEntity { Text = "FIFA", IsCorrect = true },
                        new AnswerEntity { Text = "eFootball", IsCorrect = false }
                    }
                },
                new QuestionEntity
                {
                    Text = "Карта Dust2 є в?",
                    Answers = new List<AnswerEntity>
                    {
                        new AnswerEntity { Text = "Valorant", IsCorrect = false },
                        new AnswerEntity { Text = "Counter-Strike", IsCorrect = true },
                        new AnswerEntity { Text = "Overwatch", IsCorrect = false }
                    }
                }
            }
            };

            db.Tests.Add(game);
            db.SaveChanges();

            var tests = new List<TestEntity>
        {
            new TestEntity
            {
                Title = "Автомобілі",
                Description = "Знання авто та брендів",
                Time = "3 хв",
                AuthorId = "a8b8467c-d7e4-4394-8ac0-a45ab0fc5ed9",
                Questions = new List<QuestionEntity>
                {
                    new QuestionEntity
                    {
                        Text = "Яка країна BMW?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Франція", IsCorrect = false },
                            new AnswerEntity { Text = "Німеччина", IsCorrect = true },
                            new AnswerEntity { Text = "Італія", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Що означає ABS?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Антиблокувальна система гальм", IsCorrect = true },
                            new AnswerEntity { Text = "Автоматична система безпеки", IsCorrect = false },
                            new AnswerEntity { Text = "Активний баланс швидкості", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Який тип двигуна у електромобіля?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Бензиновий", IsCorrect = false },
                            new AnswerEntity { Text = "Дизельний", IsCorrect = false },
                            new AnswerEntity { Text = "Електричний", IsCorrect = true }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Що відповідає за поворот?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Кермо", IsCorrect = true },
                            new AnswerEntity { Text = "Педаль газу", IsCorrect = false },
                            new AnswerEntity { Text = "Радіатор", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Що вимірює спідометр?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Швидкість", IsCorrect = true },
                            new AnswerEntity { Text = "Пальне", IsCorrect = false },
                            new AnswerEntity { Text = "Температуру", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Пальне дизеля?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Бензин", IsCorrect = false },
                            new AnswerEntity { Text = "Газ", IsCorrect = false },
                            new AnswerEntity { Text = "Дизель", IsCorrect = true }
                        }
                    },
                    new  QuestionEntity
                    {
                        Text = "Що запускає двигун?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Акумулятор", IsCorrect = true },
                            new AnswerEntity { Text = "Колеса", IsCorrect = false },
                            new AnswerEntity { Text = "Глушник", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Автоматична коробка передач?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Механіка", IsCorrect = false },
                            new AnswerEntity { Text = "Автомат", IsCorrect = true },
                            new AnswerEntity { Text = "Робот", IsCorrect = false }
                        }
                    }
                }
            },

            new TestEntity
            {
                Title = "Dota 2",
                Description = "Вгадай героя або здібність",
                Time = "6 хв",
                AuthorId = "a8b8467c-d7e4-4394-8ac0-a45ab0fc5ed9",
                Questions = new List<QuestionEntity>
                {
                    new QuestionEntity
                    {
                        Text = "Скільки гравців у команді?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "3", IsCorrect = false },
                            new AnswerEntity { Text = "5", IsCorrect = true },
                            new AnswerEntity { Text = "6", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Головна будівля?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Throne", IsCorrect = true },
                            new AnswerEntity { Text = "Base", IsCorrect = false },
                            new AnswerEntity { Text = "Core", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Хто має Black Hole?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Invoker", IsCorrect = false },
                            new AnswerEntity { Text = "Enigma", IsCorrect = true },
                            new AnswerEntity { Text = "Shadow Fiend", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Хто викликає ведмедя?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Lycan", IsCorrect = false },
                            new AnswerEntity { Text = "Lone Druid", IsCorrect = true },
                            new AnswerEntity { Text = "Beastmaster", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Що дає Aegis?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Невидимість", IsCorrect = false },
                            new AnswerEntity { Text = "Додаткове життя", IsCorrect = true },
                            new AnswerEntity { Text = "Урон", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Хук?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Pudge", IsCorrect = true },
                            new AnswerEntity { Text = "Axe", IsCorrect = false },
                            new AnswerEntity { Text = "Slark", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Roshan це?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Герой", IsCorrect = false },
                            new AnswerEntity { Text = "Бос", IsCorrect = true },
                            new AnswerEntity { Text = "Предмет", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Chronosphere?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Faceless Void", IsCorrect = true },
                            new AnswerEntity { Text = "Juggernaut", IsCorrect = false },
                            new AnswerEntity { Text = "PA", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Лінії на карті?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "2", IsCorrect = false },
                            new AnswerEntity { Text = "3", IsCorrect = true },
                            new AnswerEntity { Text = "4", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Міни?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Techies", IsCorrect = true },
                            new AnswerEntity { Text = "Tinker", IsCorrect = false },
                            new AnswerEntity { Text = "Sniper", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Blink Dagger?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Телепорт", IsCorrect = true },
                            new AnswerEntity { Text = "Щит", IsCorrect = false },
                            new AnswerEntity { Text = "Хіл", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Requiem of Souls?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Shadow Fiend", IsCorrect = true },
                            new AnswerEntity { Text = "Invoker", IsCorrect = false },
                            new AnswerEntity { Text = "Lina", IsCorrect = false }
                        }
                    }
                }
            },


            new TestEntity
            {
                Title = "CS-GO",
                Description = "Впізнай карту або зброю",
                Time = "4 хв",
                AuthorId = "a8b8467c-d7e4-4394-8ac0-a45ab0fc5ed9",
                Questions = new List<QuestionEntity>
                {
                    new QuestionEntity
                    {
                        Text = "Скільки гравців?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "4", IsCorrect = false },
                            new AnswerEntity { Text = "5", IsCorrect = true },
                            new AnswerEntity { Text = "6", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Хто ставить бомбу?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Terrorists", IsCorrect = true },
                            new AnswerEntity { Text = "CT", IsCorrect = false },
                            new AnswerEntity { Text = "Both", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Найвідоміша карта?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Dust2", IsCorrect = true },
                            new AnswerEntity { Text = "Mirage", IsCorrect = false },
                            new AnswerEntity { Text = "Inferno", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "AWP це?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Снайперка", IsCorrect = true },
                            new AnswerEntity { Text = "Пістолет", IsCorrect = false },
                            new AnswerEntity { Text = "Дробовик", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Скільки раундів?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "13", IsCorrect = false },
                            new AnswerEntity { Text = "15", IsCorrect = false },
                            new AnswerEntity { Text = "16", IsCorrect = true }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Defuse kit?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Швидкий дефьюз", IsCorrect = true },
                            new AnswerEntity { Text = "Броня", IsCorrect = false },
                            new AnswerEntity { Text = "Біг", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Гроші в грі?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "$", IsCorrect = true },
                            new AnswerEntity { Text = "Coins", IsCorrect = false },
                            new AnswerEntity { Text = "Credits", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Eco round?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Без закупки", IsCorrect = true },
                            new AnswerEntity { Text = "Штурм", IsCorrect = false },
                            new AnswerEntity { Text = "Розмін", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Основний режим?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Defuse", IsCorrect = true },
                            new AnswerEntity { Text = "Deathmatch", IsCorrect = false },
                            new AnswerEntity { Text = "BR", IsCorrect = false }
                        }
                    }
                }
            }

        };
            db.Tests.AddRange(tests);
            db.SaveChanges();

        }
    }
}

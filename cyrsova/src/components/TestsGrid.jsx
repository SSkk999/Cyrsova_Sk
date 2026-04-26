import { Link } from "react-router-dom";
import "./TestsGrid.css";

const tests = [
  {
    id: 1,
    title: "Ігри",
    key: "game",
    description: "Знання ігрової індустрії",
    time: "5 хв",
    questions: 10,
    path: "/tests/game",
  },
  {
    id: 2,
    title: "Автомобілі",
    key: "cars",
    description: "Знання авто та брендів",
    time: "3 хв",
    questions: 8,
    path: "/tests/car",
  },
  {
    id: 3,
    title: "Dota 2",
    key: "dota",
    description: "Вгадай героя або здібність",
    time: "6 хв",
    questions: 12,
    path: "/tests/dota",
  },
  {
    id: 4,
    title: "CS-GO",
    key:"cs",
    description: "Впізнай карту або зброю",
    time: "4 хв",
    questions: 9,
    path: "/tests/cs",
  },
];
export const questionsMap = 
{
  game:[
    {
    id: 1,
    question: "Яка гра про Дикий Захід?",
    options: ["GTA V", "Red Dead Redemption 2", "Cyberpunk 2077"],
    correct: 1,
  },
  {
    id: 2,
    question: "У якій грі є режим Battle Royale?",
    options: ["Minecraft", "Fortnite", "The Sims"],
    correct: 1,
  },
  {
    id: 3,
    question: "Яка гра про блоки та виживання?",
    options: ["Terraria", "Minecraft", "Rust"],
    correct: 1,
  },
  {
    id: 4,
    question: "У якій грі головний герой — Кратос?",
    options: ["God of War", "Assassin’s Creed", "Dark Souls"],
    correct: 0,
  },
  {
    id: 5,
    question: "Яка гра відбувається в постапокаліптичному світі з зомбі?",
    options: ["The Last of Us", "FIFA", "Need for Speed"],
    correct: 0,
  },
  {
    id: 6,
    question: "У якій грі є персонаж Маріо?",
    options: ["Sonic", "Mario Kart", "Crash Bandicoot"],
    correct: 1,
  },
  {
    id: 7,
    question: "Яка гра про злодіїв, які грабують банки?",
    options: ["Payday 2", "CS:GO", "Valorant"],
    correct: 0,
  },
  {
    id: 8,
    question: "У якій грі є режим 'Zombie'?",
    options: ["Call of Duty", "Dota 2", "League of Legends"],
    correct: 0,
  },
  {
    id: 9,
    question: "Яка гра є футбольним симулятором?",
    options: ["NBA 2K", "FIFA", "eFootball"],
    correct: 1,
  },
  {
    id: 10,
    question: "У якій грі є карта 'Dust2'?",
    options: ["Valorant", "Counter-Strike", "Overwatch"],
    correct: 1,
  },
  ],
cars:[
{
      id: 1,
      question: "Яка країна є батьківщиною бренду BMW?",
      options: ["Франція", "Німеччина", "Італія"],
      correct: 1,
    },
    {
      id: 2,
      question: "Що означає абревіатура ABS в автомобілі?",
      options: [
        "Антиблокувальна система гальм",
        "Автоматична система безпеки",
        "Активний баланс швидкості",
      ],
      correct: 0,
    },
    {
      id: 3,
      question: "Який тип двигуна використовує електромобіль?",
      options: ["Бензиновий", "Дизельний", "Електричний"],
      correct: 2,
    },
    {
      id: 4,
      question: "Яка деталь відповідає за поворот автомобіля?",
      options: ["Кермо", "Педаль газу", "Радіатор"],
      correct: 0,
    },
    {
      id: 5,
      question: "Що вимірює спідометр?",
      options: ["Швидкість", "Обʼєм пального", "Температуру двигуна"],
      correct: 0,
    },
    {
      id: 6,
      question: "Який тип пального використовують дизельні авто?",
      options: ["Бензин", "Газ", "Дизель"],
      correct: 2,
    },
    {
      id: 7,
      question: "Що відповідає за запуск двигуна?",
      options: ["Акумулятор", "Колеса", "Глушник"],
      correct: 0,
    },
    {
      id: 8,
      question: "Яка коробка передач не потребує ручного перемикання?",
      options: ["Механічна", "Автоматична", "Роботизована"],
      correct: 1,
    },
],
dota:[
    {
    id: 1,
    question: "Скільки гравців у одній команді в Dota 2?",
    options: ["3", "5", "6"],
    correct: 1,
  },
  {
    id: 2,
    question: "Як називається головна будівля, яку потрібно знищити?",
    options: ["Throne", "Base", "Core"],
    correct: 0,
  },
  {
    id: 3,
    question: "Який герой має ультимейт 'Black Hole'?",
    options: ["Invoker", "Enigma", "Shadow Fiend"],
    correct: 1,
  },
  {
    id: 4,
    question: "Який герой може викликати ведмедя?",
    options: ["Lycan", "Lone Druid", "Beastmaster"],
    correct: 1,
  },
  {
    id: 5,
    question: "Що дає Aegis of the Immortal?",
    options: [
      "Невидимість",
      "Додаткове життя",
      "Збільшення урону",
    ],
    correct: 1,
  },
  {
    id: 6,
    question: "Який герой має здібність 'Hook'?",
    options: ["Pudge", "Axe", "Slark"],
    correct: 0,
  },
  {
    id: 7,
    question: "Що таке Roshan?",
    options: ["Герой", "Бос на карті", "Предмет"],
    correct: 1,
  },
  {
    id: 8,
    question: "Який герой має ультимейт 'Chronosphere'?",
    options: ["Faceless Void", "Juggernaut", "Phantom Assassin"],
    correct: 0,
  },
  {
    id: 9,
    question: "Скільки ліній (lines) є на карті?",
    options: ["2", "3", "4"],
    correct: 1,
  },
  {
    id: 10,
    question: "Який герой може ставити міни?",
    options: ["Techies", "Tinker", "Sniper"],
    correct: 0,
  },
  {
    id: 11,
    question: "Що робить предмет Blink Dagger?",
    options: [
      "Телепортує на коротку відстань",
      "Дає щит",
      "Лікує героя",
    ],
    correct: 0,
  },
  {
    id: 12,
    question: "Який герой має здібність 'Requiem of Souls'?",
    options: ["Shadow Fiend", "Invoker", "Lina"],
    correct: 0,
  },
],
cs:[
  {
    id: 1,
    question: "Скільки гравців у команді в CS:GO / CS2?",
    options: ["4", "5", "6"],
    correct: 1,
  },
  {
    id: 2,
    question: "Яка команда ставить бомбу?",
    options: ["Terrorists", "Counter-Terrorists", "Обе"],
    correct: 0,
  },
  {
    id: 3,
    question: "Як називається найвідоміша карта в CS?",
    options: ["Dust2", "Mirage", "Inferno"],
    correct: 0,
  },
  {
    id: 4,
    question: "Що означає 'AWP'?",
    options: ["Снайперська гвинтівка", "Пістолет", "Дробовик"],
    correct: 0,
  },
  {
    id: 5,
    question: "Скільки раундів потрібно для перемоги в звичайному матчі?",
    options: ["13", "15", "16"],
    correct: 2,
  },
  {
    id: 6,
    question: "Що дає дефьюз-кит?",
    options: [
      "Швидше розмінування бомби",
      "Більше броні",
      "Швидший біг",
    ],
    correct: 0,
  },
  {
    id: 7,
    question: "Яка валюта використовується в грі для покупки зброї?",
    options: ["Coins", "Credits", "Money ($)"],
    correct: 2,
  },
  {
    id: 8,
    question: "Що означає 'eco round'?",
    options: [
      "Розмін бомби",
      "Раунд без покупки зброї",
      "Швидка атака",
    ],
    correct: 1,
  },
  {
    id: 9,
    question: "Який режим є основним у CS?",
    options: ["Deathmatch", "Defuse", "Battle Royale"],
    correct: 1,
  },
]
}

export default function TestsGrid() {
  return (
    <div className="tests-page">
      <h1 >Обери тест</h1>

      <div className="grid_test_grid">
        {tests.map((test) => (
          <div key={test.id} className="card_test_grid">
            <h2>{test.title}</h2>
            <p>{test.description}</p>
            <div className="info">
                ⏱ {test.time} • {test.questions} питань
            </div>
            <Link to="/tests/car" state={{ questions: questionsMap[test.key] }} className="button_test_grid">
              Почати
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}
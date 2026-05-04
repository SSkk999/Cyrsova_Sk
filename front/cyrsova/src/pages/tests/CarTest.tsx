import { useState, useEffect } from "react";
import "./style.css";
import { useParams, Link } from "react-router-dom";
import { useUser } from "../../context/UserContext";

export default function TestTemplate() {
  const { id } = useParams();
  const { addCrystals } = useUser();

  const [questions, setQuestions] = useState([]);
  const [current, setCurrent] = useState(0);
  const [score, setScore] = useState(0);
  const [finished, setFinished] = useState(false);

  useEffect(() => {
    const loadQuestions = async () => {
      try {
        const res = await fetch(
          `https://localhost:7166/api/question/by-test?testId=${id}`
        );
        const data = await res.json();

        if (data.isSuccess) {
          setQuestions(data.payload);
        }
      } catch (err) {
        console.error(err);
      }
    };

    loadQuestions();
  }, [id]);

  const handleAnswer = (answerIndex) => {
    const question = questions[current];
    const answer = question.answers[answerIndex];

    let newScore = score;

    if (answer.isCorrect) {
      newScore = score + 1;
      setScore(newScore);
    }

    const next = current + 1;

    if (next < questions.length) {
      setCurrent(next);
    } else {
      addCrystals(newScore);
      setFinished(true);
    }
  };

  const restart = () => {
    setCurrent(0);
    setScore(0);
    setFinished(false);
  };

  if (!questions.length) {
    return (
      <div className="page">
        <h2>Немає даних тесту 😢</h2>
        <Link to="/tests">
          <button className="button">Назад</button>
        </Link>
      </div>
    );
  }

  return (
    <div className="page">
      {!finished ? (
        <div className="card">
          <h2>{questions[current].text}</h2>

          {questions[current].answers.map((a, i) => (
            <button
              key={i}
              onClick={() => handleAnswer(i)}
              className="button"
            >
              {a.text}
            </button>
          ))}

          <p>
            Питання: {current + 1} / {questions.length}
          </p>
        </div>
      ) : (
        <div>
          <h2>Результат</h2>
          <p>
            Правильних відповідей: {score} / {questions.length}
          </p>

          <button onClick={restart} className="button">
            Пройти ще раз
          </button>

          <Link to="/tests">
            <button className="button">В головне меню</button>
          </Link>
        </div>
      )}
    </div>
  );
}
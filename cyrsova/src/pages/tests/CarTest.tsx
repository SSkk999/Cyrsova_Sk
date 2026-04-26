import { useState } from "react";
import "./style.css";
import { useParams } from "react-router-dom";
import { Link, useLocation } from "react-router-dom";
import { questionsMap } from "../../components/TestsGrid";
export default function TestTemplate() {
  const location = useLocation();
const { id } = useParams();
const questions =
  location.state?.questions ||
  questionsMap[id as keyof typeof questionsMap] ||
  [];

  const [current, setCurrent] = useState(0);
  const [score, setScore] = useState(0);
  const [finished, setFinished] = useState(false);


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

  const handleAnswer = (index: number) => {
    if (index === questions[current].correct) {
      setScore((prev) => prev + 1);
    }

    if (current + 1 < questions.length) {
      setCurrent((prev) => prev + 1);
    } else {
      setFinished(true);
    }
  };

  const restart = () => {
    setCurrent(0);
    setScore(0);
    setFinished(false);
  };

  return (
    <div className="page">
      {!finished ? (
        <div className="card">
          <h2>{questions[current].question}</h2>

          {questions[current].options.map((opt: string, i: number) => (
            <button
              key={i}
              onClick={() => handleAnswer(i)}
              className="button"
            >
              {opt}
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
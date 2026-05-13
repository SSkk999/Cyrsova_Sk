import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./TestsGrid.css";

export default function TestsGrid() {
  const [tests, setTests] = useState([]);

  useEffect(() => {
    const loadTests = async () => {
      try {
        const res = await fetch("https://localhost:7166/api/test");
        const data = await res.json();

        if (data.isSuccess) {
          setTests(data.payload);
        }
      } catch (err) {
        console.error("Помилка API:", err);
      }
    };

    loadTests();
  }, []);

  return (
    
    <div className="tests-page">
      <h1>Обери тест</h1>
      {tests.length === 0 ? (
        <p className="no-tests">Немає тестів 😢</p>
      ) : (
      <div className="grid_test_grid">
        {tests.map((test) => (
          <div key={test.id} className="card_test_grid">
            <h2>{test.title}</h2>
            <p>{test.description}</p>

            <div className="info">
              ⏱ {test.time} • {test.questionCount || 0} питань
            </div>

            <Link
              to={`/tests/tests/${test.id}`}
              state={{ test }}
              className="button_test_grid"
            >
              Почати
            </Link>
          </div>
        ))}
      </div>
      )}
    </div>
  );
}
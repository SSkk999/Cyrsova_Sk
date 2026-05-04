import { useEffect, useState } from "react";
import "./MyTestPage.css";
import { Link } from "react-router-dom";
import { HEADER_ROUTES } from "../constants";
import { toast } from "react-toastify";
export default function MyTestPage() {
  const [tests, setTests] = useState([]);
  const [loading, setLoading] = useState(true);

const storedUser = JSON.parse(localStorage.getItem("user"));
const userId = storedUser?.user?.id;

  useEffect(() => {
    if (!userId) return;

    const fetchTests = async () => {
      try {
        const res = await fetch(
          `https://localhost:7166/api/test/id-user?userId=${userId}`
        );
        const data = await res.json();

        if (data.isSuccess) {
          setTests(data.payload);
        }
      } catch (err) {
        console.error("Помилка:", err);
      } finally {
        setLoading(false);
      }
    };

    fetchTests();
  }, [userId]);

const handleDelete = async (id) => {
  try {
    const res = await fetch(
      `https://localhost:7166/api/test/id?id=${id}`,
      {
        method: "DELETE",
        headers: {
          accept: "*/*",
        },
      }
    );

    const data = await res.json();

    if (data.isSuccess) {
      toast.success("Тест видалено 🗑");


      setTests((prev) => prev.filter((t) => t.id !== id));
    } else {
      toast.error("Не вдалося видалити");
    }
  } catch (err) {
    console.error(err);
    toast.error("Помилка сервера");
  }
};

  if (loading) return <p>Загрузка...</p>;

  return (
    <div className="my-tests">
      <h1>Мої тести</h1>

      {tests.length === 0 ? (
        <div>
        <p>У тебе ще нема тестів 😢</p>
    <Link to={HEADER_ROUTES.AddTest}>
    <div className="test-card add-card" >
    <div className="plus">+</div>
    <p>Створити тест</p>
    </div>

    </Link>
        </div>
      ) : (
        <div className="tests-grid">
          {tests.map((test) => (
            <div className="test-card" key={test.id}>
              <h3>{test.title}</h3>
              <p>{test.description}</p>

              <div className="test-info">
                <span>⏱ {test.time}</span>
                <span>❓ {test.questionCount}</span>
              </div>
<div>
              <Link to={`/tests/rename/${test.id}`}>
              <button className="start-btn">
                Редагувати
              </button>
              </Link>
              
                <button
    className="delete-btn"
    onClick={() => handleDelete(test.id)}
  >
    Видалити
  </button>
  </div>
            </div>
            
          ))}
          
    <Link to={HEADER_ROUTES.AddTest}>
    <div className="test-card add-card" >
    <div className="plus">+</div>
    <p>Створити тест</p>
    </div>

    </Link>
            </div>
      )}
    </div>
  );
}
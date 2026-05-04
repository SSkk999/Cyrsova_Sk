import { useEffect, useState } from "react";
import "./MyTestPage.css";
import { toast } from "react-toastify";

export default function AdminPanel() {
  const [tests, setTests] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchAllTests = async () => {
      try {
        const res = await fetch("https://localhost:7166/api/test", {
          headers: {
            accept: "*/*",
          },
        });

        const data = await res.json();

        if (data.isSuccess) {
          setTests(data.payload);
        }
      } catch (err) {
        console.error(err);
        toast.error("Помилка завантаження");
      } finally {
        setLoading(false);
      }
    };

    fetchAllTests();
  }, []);

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
      <h1>Admin Panel — Всі тести</h1>

      {tests.length === 0 ? (
        <p>Немає тестів 😢</p>
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

                <button
                  className="delete-btn"
                  onClick={() => handleDelete(test.id)}
                >
                  Видалити
                </button>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
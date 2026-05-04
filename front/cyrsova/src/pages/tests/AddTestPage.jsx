import { useState } from "react";
import "./AddTestPage.css";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { HEADER_ROUTES } from "../../constants";

export default function AddTestPage() {
  const storedUser = JSON.parse(localStorage.getItem("user"));
  const authorId = storedUser?.user?.id;
  const navigate = useNavigate();

  const createEmptyQuestion = () => ({
    text: "",
    answers: [
      { text: "", isCorrect: false },
      { text: "", isCorrect: false },
    ],
  });

  const [test, setTest] = useState({
    title: "",
    description: "",
    time: "",
    questions: [
      createEmptyQuestion(),
      createEmptyQuestion(),
      createEmptyQuestion(),
      createEmptyQuestion(),
    ],
  });

  const handleAddQuestion = () => {
    setTest((prev) => ({
      ...prev,
      questions: [...prev.questions, createEmptyQuestion()],
    }));
  };

  const handleRemoveQuestion = (index) => {
    setTest((prev) => {
      if (prev.questions.length <= 4) {
        toast.error("Мінімум 4 питання");
        return prev;
      }

      return {
        ...prev,
        questions: prev.questions.filter((_, i) => i !== index),
      };
    });
  };

  const addAnswer = (qIndex) => {
    setTest((prev) => {
      const copy = structuredClone(prev);

      if (copy.questions[qIndex].answers.length >= 5) {
        toast.error("Максимум 5 відповідей");
        return prev;
      }

      copy.questions[qIndex].answers.push({
        text: "",
        isCorrect: false,
      });

      return copy;
    });
  };

  const removeAnswer = (qIndex, aIndex) => {
    setTest((prev) => {
      const copy = structuredClone(prev);

      if (copy.questions[qIndex].answers.length <= 2) {
        toast.error("Мінімум 2 відповіді");
        return prev;
      }

      copy.questions[qIndex].answers.splice(aIndex, 1);

      return copy;
    });
  };

  const validateTest = () => {
    if (!test.title.trim()) return toast.error("Введи назву"), false;
    if (!test.description.trim()) return toast.error("Введи опис"), false;
    if (!test.time.trim()) return toast.error("Введи час"), false;

    for (let i = 0; i < test.questions.length; i++) {
      const q = test.questions[i];

      if (!q.text.trim()) {
        toast.error(`Питання ${i + 1} пусте`);
        return false;
      }

      let correct = 0;

      for (let j = 0; j < q.answers.length; j++) {
        const a = q.answers[j];

        if (!a.text.trim()) {
          toast.error(`Відповідь ${j + 1} у питанні ${i + 1} пуста`);
          return false;
        }

        if (a.isCorrect) correct++;
      }

      if (correct !== 1) {
        toast.error(`У питанні ${i + 1} має бути 1 правильна відповідь`);
        return false;
      }
    }

    return true;
  };

  const handleSubmit = async () => {
    if (!validateTest()) return;

    try {
      const testRes = await fetch("https://localhost:7166/api/test", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          title: test.title,
          description: test.description,
          authorId,
          questionCount: test.questions.length.toString(),
          time: test.time,
        }),
      });

      const testData = await testRes.json();
      const testId = testData.payload;

      for (const q of test.questions) {
        const qRes = await fetch("https://localhost:7166/api/question", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            text: q.text,
            testId,
          }),
        });

        const qData = await qRes.json();
        const questionId = qData.payload;

        for (const a of q.answers) {
          await fetch("https://localhost:7166/api/answer", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
              text: a.text,
              isCorrect: a.isCorrect,
              questionid: questionId,
            }),
          });
        }
      }

      toast.success("Тест створено успішно");
      navigate(HEADER_ROUTES.MyTests);
    } catch {
      toast.error("Помилка");
    }
  };

  return (
    <div className="create-test">
      <h1>Створити тест</h1>

      <input
        placeholder="Назва"
        value={test.title}
        onChange={(e) =>
          setTest((p) => ({ ...p, title: e.target.value }))
        }
      />

      <input
        placeholder="Опис"
        value={test.description}
        onChange={(e) =>
          setTest((p) => ({ ...p, description: e.target.value }))
        }
      />

      <input
        placeholder="Час"
        value={test.time}
        onChange={(e) =>
          setTest((p) => ({ ...p, time: e.target.value }))
        }
      />

      {test.questions.map((q, qIndex) => (
        <div key={qIndex} className="question-block">
          <div className="question-header">
            <h3>Питання {qIndex + 1}</h3>

            <button onClick={() => handleRemoveQuestion(qIndex)}>
              ❌
            </button>
          </div>

          <input
            placeholder="Питання"
            value={q.text}
            onChange={(e) => {
              const copy = structuredClone(test);
              copy.questions[qIndex].text = e.target.value;
              setTest(copy);
            }}
          />

          {q.answers.map((a, aIndex) => (
            <div key={aIndex} className="answer">
              <input
                placeholder="Відповідь"
                value={a.text}
                onChange={(e) => {
                  const copy = structuredClone(test);
                  copy.questions[qIndex].answers[aIndex].text =
                    e.target.value;
                  setTest(copy);
                }}
              />

              <input
                type="radio"
                name={`correct-${qIndex}`}
                checked={a.isCorrect}
                onChange={() => {
                  const copy = structuredClone(test);

                  copy.questions[qIndex].answers =
                    copy.questions[qIndex].answers.map((ans, i) => ({
                      ...ans,
                      isCorrect: i === aIndex,
                    }));

                  setTest(copy);
                }}
              />

              правильна

              <button onClick={() => removeAnswer(qIndex, aIndex)}>
                ❌
              </button>
            </div>
          ))}

          <button onClick={() => addAnswer(qIndex)}>
            + Відповідь
          </button>
        </div>
      ))}

      <button onClick={handleAddQuestion}>+ Питання</button>

      <button className="submit-btn" onClick={handleSubmit}>
        Створити тест
      </button>
    </div>
  );
}
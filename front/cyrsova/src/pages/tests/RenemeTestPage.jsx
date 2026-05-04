import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useParams } from "react-router-dom";

export default function EditTestPage() {
  const { id } = useParams();
  const [test, setTest] = useState(null);


const syncQuestionCount = async (questionsLength) => {
  await api(
    "https://localhost:7166/api/test/Reneme-QuestionCount",
    "PUT",
    {
      id: test.id,
      newText: questionsLength.toString(),
    }
  );
};

  const api = async (url, method = "PUT", body) => {
    const res = await fetch(url, {
      method,
      headers: {
        "Content-Type": "application/json",
      },
      body: body ? JSON.stringify(body) : undefined,
    });

    const text = await res.text();
    if (!res.ok) throw new Error(text);
    return text ? JSON.parse(text) : null;
  };

  const load = async () => {
    try {
      const res = await fetch(
        `https://localhost:7166/api/test/id?id=${id}`
      );
      const data = await res.json();

      if (!data.isSuccess) {
        toast.error("Помилка завантаження");
        return;
      }

      setTest({
        ...data.payload,
        questions: data.payload.questions.map((q) => ({
          ...q,
          answers: q.answers.map((a) => ({
            ...a,
            originalIsCorrect: a.isCorrect,
          })),
        })),
      });
    } catch {
      toast.error("Помилка сервера");
    }
  };

  useEffect(() => {
    load();
  }, [id]);

  if (!test) return <h2>Завантаження...</h2>;

  const updateQuestion = (qIndex, value) => {
    setTest((prev) => ({
      ...prev,
      questions: prev.questions.map((q, i) =>
        i === qIndex ? { ...q, text: value } : q
      ),
    }));
  };

  const updateAnswer = (qIndex, aIndex, value) => {
    setTest((prev) => ({
      ...prev,
      questions: prev.questions.map((q, i) =>
        i === qIndex
          ? {
              ...q,
              answers: q.answers.map((a, j) =>
                j === aIndex ? { ...a, text: value } : a
              ),
            }
          : q
      ),
    }));
  };

  const setCorrect = (qIndex, aIndex) => {
    setTest((prev) => ({
      ...prev,
      questions: prev.questions.map((q, i) =>
        i === qIndex
          ? {
              ...q,
              answers: q.answers.map((a, j) => ({
                ...a,
                isCorrect: j === aIndex,
              })),
            }
          : q
      ),
    }));
  };

 const addQuestion = async () => {
  if (test.questions.length >= 15) {
    toast.error("Максимум 15 питань");
    return;
  }

  try {
    const qRes = await api(
      "https://localhost:7166/api/question",
      "POST",
      {
        text: "Нове питання",
        testId: test.id,
      }
    );

    const questionId = qRes.payload;

    const a1 = await api(
      "https://localhost:7166/api/answer",
      "POST",
      {
        text: "",
        isCorrect: false,
        questionid: questionId,
      }
    );

    const a2 = await api(
      "https://localhost:7166/api/answer",
      "POST",
      {
        text: "",
        isCorrect: false,
        questionid: questionId,
      }
    );

    const newQuestion = {
      id: questionId,
      text: "Нове питання",
      answers: [
        {
          id: a1.payload,
          text: "",
          isCorrect: false,
          originalIsCorrect: false,
        },
        {
          id: a2.payload,
          text: "",
          isCorrect: false,
          originalIsCorrect: false,
        },
      ],
    };

    setTest((prev) => ({
      ...prev,
      questions: [...prev.questions, newQuestion],
    }));

    await syncQuestionCount(test.questions.length + 1);
  } catch {
    toast.error("Помилка створення");
  }
};

const deleteQuestion = async (qIndex, qId) => {
  if (test.questions.length <= 4) {
    toast.error("Мінімум 4 питання");
    return;
  }

  try {
    await api(
      `https://localhost:7166/api/question/${qId}`,
      "DELETE"
    );
    await syncQuestionCount(test.questions.length + 1);
    setTest((prev) => ({
      ...prev,
      questions: prev.questions.filter((q) => q.id !== qId),
    }));
  } catch {
    toast.error("Помилка видалення");
  }
};

 const addAnswer = async (qIndex, qId) => {
  const q = test.questions[qIndex];

  if (q.answers.length >= 5) {
    toast.error("Максимум 5 відповідей");
    return;
  }

  try {
    const res = await api(
      "https://localhost:7166/api/answer",
      "POST",
      {
        text: "",
        isCorrect: false,
        questionId: qId,
      }
    );

    const id = res.payload; 

    const newAnswer = {
      id,
      text: "",
      isCorrect: false,
      originalIsCorrect: false,
    };

    setTest((prev) => ({
      ...prev,
      questions: prev.questions.map((q, i) =>
        i === qIndex
          ? {
              ...q,
              answers: [...q.answers, newAnswer],
            }
          : q
      ),
    }));
  } catch (err) {
    console.error(err);
    toast.error("Помилка створення відповіді");
  }
};

  const deleteAnswer = async (qIndex, aIndex, aId) => {
    const q = test.questions[qIndex];

    if (q.answers.length <= 2) {
      toast.error("Мінімум 2 відповіді");
      return;
    }

    try {
      await api(
        `https://localhost:7166/api/answer/${aId}`,
        "DELETE"
      );

      setTest((prev) => ({
        ...prev,
        questions: prev.questions.map((q, i) =>
          i === qIndex
            ? {
                ...q,
                answers: q.answers.filter((_, j) => j !== aIndex),
              }
            : q
        ),
      }));
    } catch {
      toast.error("Помилка видалення");
    }
  };
const validateBeforeSave = () => {
  for (let i = 0; i < test.questions.length; i++) {
    const q = test.questions[i];

    if (!q.text || !q.text.trim()) {
      toast.error(`Питання ${i + 1} пусте`);
      return false;
    }

    if (!q.answers || q.answers.length < 2) {
      toast.error(`Питання ${i + 1} має мати мінімум 2 відповіді`);
      return false;
    }

    let hasCorrect = false;

    for (let j = 0; j < q.answers.length; j++) {
      const a = q.answers[j];

      if (!a.text || !a.text.trim()) {
        toast.error(`Відповідь ${j + 1} у питанні ${i + 1} пуста`);
        return false;
      }

      if (a.isCorrect) hasCorrect = true;
    }

    if (!hasCorrect) {
      toast.error(`У питанні ${i + 1} не вибрана правильна відповідь`);
      return false;
    }
  }

  return true;
};
 const handleSave = async () => {
  if (!validateBeforeSave()) return;

  try {
    for (const q of test.questions) {
      await api(
        "https://localhost:7166/api/question/reneme-text",
        "PUT",
        { id: q.id, newText: q.text }
      );

      for (const a of q.answers) {
        await api(
          "https://localhost:7166/api/answer/reneme-text",
          "PUT",
          { id: a.id, newText: a.text }
        );

        if (a.isCorrect !== a.originalIsCorrect) {
          await api(
            "https://localhost:7166/api/answer/Reneme-IsCorrect",
            "PUT",
            { id: a.id }
          );
        }
      }
    }

    toast.success("Збережено");
  } catch {
    toast.error("Помилка збереження");
  }
};

  return (
    <div className="create-test">
      <h1>Редагування тесту</h1>

      <input
        value={test.title}
        onChange={(e) =>
          setTest((prev) => ({ ...prev, title: e.target.value }))
        }
      />

      <input
        value={test.description}
        onChange={(e) =>
          setTest((prev) => ({
            ...prev,
            description: e.target.value,
          }))
        }
      />

      <input
        value={test.time}
        onChange={(e) =>
          setTest((prev) => ({ ...prev, time: e.target.value }))
        }
      />

      {test.questions.map((q, qIndex) => (
        <div key={q.id} className="question-block">
          <div className="question-header">
            <h3>Питання {qIndex + 1}</h3>

            <button onClick={() => deleteQuestion(qIndex, q.id)}>
              ❌
            </button>
          </div>

          <input
            value={q.text}
            onChange={(e) =>
              updateQuestion(qIndex, e.target.value)
            }
          />

          {q.answers.map((a, aIndex) => (
            <div key={a.id} className="answer">
              <input
                value={a.text}
                onChange={(e) =>
                  updateAnswer(qIndex, aIndex, e.target.value)
                }
              />

              <input
                type="radio"
                name={`correct-${qIndex}`}
                checked={a.isCorrect}
                onChange={() => setCorrect(qIndex, aIndex)}
              />

              правильна

              <button
                onClick={() =>
                  deleteAnswer(qIndex, aIndex, a.id)
                }
              >
                ❌
              </button>
            </div>
          ))}

          <button onClick={() => addAnswer(qIndex, q.id)}>
            + Відповідь
          </button>
        </div>
      ))}

      <button onClick={addQuestion}>+ Питання</button>

      <button className="submit-btn" onClick={handleSave}>
        Зберегти
      </button>
    </div>
  );
}
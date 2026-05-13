import "./Login.css";
import { Link, useNavigate } from "react-router-dom";
import { useState } from "react";
import { toast } from "react-toastify";
import { useUser } from "../../context/UserContext";
export default function RegisterPage() {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const { setUser, fetchCrystals } = useUser();
  const navigate = useNavigate();

  const handleRegister = async () => {
    try {
      const response = await fetch("https://localhost:7166/api/auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({
          name,
          password,
          role: 0
        })
      });

      const data = await response.json();

      if (!data.isSuccess) {
        toast.error(data.message || "Помилка реєстрації ❌");
        return;
      }

      toast.success("Реєстрація успішна ✅");

      localStorage.setItem("user", JSON.stringify(data.payload));
      setUser(data.payload);
      await fetchCrystals(data.payload.user.id);
      navigate("/tests");

    } catch (error) {
      toast.error("Сервер не відповідає 🚫");
    }
  };

  return (
    <div className="login-container">
      <div className="login-card">
        <h1>Реєстрація</h1>
        <p className="subtitle">Створіть свій акаунт.</p>

        <label>Логін</label>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />

        <label>Пароль</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />

        <button className="login-btn" onClick={handleRegister}>
          Зареєструватись
        </button>

        <p className="register-text">
          Вже маєте акаунт?
          <Link to="/login">
            <span>Увійти</span>
          </Link>
        </p>
      </div>
    </div>
  );
}
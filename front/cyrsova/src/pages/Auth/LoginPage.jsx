import "./Login.css";
import { Link, useNavigate } from "react-router-dom";
import { useState } from "react";
import { toast } from "react-toastify";
import { useUser } from "../../context/UserContext";

export default function LoginPage() {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
const { setUser,crystals , fetchCrystals } = useUser();
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await fetch("https://localhost:7166/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ name, password })
      });

      const data = await response.json();

      if (!data.isSuccess) {
        toast.error(data.message || "Помилка логіну ❌");
        return;
      }


      localStorage.setItem("user", JSON.stringify(data.payload));
      setUser(data.payload);
      await fetchCrystals(data.payload.user.id);
      toast.success("Успішний вхід ✅");

      setTimeout(() => {
        navigate("/tests");
      }, 10);

    } catch (error) {
      toast.error("Сервер не відповідає 🚫");
    }
  };

  return (
    <div className="login-container">
      <div className="login-card">
        <h1>Увійти</h1>

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

        <button className="login-btn" onClick={handleLogin}>
          Увійти
        </button>

        <p className="register-text">
          Ще немає акаунта?
          <Link to="/register">
            <span>Зареєструйтесь</span>
          </Link>
        </p>
      </div>
    </div>
  );
}
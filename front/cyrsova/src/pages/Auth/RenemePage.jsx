import { time } from "framer-motion";
import { s } from "framer-motion/client";
import { useState } from "react";
import { toast } from "react-toastify";

export default function RenamePage() {
  const [username, setUsername] = useState("");

  const [currentPassword, setCurrentPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const handleNameSubmit = async (e) => {
    e.preventDefault();

    if (!username.trim()) {
      toast.error("Введи ім'я");
      return;
    }

    try {
      const storedUser = JSON.parse(localStorage.getItem("user"));

      const response = await fetch("https://localhost:7166/api/auth/rename", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          newName: username,
          oldName: storedUser?.user.name,
        }),
      });

      const data = await response.json();

      if (!data.isSuccess) {
        toast.error(data.message);
        return;
      }

      localStorage.setItem("user", JSON.stringify(data.payload));

      toast.success("Ім'я змінено");
      setUsername("");
      setTimeout(() => {
    window.location.reload();
    }, 2550);

    } catch {
      toast.error("Помилка сервера");
    }
  };

  const handlePasswordSubmit = async (e) => {
  e.preventDefault();

  if (newPassword !== confirmPassword) {
    toast.error("Паролі не співпадають");
    return;
  }

  try {
    const storedUser = JSON.parse(localStorage.getItem("user"));

    const response = await fetch("https://localhost:7166/api/auth/change-password", {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        id: storedUser?.user.id,
        oldPassword: currentPassword,
        newPassword: newPassword,
      }),
    });

    const data = await response.json();

    if (!data.isSuccess) {
      toast.error(data.message);
      return;
    }


    toast.success("Пароль змінено");

    setCurrentPassword("");
    setNewPassword("");
    setConfirmPassword("");
  } catch {
    toast.error("Помилка сервера");
  }
};

  return (
    <div style={{ maxWidth: "400px", margin: "0 auto", marginTop: "150px" }}>
      <h2>Профіль</h2>

      <form onSubmit={handleNameSubmit}>
        <h3>Зміна імені</h3>

        <input
          type="text"
          placeholder="New username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />

        <button type="submit">Зберегти</button>
      </form>

      <form onSubmit={handlePasswordSubmit} style={{ marginTop: "30px" }}>
        <h3>Зміна пароля</h3>

        <input
          type="password"
          placeholder="Current password"
          value={currentPassword}
          onChange={(e) => setCurrentPassword(e.target.value)}
        />

        <input
          type="password"
          placeholder="New password"
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
        />

        <input
          type="password"
          placeholder="Confirm password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
        />

        <button type="submit">Змінити пароль</button>
      </form>
    </div>
  );
}
import { motion } from "framer-motion";
import "./StartScreen.css";
import { useNavigate } from "react-router-dom";

export default function StartScreen() {
  const navigate = useNavigate();

  const handleContinue = () => {
    const isAuth = !!localStorage.getItem("user");

    if (isAuth) {
      navigate("/tests");
    } else {
      navigate("/login");
    }
  };

  return (
    <div className="page">
      <motion.div
        initial={{ scale: 0.8, opacity: 0 }}
        animate={{ scale: 1, opacity: 1 }}
        transition={{ duration: 0.4 }}
        className="card"
      >
        <h1 className="title">Привіт</h1>

        <p className="subtitle">
          Натисни кнопку щоб продовжити далі
        </p>

        <button className="button" onClick={handleContinue}>
          Продовжити
        </button>

      </motion.div>
    </div>
  );
}
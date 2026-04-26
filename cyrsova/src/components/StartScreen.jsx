
import { motion } from "framer-motion";
import "./StartScreen.css";
import { Link } from "react-router-dom";
export default function StartScreen() {


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

<Link to="/tests">
  <button className="button">
    Продовжити
  </button>
</Link>
      </motion.div>
    </div>
  );
}
